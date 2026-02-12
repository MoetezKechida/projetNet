"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchAllReviews, deleteReview } from "@/lib/api/reviews";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import { toast } from "sonner";
import { Star, Trash2, MessageSquare } from "lucide-react";
import { formatDate } from "@/lib/utils";
import type { Review } from "@/types";

export default function ReviewsPage() {
  const queryClient = useQueryClient();

  const { data: reviews = [], isLoading } = useQuery({
    queryKey: ["all-reviews"],
    queryFn: fetchAllReviews,
  });

  const deleteMutation = useMutation({
    mutationFn: deleteReview,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["all-reviews"] });
      toast.success("Review deleted");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const renderStars = (rating: number) => (
    <div className="flex">
      {[1, 2, 3, 4, 5].map((i) => (
        <Star
          key={i}
          className={`h-4 w-4 ${
            i <= rating ? "fill-amber-400 text-amber-400" : "text-gray-300"
          }`}
        />
      ))}
    </div>
  );

  return (
    <ProtectedRoute>
      <PageLayout>
        <div className="mb-8">
          <h1 className="font-heading text-3xl font-bold text-dark">My Reviews</h1>
          <p className="text-muted mt-1">Manage your reviews and ratings</p>
        </div>

        {isLoading ? (
          <div className="space-y-4">
            {[1, 2, 3].map((i) => (
              <div key={i} className="rounded-xl border border-border p-6 animate-pulse">
                <div className="h-5 bg-gray-200 rounded w-1/4 mb-3" />
                <div className="h-4 bg-gray-200 rounded w-3/4 mb-2" />
                <div className="h-4 bg-gray-200 rounded w-1/2" />
              </div>
            ))}
          </div>
        ) : reviews.length === 0 ? (
          <div className="rounded-xl border-2 border-dashed border-border p-12 text-center">
            <MessageSquare className="h-12 w-12 mx-auto text-muted mb-4" />
            <h3 className="font-heading text-xl font-semibold text-dark mb-2">No Reviews Yet</h3>
            <p className="text-muted">
              You haven&#39;t written any reviews. Visit a car listing to leave your feedback!
            </p>
          </div>
        ) : (
          <div className="space-y-4">
            {reviews.map((review: Review) => (
              <div
                key={review.id}
                className="rounded-xl border border-border bg-white p-6 shadow-card hover:shadow-lg transition-shadow"
              >
                <div className="flex items-start justify-between">
                  <div className="flex-1">
                    <div className="flex items-center gap-3 mb-2">
                      {renderStars(review.rating)}
                      <span className="text-sm font-medium text-dark">
                        {review.rating}/5
                      </span>
                    </div>
                    <p className="text-dark mb-3">{review.comment}</p>
                    <div className="flex items-center gap-4 text-sm text-muted">
                      <span>Target: {review.targetId.slice(0, 8)}...</span>
                      <span>Created: {formatDate(review.createdAt)}</span>
                    </div>
                  </div>
                  <Button
                    variant="ghost"
                    size="sm"
                    className="text-red-500 hover:bg-red-50 ml-4"
                    onClick={() => {
                      if (confirm("Delete this review?"))
                        deleteMutation.mutate(review.id);
                    }}
                  >
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>
              </div>
            ))}
          </div>
        )}
      </PageLayout>
    </ProtectedRoute>
  );
}
