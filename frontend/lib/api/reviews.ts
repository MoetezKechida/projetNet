import { apiFetch, getAuthHeaders } from "./client";
import type { Review } from "@/types";

export async function fetchReviewsByTarget(targetId: string) {
  return apiFetch<{ reviews: Review[]; averageRating: number }>(
    `/api/reviews/by-target/${targetId}`
  );
}

export async function createReview(data: {
  targetId: string;
  comment: string;
  rating: number;
}) {
  return apiFetch<Review>("/api/reviews", {
    method: "POST",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}
