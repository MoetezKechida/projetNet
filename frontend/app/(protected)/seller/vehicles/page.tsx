"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchMyVehicles, deleteSellerVehicle } from "@/lib/api/seller-vehicles";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import Image from "next/image";
import { useState } from "react";
import { toast } from "sonner";
import { cn, formatPrice } from "@/lib/utils";
import { Pencil, Trash2, AlertCircle, Plus, Filter } from "lucide-react";

const statusColors: Record<string, string> = {
  pending: "bg-amber-100 text-amber-800",
  accepted: "bg-green-100 text-green-800",
  declined: "bg-red-100 text-red-800",
};

export default function SellerVehiclesPage() {
  const [statusFilter, setStatusFilter] = useState<string>("");
  const queryClient = useQueryClient();

  const { data: vehicles = [], isLoading } = useQuery({
    queryKey: ["seller-vehicles", statusFilter],
    queryFn: () => fetchMyVehicles(statusFilter || undefined),
  });

  const deleteMutation = useMutation({
    mutationFn: deleteSellerVehicle,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["seller-vehicles"] });
      toast.success("Vehicle deleted successfully");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleDelete = (id: string) => {
    if (confirm("Are you sure you want to delete this vehicle?")) {
      deleteMutation.mutate(id);
    }
  };

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        {/* Page Header */}
        <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 mb-8">
          <div>
            <h1 className="font-heading text-3xl font-bold text-dark">My Vehicles</h1>
            <p className="text-muted mt-1">Manage your vehicle listings</p>
          </div>
          <div className="flex gap-3">
            <Link href="/bookings/requests">
              <Button variant="outline" size="sm">Booking Requests</Button>
            </Link>
            <Link href="/seller/vehicles/create">
              <Button size="sm">
                <Plus className="h-4 w-4 mr-2" />
                Add Vehicle
              </Button>
            </Link>
          </div>
        </div>

        {/* Status Filter */}
        <div className="flex items-center gap-3 mb-6">
          <Filter className="h-5 w-5 text-muted" />
          <div className="flex gap-2">
            {["", "pending", "accepted", "declined"].map((s) => (
              <button
                key={s}
                onClick={() => setStatusFilter(s)}
                className={cn(
                  "px-4 py-2 rounded-full text-sm font-medium border-2 transition-colors",
                  statusFilter === s
                    ? "bg-primary text-white border-primary"
                    : "border-border text-dark hover:border-primary"
                )}
              >
                {s || "All"}
              </button>
            ))}
          </div>
        </div>

        {/* Vehicle Grid */}
        {isLoading ? (
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            {[1, 2, 3, 4].map((i) => (
              <div key={i} className="rounded-xl border border-border p-6 animate-pulse">
                <div className="h-48 bg-gray-200 rounded-lg mb-4" />
                <div className="h-6 bg-gray-200 rounded w-3/4 mb-2" />
                <div className="h-4 bg-gray-200 rounded w-1/2" />
              </div>
            ))}
          </div>
        ) : vehicles.length === 0 ? (
          <div className="text-center py-20 rounded-xl border-2 border-dashed border-border">
            <p className="text-muted text-lg mb-4">You have no vehicles yet.</p>
            <Link href="/seller/vehicles/create">
              <Button>Add Your First Vehicle</Button>
            </Link>
          </div>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            {vehicles.map((vehicle) => (
              <div
                key={vehicle.id}
                className="rounded-xl border border-border bg-white overflow-hidden shadow-card hover:shadow-card-hover transition-shadow"
              >
                {/* Status Badge */}
                <div className="relative">
                  <div className="aspect-[16/10] relative bg-gray-100">
                    <Image
                      src={
                        vehicle.imageUrl ||
                        `https://placehold.co/600x400/1a1a1a/fff?text=${encodeURIComponent(vehicle.brand)}`
                      }
                      alt={`${vehicle.brand} ${vehicle.model || ""}`}
                      fill
                      className="object-cover"
                      sizes="(max-width: 768px) 100vw, 50vw"
                    />
                  </div>
                  <span
                    className={cn(
                      "absolute top-3 right-3 px-3 py-1 rounded-full text-xs font-semibold capitalize",
                      statusColors[vehicle.status || "pending"]
                    )}
                  >
                    {vehicle.status || "pending"}
                  </span>
                </div>

                <div className="p-5">
                  <h3 className="font-heading text-xl font-bold text-dark">
                    {vehicle.brand} {vehicle.model} ({vehicle.year})
                  </h3>
                  <p className="text-sm text-muted mt-1">VIN: {vehicle.vin}</p>

                  <div className="grid grid-cols-2 gap-2 mt-3 text-sm">
                    <div>
                      <span className="text-muted">Sale Price:</span>{" "}
                      <span className="font-semibold">
                        {vehicle.price ? formatPrice(vehicle.price) : "N/A"}
                      </span>
                    </div>
                    <div>
                      <span className="text-muted">Rental:</span>{" "}
                      <span className="font-semibold">
                        {vehicle.rentalPrice ? `${formatPrice(vehicle.rentalPrice)}/day` : "N/A"}
                      </span>
                    </div>
                    {vehicle.mileage != null && (
                      <div>
                        <span className="text-muted">Mileage:</span>{" "}
                        <span className="font-semibold">{vehicle.mileage.toLocaleString()} km</span>
                      </div>
                    )}
                    {vehicle.location && (
                      <div>
                        <span className="text-muted">Location:</span>{" "}
                        <span className="font-semibold">{vehicle.location}</span>
                      </div>
                    )}
                  </div>

                  {vehicle.description && (
                    <p className="text-sm text-muted mt-3 line-clamp-2">{vehicle.description}</p>
                  )}

                  <div className="flex gap-2 mt-4">
                    <Link href={`/seller/vehicles/${vehicle.id}/edit`} className="flex-1">
                      <Button variant="outline" size="sm" className="w-full">
                        <Pencil className="h-4 w-4 mr-1" /> Edit
                      </Button>
                    </Link>
                    <Button
                      variant="outline"
                      size="sm"
                      className="text-red-500 border-red-200 hover:bg-red-50"
                      onClick={() => handleDelete(vehicle.id)}
                    >
                      <Trash2 className="h-4 w-4" />
                    </Button>
                    {vehicle.status === "declined" && (
                      <Link href={`/seller/vehicles/${vehicle.id}/reason`}>
                        <Button variant="outline" size="sm" className="text-amber-600 border-amber-200">
                          <AlertCircle className="h-4 w-4 mr-1" /> Reason
                        </Button>
                      </Link>
                    )}
                  </div>
                </div>
              </div>
            ))}
          </div>
        )}
      </PageLayout>
    </ProtectedRoute>
  );
}
