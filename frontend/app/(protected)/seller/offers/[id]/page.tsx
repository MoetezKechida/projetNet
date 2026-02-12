"use client";

import { useQuery } from "@tanstack/react-query";
import { fetchOfferDetails } from "@/lib/api/seller-offers";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import { useParams } from "next/navigation";
import { ArrowLeft, Pencil } from "lucide-react";
import { formatPrice } from "@/lib/utils";
import { cn } from "@/lib/utils";

export default function OfferDetailsPage() {
  const params = useParams();
  const offerId = params.id as string;

  const { data, isLoading } = useQuery({
    queryKey: ["offer-details", offerId],
    queryFn: () => fetchOfferDetails(offerId),
    enabled: !!offerId,
  });

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        <div className="max-w-2xl mx-auto">
          <Link
            href="/seller/offers"
            className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
          >
            <ArrowLeft className="h-4 w-4" /> Back to Offers
          </Link>

          {isLoading ? (
            <div className="rounded-xl border border-border p-8 animate-pulse">
              <div className="h-8 bg-gray-200 rounded w-1/2 mb-4" />
              <div className="h-4 bg-gray-200 rounded w-3/4 mb-2" />
              <div className="h-4 bg-gray-200 rounded w-1/3" />
            </div>
          ) : !data ? (
            <div className="text-center py-20">
              <p className="text-muted text-lg">Offer not found</p>
            </div>
          ) : (
            <div className="rounded-xl border border-border bg-white p-8 shadow-card">
              <div className="flex items-start justify-between mb-6">
                <div>
                  <h1 className="font-heading text-2xl font-bold text-dark">Offer Details</h1>
                  <p className="text-muted text-sm mt-1">ID: {data.offer.id.slice(0, 8)}...</p>
                </div>
                <Link href={`/seller/offers/${offerId}/edit`}>
                  <Button variant="outline" size="sm">
                    <Pencil className="h-4 w-4 mr-1" /> Edit
                  </Button>
                </Link>
              </div>

              <div className="grid grid-cols-2 gap-6">
                <div>
                  <p className="text-sm text-muted mb-1">Type</p>
                  <span
                    className={cn(
                      "px-3 py-1 rounded-full text-sm font-semibold",
                      data.offer.type === "Sale"
                        ? "bg-primary/10 text-primary"
                        : "bg-green-100 text-green-800"
                    )}
                  >
                    {data.offer.type}
                  </span>
                </div>
                <div>
                  <p className="text-sm text-muted mb-1">Status</p>
                  <p className="font-semibold text-dark capitalize">{data.offer.status}</p>
                </div>
                <div>
                  <p className="text-sm text-muted mb-1">Price</p>
                  <p className="font-heading text-xl font-bold text-dark">
                    {formatPrice(data.offer.price)}
                  </p>
                </div>
                {data.vehicle && (
                  <div>
                    <p className="text-sm text-muted mb-1">Vehicle</p>
                    <p className="font-semibold text-dark">
                      {data.vehicle.brand} {data.vehicle.model} ({data.vehicle.year})
                    </p>
                  </div>
                )}
              </div>
            </div>
          )}
        </div>
      </PageLayout>
    </ProtectedRoute>
  );
}
