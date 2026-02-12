"use client";

import { useQuery, useMutation } from "@tanstack/react-query";
import { fetchMyVehiclesForOffer, createOffer } from "@/lib/api/seller-offers";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState } from "react";
import { toast } from "sonner";
import { ArrowLeft } from "lucide-react";

export default function CreateOfferPage() {
  const router = useRouter();

  const { data: vehicles = [] } = useQuery({
    queryKey: ["my-vehicles-for-offer"],
    queryFn: fetchMyVehiclesForOffer,
  });

  const [form, setForm] = useState({
    type: "Sale",
    price: "",
    vehicleId: "",
  });

  const createMutation = useMutation({
    mutationFn: createOffer,
    onSuccess: () => {
      toast.success("Offer created successfully!");
      router.push("/seller/offers");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!form.vehicleId) {
      toast.error("Please select a vehicle");
      return;
    }
    createMutation.mutate({
      type: form.type,
      price: Number(form.price),
      vehicleId: form.vehicleId,
    });
  };

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        <div className="max-w-lg mx-auto">
          <Link
            href="/seller/offers"
            className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
          >
            <ArrowLeft className="h-4 w-4" /> Back to Offers
          </Link>

          <h1 className="font-heading text-3xl font-bold text-dark mb-8">Create New Offer</h1>

          <form onSubmit={handleSubmit} className="space-y-6">
            <div className="flex flex-col gap-1.5">
              <label className="text-sm font-medium text-foreground">Offer Type</label>
              <select
                value={form.type}
                onChange={(e) => setForm({ ...form, type: e.target.value })}
                className="h-12 rounded-lg border border-border bg-white px-4 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
              >
                <option value="Sale">Sale</option>
                <option value="Rent">Rent</option>
              </select>
            </div>

            <Input
              label="Price (€)"
              type="number"
              required
              min="1"
              value={form.price}
              onChange={(e) => setForm({ ...form, price: e.target.value })}
              placeholder="Enter price"
            />

            <div className="flex flex-col gap-1.5">
              <label className="text-sm font-medium text-foreground">Vehicle</label>
              <select
                value={form.vehicleId}
                onChange={(e) => setForm({ ...form, vehicleId: e.target.value })}
                className="h-12 rounded-lg border border-border bg-white px-4 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                required
              >
                <option value="">Select a vehicle</option>
                {vehicles.map((v) => (
                  <option key={v.id} value={v.id}>
                    {v.brand} {v.model} ({v.year})
                  </option>
                ))}
              </select>
            </div>

            <div className="flex gap-3">
              <Button type="submit" disabled={createMutation.isPending}>
                {createMutation.isPending ? "Creating..." : "Create Offer"}
              </Button>
              <Link href="/seller/offers">
                <Button variant="ghost" type="button">Cancel</Button>
              </Link>
            </div>
          </form>
        </div>
      </PageLayout>
    </ProtectedRoute>
  );
}
