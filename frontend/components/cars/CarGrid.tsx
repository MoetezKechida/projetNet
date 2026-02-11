"use client";

import { useQuery } from "@tanstack/react-query";
import { fetchVehicles } from "@/lib/api/vehicles";
import { CarCard } from "./CarCard";
import { CarGridSkeleton } from "./CarGridSkeleton";

interface CarGridProps {
  featuredFirst?: boolean;
  limit?: number;
}

export function CarGrid({ featuredFirst, limit }: CarGridProps) {
  const { data: vehicles = [], isLoading } = useQuery({
    queryKey: ["vehicles"],
    queryFn: fetchVehicles,
  });

  const displayVehicles = limit ? vehicles.slice(0, limit) : vehicles;
  const sorted = featuredFirst
    ? [...displayVehicles].sort((a) => (a.status === "accepted" ? -1 : 1))
    : displayVehicles;

  if (isLoading) {
    return <CarGridSkeleton />;
  }

  if (vehicles.length === 0) {
    return (
      <div className="text-center py-16">
        <p className="text-muted text-lg">No vehicles available yet.</p>
      </div>
    );
  }

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
      {sorted.map((vehicle, i) => (
        <CarCard
          key={vehicle.id}
          vehicle={vehicle}
          featured={featuredFirst && i === 0}
        />
      ))}
    </div>
  );
}
