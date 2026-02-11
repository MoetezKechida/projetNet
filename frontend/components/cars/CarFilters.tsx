"use client";

import { useMemo } from "react";
import { useQuery } from "@tanstack/react-query";
import { fetchVehicles } from "@/lib/api/vehicles";
import { Input } from "@/components/ui/Input";
import { cn } from "@/lib/utils";

interface Filters {
  brand: string;
  minYear: string;
  maxYear: string;
  minPrice: string;
  maxPrice: string;
  type?: string;
}

interface CarFiltersProps {
  filters: Filters;
  onFiltersChange: (f: Filters) => void;
}

const carTypes = ["Sedan", "Sports", "SUV", "Coupe", "Convertible"];

export function CarFilters({ filters, onFiltersChange }: CarFiltersProps) {
  const { data: vehicles = [] } = useQuery({
    queryKey: ["vehicles"],
    queryFn: fetchVehicles,
  });

  const brands = useMemo(
    () => Array.from(new Set(vehicles.map((v) => v.brand))).sort(),
    [vehicles]
  );

  const update = (key: keyof Filters, value: string) => {
    onFiltersChange({ ...filters, [key]: value });
  };

  const clearAll = () => {
    onFiltersChange({
      brand: "",
      minYear: "",
      maxYear: "",
      minPrice: "",
      maxPrice: "",
    });
  };

  const activeCount = [
    filters.brand,
    filters.minYear,
    filters.maxYear,
    filters.minPrice,
    filters.maxPrice,
  ].filter(Boolean).length;

  return (
    <div className="rounded-xl bg-white border border-border p-6 shadow-card sticky top-24 space-y-6">
      <div className="flex items-center justify-between">
        <h3 className="font-heading font-semibold text-dark">Filters</h3>
        {activeCount > 0 && (
          <button
            onClick={clearAll}
            className="text-sm text-primary hover:underline"
          >
            Clear all
          </button>
        )}
      </div>

      <div>
        <label className="block text-sm font-medium text-foreground mb-2">
          Brand
        </label>
        <select
          value={filters.brand}
          onChange={(e) => update("brand", e.target.value)}
          className="w-full h-12 rounded-lg border border-border bg-white px-4 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
        >
          <option value="">All brands</option>
          {brands.map((b) => (
            <option key={b} value={b}>
              {b}
            </option>
          ))}
        </select>
      </div>

      <div className="grid grid-cols-2 gap-4">
        <Input
          label="Min Year"
          type="number"
          placeholder="e.g. 2020"
          value={filters.minYear}
          onChange={(e) => update("minYear", e.target.value)}
        />
        <Input
          label="Max Year"
          type="number"
          placeholder="e.g. 2024"
          value={filters.maxYear}
          onChange={(e) => update("maxYear", e.target.value)}
        />
      </div>

      <div className="grid grid-cols-2 gap-4">
        <Input
          label="Min Price €"
          type="number"
          placeholder="0"
          value={filters.minPrice}
          onChange={(e) => update("minPrice", e.target.value)}
        />
        <Input
          label="Max Price €"
          type="number"
          placeholder="500"
          value={filters.maxPrice}
          onChange={(e) => update("maxPrice", e.target.value)}
        />
      </div>

      <div>
        <label className="block text-sm font-medium text-foreground mb-2">
          Type
        </label>
        <div className="flex flex-wrap gap-2">
          {carTypes.map((t) => (
            <button
              key={t}
              onClick={() =>
                update("type", filters.type === t.toLowerCase() ? "" : t.toLowerCase())
              }
              className={cn(
                "px-4 py-2 rounded-full text-sm font-medium border-2 transition-colors",
                filters.type === t.toLowerCase()
                  ? "bg-primary text-white border-primary"
                  : "border-border text-dark hover:border-primary"
              )}
            >
              {t}
            </button>
          ))}
        </div>
      </div>
    </div>
  );
}
