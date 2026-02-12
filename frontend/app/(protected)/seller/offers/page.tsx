"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchMyOffers, deleteOffer } from "@/lib/api/seller-offers";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import { toast } from "sonner";
import { Plus, Eye, Pencil, Trash2 } from "lucide-react";
import { cn } from "@/lib/utils";
import { formatPrice } from "@/lib/utils";

export default function SellerOffersPage() {
  const queryClient = useQueryClient();

  const { data: offers = [], isLoading } = useQuery({
    queryKey: ["seller-offers"],
    queryFn: fetchMyOffers,
  });

  const deleteMutation = useMutation({
    mutationFn: deleteOffer,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["seller-offers"] });
      toast.success("Offer deleted successfully");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleDelete = (id: string) => {
    if (confirm("Are you sure you want to delete this offer?")) {
      deleteMutation.mutate(id);
    }
  };

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="font-heading text-3xl font-bold text-dark">My Offers</h1>
            <p className="text-muted mt-1">Manage your sale and rental offers</p>
          </div>
          <Link href="/seller/offers/create">
            <Button size="sm">
              <Plus className="h-4 w-4 mr-2" />
              New Offer
            </Button>
          </Link>
        </div>

        {isLoading ? (
          <div className="space-y-4">
            {[1, 2, 3].map((i) => (
              <div key={i} className="rounded-xl border border-border p-6 animate-pulse">
                <div className="h-6 bg-gray-200 rounded w-1/3 mb-3" />
                <div className="h-4 bg-gray-200 rounded w-1/2" />
              </div>
            ))}
          </div>
        ) : offers.length === 0 ? (
          <div className="text-center py-20 rounded-xl border-2 border-dashed border-border">
            <p className="text-muted text-lg mb-4">You have no offers yet.</p>
            <Link href="/seller/offers/create">
              <Button>Create Your First Offer</Button>
            </Link>
          </div>
        ) : (
          <div className="overflow-x-auto rounded-xl border border-border">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-border">
                <tr>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Type</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Price</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Status</th>
                  <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Actions</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-border">
                {offers.map((offer) => (
                  <tr key={offer.id} className="hover:bg-gray-50 transition-colors">
                    <td className="px-6 py-4">
                      <span
                        className={cn(
                          "px-3 py-1 rounded-full text-xs font-semibold",
                          offer.type === "Sale"
                            ? "bg-primary/10 text-primary"
                            : "bg-green-100 text-green-800"
                        )}
                      >
                        {offer.type}
                      </span>
                    </td>
                    <td className="px-6 py-4 font-semibold text-dark">
                      {formatPrice(offer.price)}
                    </td>
                    <td className="px-6 py-4 text-sm text-muted capitalize">{offer.status}</td>
                    <td className="px-6 py-4 text-right">
                      <div className="flex justify-end gap-2">
                        <Link href={`/seller/offers/${offer.id}`}>
                          <Button variant="ghost" size="sm"><Eye className="h-4 w-4" /></Button>
                        </Link>
                        <Link href={`/seller/offers/${offer.id}/edit`}>
                          <Button variant="ghost" size="sm"><Pencil className="h-4 w-4" /></Button>
                        </Link>
                        <Button
                          variant="ghost"
                          size="sm"
                          className="text-red-500 hover:bg-red-50"
                          onClick={() => handleDelete(offer.id)}
                        >
                          <Trash2 className="h-4 w-4" />
                        </Button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </PageLayout>
    </ProtectedRoute>
  );
}
