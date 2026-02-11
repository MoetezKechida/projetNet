"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchReviewsByTarget, createReview } from "@/lib/api/reviews";
import { Button } from "@/components/ui/Button";
import { useAuth } from "@/contexts/AuthContext";
import { formatDate } from "@/lib/utils";
import { Star } from "lucide-react";
import { useState } from "react";
import { toast } from "sonner";

interface ReviewsSectionProps {
  targetId: string;
}

export function ReviewsSection({ targetId }: ReviewsSectionProps) {
  const { isAuthenticated } = useAuth();
  const [comment, setComment] = useState("");
  const [rating, setRating] = useState(5);
  const [showForm, setShowForm] = useState(false);
  const queryClient = useQueryClient();

  const { data, isLoading } = useQuery({
    queryKey: ["reviews", targetId],
    queryFn: () => fetchReviewsByTarget(targetId),
  });

  const createMutation = useMutation({
    mutationFn: createReview,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["reviews", targetId] });
      setComment("");
      setRating(5);
      setShowForm(false);
      toast.success("Review submitted!");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!comment.trim()) return;
    createMutation.mutate({ targetId, comment: comment.trim(), rating });
  };

  const reviews = data?.reviews ?? [];
  const avgRating = data?.averageRating ?? 0;

  return (
    <section>
      <div className="flex items-center justify-between mb-6">
        <h2 className="font-heading text-2xl font-bold text-dark">
          Reviews & Ratings
        </h2>
        <div className="flex items-center gap-2">
          <div className="flex">
            {[1, 2, 3, 4, 5].map((i) => (
              <Star
                key={i}
                className={`h-5 w-5 ${
                  i <= Math.round(avgRating)
                    ? "fill-amber-400 text-amber-400"
                    : "text-gray-300"
                }`}
              />
            ))}
          </div>
          <span className="text-sm text-muted">
            {avgRating.toFixed(1)} ({reviews.length} reviews)
          </span>
        </div>
      </div>

      {isAuthenticated && (
        <div className="mb-8">
          {!showForm ? (
            <Button
              variant="outline"
              size="sm"
              onClick={() => setShowForm(true)}
            >
              Write a review
            </Button>
          ) : (
            <form
              onSubmit={handleSubmit}
              className="rounded-xl border border-border p-6 space-y-4"
            >
              <div>
                <label className="block text-sm font-medium mb-2">Rating</label>
                <div className="flex gap-1">
                  {[1, 2, 3, 4, 5].map((i) => (
                    <button
                      key={i}
                      type="button"
                      onClick={() => setRating(i)}
                      className="p-1"
                    >
                      <Star
                        className={`h-8 w-8 ${
                          i <= rating
                            ? "fill-amber-400 text-amber-400"
                            : "text-gray-300"
                        }`}
                      />
                    </button>
                  ))}
                </div>
              </div>
              <div>
                <label className="block text-sm font-medium mb-2">Comment</label>
                <textarea
                  value={comment}
                  onChange={(e) => setComment(e.target.value)}
                  className="w-full h-24 rounded-lg border border-border px-4 py-3 focus:outline-none focus:ring-2 focus:ring-primary"
                  placeholder="Share your experience..."
                  required
                />
              </div>
              <div className="flex gap-2">
                <Button type="submit" disabled={createMutation.isPending}>
                  Submit
                </Button>
                <Button
                  type="button"
                  variant="ghost"
                  onClick={() => setShowForm(false)}
                >
                  Cancel
                </Button>
              </div>
            </form>
          )}
        </div>
      )}

      {isLoading ? (
        <div className="space-y-4">
          {[1, 2, 3].map((i) => (
            <div
              key={i}
              className="rounded-lg border border-border p-4 animate-pulse"
            >
              <div className="h-4 bg-gray-200 rounded w-1/4 mb-2" />
              <div className="h-4 bg-gray-200 rounded w-full" />
            </div>
          ))}
        </div>
      ) : reviews.length === 0 ? (
        <p className="text-muted">No reviews yet. Be the first to leave one!</p>
      ) : (
        <div className="space-y-4">
          {reviews.map((r) => (
            <div
              key={r.id}
              className="rounded-lg border border-border bg-white p-4 shadow-sm"
            >
              <div className="flex items-center gap-3 mb-2">
                <div className="w-12 h-12 rounded-full bg-primary/20 flex items-center justify-center font-semibold text-primary">
                  {r.reviewerId.slice(0, 2).toUpperCase()}
                </div>
                <div>
                  <div className="flex gap-1">
                    {[1, 2, 3, 4, 5].map((i) => (
                      <Star
                        key={i}
                        className={`h-4 w-4 ${
                          i <= r.rating
                            ? "fill-amber-400 text-amber-400"
                            : "text-gray-300"
                        }`}
                      />
                    ))}
                  </div>
                  <p className="text-sm text-muted">{formatDate(r.createdAt)}</p>
                </div>
              </div>
              <p className="text-foreground leading-relaxed">{r.comment}</p>
            </div>
          ))}
        </div>
      )}
    </section>
  );
}
