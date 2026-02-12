"use client";

import { useQuery } from "@tanstack/react-query";
import { fetchDeclineReason } from "@/lib/api/seller-vehicles";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import Image from "next/image";
import { useParams } from "next/navigation";
import { ArrowLeft, AlertTriangle } from "lucide-react";
import { formatPrice } from "@/lib/utils";

export default function VehicleReasonPage() {
  const params = useParams();
  const vehicleId = params.id as string;

  const { data, isLoading } = useQuery({
    queryKey: ["vehicle-reason", vehicleId],
    queryFn: () => fetchDeclineReason(vehicleId),
    enabled: !!vehicleId,
  });

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        <div className="max-w-2xl mx-auto">
          <Link
            href="/seller/vehicles"
            className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
          >
            <ArrowLeft className="h-4 w-4" /> Back to My Vehicles
          </Link>

          {isLoading ? (
            <div className="flex justify-center py-20">
              <div className="w-8 h-8 border-4 border-primary border-t-transparent rounded-full animate-spin" />
            </div>
          ) : !data?.vehicle ? (
            <div className="text-center py-20">
              <p className="text-muted text-lg">Vehicle not found</p>
            </div>
          ) : (
            <div className="rounded-xl border border-border bg-white overflow-hidden shadow-card">
              {data.vehicle.imageUrl && (
                <div className="aspect-[16/9] relative">
                  <Image
                    src={data.vehicle.imageUrl}
                    alt={`${data.vehicle.brand} ${data.vehicle.model || ""}`}
                    fill
                    className="object-cover"
                  />
                </div>
              )}

              <div className="p-6 space-y-4">
                <h1 className="font-heading text-2xl font-bold text-dark">
                  {data.vehicle.brand} {data.vehicle.model} ({data.vehicle.year})
                </h1>

                <div className="grid grid-cols-2 gap-3 text-sm">
                  <div><span className="text-muted">VIN:</span> <span className="font-medium">{data.vehicle.vin}</span></div>
                  <div><span className="text-muted">Price:</span> <span className="font-medium">{data.vehicle.price ? formatPrice(data.vehicle.price) : "N/A"}</span></div>
                  <div><span className="text-muted">Rental:</span> <span className="font-medium">{data.vehicle.rentalPrice ? `${formatPrice(data.vehicle.rentalPrice)}/day` : "N/A"}</span></div>
                  <div><span className="text-muted">Mileage:</span> <span className="font-medium">{data.vehicle.mileage?.toLocaleString() || "N/A"} km</span></div>
                  <div><span className="text-muted">Location:</span> <span className="font-medium">{data.vehicle.location || "N/A"}</span></div>
                  <div><span className="text-muted">Status:</span> <span className="font-medium text-red-600 capitalize">{data.vehicle.status}</span></div>
                </div>

                <hr className="border-border" />

                <div className="rounded-lg bg-red-50 border border-red-200 p-4">
                  <div className="flex items-center gap-2 mb-2">
                    <AlertTriangle className="h-5 w-5 text-red-500" />
                    <h3 className="font-heading font-semibold text-red-800">Decline Reason</h3>
                  </div>
                  {data.inspection ? (
                    <p className="text-red-700">{data.inspection.reason}</p>
                  ) : (
                    <p className="text-red-600 italic">No inspection reason available</p>
                  )}
                </div>
              </div>
            </div>
          )}
        </div>
      </PageLayout>
    </ProtectedRoute>
  );
}
