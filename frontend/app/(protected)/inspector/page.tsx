"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchPendingVehicles, acceptVehicle, declineVehicle } from "@/lib/api/inspections";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Image from "next/image";
import { useState } from "react";
import { toast } from "sonner";
import { Check, X, Search, MapPin, Gauge, Calendar } from "lucide-react";
import { formatPrice } from "@/lib/utils";
import type { Vehicle } from "@/types";

const BRANDS = ["Renault", "Toyota", "BMW", "Mercedes"];

export default function InspectorPage() {
  const queryClient = useQueryClient();
  const [brandFilter, setBrandFilter] = useState("");
  const [decliningId, setDecliningId] = useState<string | null>(null);
  const [reason, setReason] = useState("");

  const { data: vehicles = [], isLoading } = useQuery({
    queryKey: ["pending-vehicles", brandFilter],
    queryFn: () => fetchPendingVehicles(brandFilter || undefined),
  });

  const acceptMutation = useMutation({
    mutationFn: acceptVehicle,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pending-vehicles"] });
      toast.success("Vehicle accepted successfully!");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const declineMutation = useMutation({
    mutationFn: ({ vehicleId, reason }: { vehicleId: string; reason: string }) =>
      declineVehicle(vehicleId, reason),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["pending-vehicles"] });
      setDecliningId(null);
      setReason("");
      toast.success("Vehicle declined");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleDecline = (vehicleId: string) => {
    if (!reason.trim()) {
      toast.error("Please provide a reason for declining");
      return;
    }
    declineMutation.mutate({ vehicleId, reason: reason.trim() });
  };

  return (
    <ProtectedRoute requiredRole="Inspector">
      <PageLayout>
        <div className="mb-8">
          <h1 className="font-heading text-3xl font-bold text-dark">Vehicle Inspections</h1>
          <p className="text-muted mt-1">Review pending vehicles and approve or decline them</p>
        </div>

        {/* Brand Filter */}
        <div className="mb-8 max-w-xs">
          <label className="block text-sm font-medium text-dark mb-2">Filter by Brand</label>
          <select
            value={brandFilter}
            onChange={(e) => setBrandFilter(e.target.value)}
            className="w-full h-11 rounded-lg border border-border px-4 text-sm focus:outline-none focus:ring-2 focus:ring-primary bg-white"
          >
            <option value="">All Brands</option>
            {BRANDS.map((b) => (
              <option key={b} value={b}>{b}</option>
            ))}
          </select>
        </div>

        {/* Vehicles Grid */}
        {isLoading ? (
          <div className="grid md:grid-cols-2 gap-6">
            {[1, 2, 3, 4].map((i) => (
              <div key={i} className="rounded-xl border border-border p-4 animate-pulse">
                <div className="h-48 bg-gray-200 rounded-lg mb-4" />
                <div className="h-5 bg-gray-200 rounded w-2/3 mb-2" />
                <div className="h-4 bg-gray-200 rounded w-1/2" />
              </div>
            ))}
          </div>
        ) : vehicles.length === 0 ? (
          <div className="rounded-xl border-2 border-dashed border-border p-12 text-center">
            <Search className="h-12 w-12 mx-auto text-muted mb-4" />
            <h3 className="font-heading text-xl font-semibold text-dark mb-2">No Pending Vehicles</h3>
            <p className="text-muted">There are no vehicles waiting for inspection right now.</p>
          </div>
        ) : (
          <div className="grid md:grid-cols-2 gap-6">
            {vehicles.map((vehicle: Vehicle) => {
              const label = [vehicle.brand, vehicle.model].filter(Boolean).join(" ");
              const imageUrl =
                vehicle.imageUrl ||
                `https://placehold.co/600x400/1a1a1a/fff?text=${encodeURIComponent(label)}`;

              return (
                <div
                  key={vehicle.id}
                  className="rounded-xl border border-border bg-white shadow-card overflow-hidden hover:shadow-lg transition-shadow"
                >
                  {/* Image */}
                  <div className="relative h-52 bg-gray-100">
                    <Image
                      src={imageUrl}
                      alt={label}
                      fill
                      className="object-cover"
                      sizes="(max-width: 768px) 100vw, 50vw"
                    />
                  </div>

                  {/* Body */}
                  <div className="p-5">
                    <h3 className="font-heading text-lg font-bold text-dark mb-3">
                      {vehicle.brand} {vehicle.model} ({vehicle.year})
                    </h3>

                    <div className="grid grid-cols-2 gap-2 text-sm mb-4">
                      <div className="flex items-center gap-2 text-muted">
                        <span className="font-medium text-dark">VIN:</span>
                        <span className="truncate">{vehicle.vin}</span>
                      </div>
                      {vehicle.mileage != null && (
                        <div className="flex items-center gap-2 text-muted">
                          <Gauge className="h-4 w-4" />
                          {vehicle.mileage.toLocaleString()} km
                        </div>
                      )}
                      {vehicle.location && (
                        <div className="flex items-center gap-2 text-muted">
                          <MapPin className="h-4 w-4" />
                          {vehicle.location}
                        </div>
                      )}
                      <div className="flex items-center gap-2 text-muted">
                        <Calendar className="h-4 w-4" />
                        {vehicle.year}
                      </div>
                    </div>

                    <div className="flex gap-3 mb-3">
                      {vehicle.price != null && vehicle.price > 0 && (
                        <span className="inline-flex items-center gap-1 px-3 py-1 rounded-full bg-green-50 text-green-700 text-sm font-medium">
                          Sale: {formatPrice(vehicle.price)}
                        </span>
                      )}
                      {vehicle.rentalPrice != null && vehicle.rentalPrice > 0 && (
                        <span className="inline-flex items-center gap-1 px-3 py-1 rounded-full bg-blue-50 text-blue-700 text-sm font-medium">
                          Rent: {formatPrice(vehicle.rentalPrice)}/day
                        </span>
                      )}
                    </div>

                    {vehicle.description && (
                      <p className="text-sm text-muted line-clamp-2 mb-4">{vehicle.description}</p>
                    )}

                    {/* Decline form (shown inline) */}
                    {decliningId === vehicle.id ? (
                      <div className="rounded-lg border border-red-200 bg-red-50 p-4 mb-4">
                        <h4 className="text-sm font-semibold text-red-800 mb-2">Reason for Declining</h4>
                        <textarea
                          value={reason}
                          onChange={(e) => setReason(e.target.value)}
                          className="w-full h-20 rounded-lg border border-red-200 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-red-400 bg-white"
                          placeholder="Describe why this vehicle is being declined..."
                          required
                        />
                        <div className="flex gap-2 mt-2">
                          <Button
                            size="sm"
                            className="bg-red-600 hover:bg-red-700"
                            onClick={() => handleDecline(vehicle.id)}
                            disabled={declineMutation.isPending}
                          >
                            {declineMutation.isPending ? "Declining..." : "Confirm Decline"}
                          </Button>
                          <Button
                            variant="ghost"
                            size="sm"
                            onClick={() => {
                              setDecliningId(null);
                              setReason("");
                            }}
                          >
                            Cancel
                          </Button>
                        </div>
                      </div>
                    ) : null}

                    {/* Action Buttons */}
                    <div className="flex gap-3">
                      <Button
                        size="sm"
                        className="flex-1 bg-green-600 hover:bg-green-700"
                        onClick={() => {
                          if (confirm("Accept this vehicle? It will become visible to buyers.")) {
                            acceptMutation.mutate(vehicle.id);
                          }
                        }}
                        disabled={acceptMutation.isPending}
                      >
                        <Check className="h-4 w-4 mr-1" /> Accept
                      </Button>
                      <Button
                        size="sm"
                        variant="outline"
                        className="flex-1 border-red-300 text-red-600 hover:bg-red-50"
                        onClick={() => {
                          setDecliningId(vehicle.id);
                          setReason("");
                        }}
                      >
                        <X className="h-4 w-4 mr-1" /> Decline
                      </Button>
                    </div>
                  </div>
                </div>
              );
            })}
          </div>
        )}
      </PageLayout>
    </ProtectedRoute>
  );
}
