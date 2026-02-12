"use client";

import { useQuery, useMutation } from "@tanstack/react-query";
import { fetchOfferDetails, fetchMyVehiclesForOffer, updateOffer } from "@/lib/api/seller-offers";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import Link from "next/link";
import { useRouter, useParams } from "next/navigation";
import { useState, useEffect } from "react";
import { toast } from "sonner";
import { ArrowLeft } from "lucide-react";

export default function EditOfferPage() {
  const router = useRouter();
  const params = useParams();
  const offerId = params.id as string;

  const { data, isLoading } = useQuery({
    queryKey: ["offer-details", offerId],
    queryFn: () => fetchOfferDetails(offerId),
    enabled: !!offerId,
  });

  const { data: vehicles = [] } = useQuery({
    queryKey: ["my-vehicles-for-offer"],
    queryFn: fetchMyVehiclesForOffer,
  });

  const [form, setForm] = useState({
    type: "Sale",
    price: "",
    vehicleId: "",
    status: "Active",
  });

  useEffect(() => {
    if (data?.offer) {
      setForm({
        type: data.offer.type,
        price: data.offer.price.toString(),
        vehicleId: data.offer.vehicleId,
        status: data.offer.status,
      });
    }
  }, [data]);

  const updateMutation = useMutation({
    mutationFn: (d: { type: string; price: number; vehicleId: string; status: string }) =>
      updateOffer(offerId, d),
    onSuccess: () => {
      toast.success("Offer updated successfully!");
      router.push("/seller/offers");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    updateMutation.mutate({
      type: form.type,
      price: Number(form.price),
      vehicleId: form.vehicleId,
      status: form.status,
    });
  };

  if (isLoading) {
    return (
      <ProtectedRoute requiredRole="Seller">
        <PageLayout>
          <div className="flex justify-center py-20">
            <div className="w-8 h-8 border-4 border-primary border-t-transparent rounded-full animate-spin" />
          </div>
        </PageLayout>
      </ProtectedRoute>
    );
  }

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

          <h1 className="font-heading text-3xl font-bold text-dark mb-8">Edit Offer</h1>

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

            <div className="flex flex-col gap-1.5">
              <label className="text-sm font-medium text-foreground">Status</label>
              <select
                value={form.status}
                onChange={(e) => setForm({ ...form, status: e.target.value })}
                className="h-12 rounded-lg border border-border bg-white px-4 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
              >
                <option value="Active">Active</option>
                <option value="Inactive">Inactive</option>
              </select>
            </div>

            <div className="flex gap-3">
              <Button type="submit" disabled={updateMutation.isPending}>
                {updateMutation.isPending ? "Saving..." : "Save Changes"}
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
