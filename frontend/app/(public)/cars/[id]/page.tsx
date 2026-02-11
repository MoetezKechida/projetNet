"use client";

import { useParams, useRouter } from "next/navigation";
import Image from "next/image";
import { useQuery } from "@tanstack/react-query";
import { fetchVehicle } from "@/lib/api/vehicles";
import { fetchReviewsByTarget } from "@/lib/api/reviews";
import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { Button } from "@/components/ui/Button";
import { formatPrice, formatDate } from "@/lib/utils";
import { CarDetailSkeleton } from "@/components/cars/CarDetailSkeleton";
import { ReviewsSection } from "@/components/reviews/ReviewsSection";

export default function CarDetailPage() {
  const params = useParams();
  const router = useRouter();
  const id = params.id as string;

  const { data: vehicle, isLoading } = useQuery({
    queryKey: ["vehicle", id],
    queryFn: () => fetchVehicle(id),
    enabled: !!id,
  });

  const label = [vehicle?.brand, vehicle?.model].filter(Boolean).join(" ") || "Car";
  const imageUrl =
    vehicle?.imageUrl ||
    `https://placehold.co/800x500/1a1a1a/fff?text=${encodeURIComponent(label)}`;

  if (!id) {
    router.replace("/cars");
    return null;
  }

  if (isLoading) {
    return (
      <div className="min-h-screen">
        <Header />
        <main className="pt-24 pb-16">
          <CarDetailSkeleton />
        </main>
        <Footer />
      </div>
    );
  }

  if (!vehicle) {
    return (
      <div className="min-h-screen">
        <Header />
        <main className="pt-24 pb-16 text-center">
          <p className="text-muted">Vehicle not found.</p>
        </main>
        <Footer />
      </div>
    );
  }

  const price = vehicle.rentalPrice ?? vehicle.price ?? 0;

  return (
    <div className="min-h-screen">
      <Header />

      <main className="pt-24 pb-16 px-6">
        <div className="mx-auto max-w-7xl">
          <div className="grid lg:grid-cols-[1.2fr_1fr] gap-12">
            <div>
              <div className="relative aspect-[16/10] rounded-xl overflow-hidden bg-gray-100">
                <Image
                  src={imageUrl}
                  alt={`${vehicle.brand} ${vehicle.model ?? ""}`}
                  fill
                  className="object-cover"
                  sizes="(max-width: 1024px) 100vw, 60vw"
                  priority
                />
              </div>
            </div>

            <div>
              <h1 className="font-heading text-4xl font-bold text-dark mb-4">
                {vehicle.brand} - {vehicle.model ?? "Model"}
              </h1>
              <p className="text-3xl font-semibold text-primary mb-6">
                {price > 0 ? `${formatPrice(price)}/day` : "Contact for price"}
              </p>
              {vehicle.description && (
                <p className="text-muted leading-relaxed mb-8">
                  {vehicle.description}
                </p>
              )}
              <Button size="lg" className="w-full sm:w-auto h-14 px-10">
                Book Now
              </Button>

              <div className="mt-12">
                <h3 className="text-sm font-semibold uppercase tracking-wider text-muted mb-4">
                  Specifications
                </h3>
                <div className="grid grid-cols-2 gap-4">
                  <div className="flex items-center gap-3">
                    <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                      <span className="text-lg">🚗</span>
                    </div>
                    <div>
                      <p className="text-sm text-muted">Type</p>
                      <p className="font-medium">Sedan</p>
                    </div>
                  </div>
                  <div className="flex items-center gap-3">
                    <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                      <span className="text-lg">⚙</span>
                    </div>
                    <div>
                      <p className="text-sm text-muted">Year</p>
                      <p className="font-medium">{vehicle.year}</p>
                    </div>
                  </div>
                  {vehicle.mileage != null && (
                    <div className="flex items-center gap-3">
                      <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                        <span className="text-lg">📏</span>
                      </div>
                      <div>
                        <p className="text-sm text-muted">Mileage</p>
                        <p className="font-medium">{vehicle.mileage.toLocaleString()} km</p>
                      </div>
                    </div>
                  )}
                  {vehicle.location && (
                    <div className="flex items-center gap-3">
                      <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                        <span className="text-lg">📍</span>
                      </div>
                      <div>
                        <p className="text-sm text-muted">Location</p>
                        <p className="font-medium">{vehicle.location}</p>
                      </div>
                    </div>
                  )}
                </div>
              </div>
            </div>
          </div>

          <div className="mt-20">
            <ReviewsSection targetId={vehicle.id} />
          </div>
        </div>
      </main>

      <Footer />
    </div>
  );
}
