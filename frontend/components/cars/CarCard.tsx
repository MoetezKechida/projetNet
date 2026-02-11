"use client";

import Image from "next/image";
import Link from "next/link";
import { motion } from "framer-motion";
import { formatPrice } from "@/lib/utils";
import type { Vehicle } from "@/types";
import { cn } from "@/lib/utils";

interface CarCardProps {
  vehicle: Vehicle;
  featured?: boolean;
}

const PLACEHOLDER_IMAGE = "/car-placeholder.jpg";

function getCarImageUrl(vehicle: Vehicle): string {
  if (vehicle.imageUrl) return vehicle.imageUrl;
  return `https://placehold.co/600x400/1a1a1a/fff?text=${encodeURIComponent(vehicle.brand + " " + (vehicle.model || ""))}`;
}

export function CarCard({ vehicle, featured }: CarCardProps) {
  const price = vehicle.rentalPrice ?? vehicle.price ?? 0;
  const displayPrice = price > 0 ? formatPrice(price) : "Contact for price";

  return (
    <motion.div
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.5, ease: "easeOut" }}
      whileHover={{ y: -8, transition: { duration: 0.2 } }}
      className={cn(
        "group overflow-hidden rounded-xl shadow-card hover:shadow-card-hover transition-shadow duration-200",
        featured
          ? "bg-primary text-white"
          : "bg-white"
      )}
    >
      <Link href={`/cars/${vehicle.id}`}>
        <div className="relative aspect-[4/3] overflow-hidden">
          <Image
            src={getCarImageUrl(vehicle)}
            alt={`${vehicle.brand} ${vehicle.model ?? ""}`}
            fill
            className="object-cover group-hover:scale-105 transition-transform duration-300"
            sizes="(max-width: 640px) 100vw, (max-width: 1024px) 50vw, 33vw"
          />
          {featured && (
            <span className="absolute top-4 left-4 rounded-full bg-white/20 px-3 py-1 text-sm font-semibold">
              Featured
            </span>
          )}
        </div>
        <div className={cn(
          "p-6 flex flex-col gap-3",
          featured ? "text-white" : "text-dark"
        )}>
          <h3 className="font-heading text-xl font-bold">
            {vehicle.brand} - {vehicle.model ?? "Model"}
          </h3>
          <p className={cn(
            "text-base",
            featured ? "text-white/90" : "text-muted"
          )}>
            Starting at {displayPrice}/day
          </p>
          <span className={cn(
            "inline-flex items-center justify-end mt-2",
            "text-sm font-semibold",
            featured ? "text-white" : "text-primary"
          )}>
            View →
          </span>
        </div>
      </Link>
    </motion.div>
  );
}
