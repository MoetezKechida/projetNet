"use client";

import { useState, useMemo, Suspense } from "react";
import { useSearchParams } from "next/navigation";
import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { CarFilters } from "@/components/cars/CarFilters";
import { useQuery } from "@tanstack/react-query";
import { fetchVehicles } from "@/lib/api/vehicles";
import { CarCard } from "@/components/cars/CarCard";
import { CarGridSkeleton } from "@/components/cars/CarGridSkeleton";
import type { Vehicle } from "@/types";

function CarsContent() {
  const searchParams = useSearchParams();
  const typeParam = searchParams.get("type") ?? "";
  const [filters, setFilters] = useState({
    brand: "",
    minYear: "",
    maxYear: "",
    minPrice: "",
    maxPrice: "",
    ...(typeParam && { type: typeParam }),
  });

  const { data: vehicles = [], isLoading } = useQuery({
    queryKey: ["vehicles"],
    queryFn: fetchVehicles,
  });

  const filtered = useMemo(() => {
    let result = vehicles;
    if (filters.brand) {
      result = result.filter((v) =>
        v.brand.toLowerCase().includes(filters.brand.toLowerCase())
      );
    }
    if (filters.minYear) {
      const y = parseInt(filters.minYear, 10);
      result = result.filter((v) => v.year >= y);
    }
    if (filters.maxYear) {
      const y = parseInt(filters.maxYear, 10);
      result = result.filter((v) => v.year <= y);
    }
    const price = (v: Vehicle) => v.rentalPrice ?? v.price ?? 0;
    if (filters.minPrice) {
      const p = parseFloat(filters.minPrice);
      result = result.filter((v) => price(v) >= p);
    }
    if (filters.maxPrice) {
      const p = parseFloat(filters.maxPrice);
      result = result.filter((v) => price(v) <= p);
    }
    return result;
  }, [vehicles, filters]);

  return (
    <div className="min-h-screen">
      <Header />

      <main className="pt-24 pb-16">
        <div className="mx-auto max-w-7xl px-6">
          <h1 className="font-heading text-4xl font-bold text-dark mb-8">
            Our Impressive Fleet
          </h1>

          <div className="flex flex-col lg:flex-row gap-8">
            <aside className="lg:w-64 shrink-0">
              <CarFilters filters={filters} onFiltersChange={setFilters} />
            </aside>

            <div className="flex-1 min-w-0">
              {isLoading ? (
                <CarGridSkeleton />
              ) : (
                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-2 xl:grid-cols-3 gap-6">
                  {filtered.map((vehicle) => (
                    <CarCard key={vehicle.id} vehicle={vehicle} />
                  ))}
                </div>
              )}
              {!isLoading && filtered.length === 0 && (
                <div className="text-center py-16">
                  <p className="text-muted text-lg">
                    No vehicles match your filters.
                  </p>
                </div>
              )}
            </div>
          </div>
        </div>
      </main>

      <Footer />
    </div>
  );
}

export default function CarsPage() {
  return (
    <Suspense fallback={
      <div className="min-h-screen">
        <Header />
        <main className="pt-24 pb-16"><CarGridSkeleton /></main>
        <Footer />
      </div>
    }>
      <CarsContent />
    </Suspense>
  );
}
