import { apiFetch, getAuthHeaders } from "./client";
import type { Review } from "@/types";

export async function fetchReviewsByTarget(targetId: string) {
  return apiFetch<{ reviews: Review[]; averageRating: number }>(
    `/api/reviews/by-target/${targetId}`
  );
}

export async function fetchReviewsByReviewer(reviewerId: string) {
  return apiFetch<Review[]>(`/api/reviews/by-reviewer/${reviewerId}`);
}

export async function fetchAllReviews(): Promise<Review[]> {
  return apiFetch<Review[]>("/api/reviews");
}

export async function fetchReview(id: string): Promise<Review> {
  return apiFetch<Review>(`/api/reviews/${id}`);
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

export async function updateReview(
  id: string,
  data: { comment: string; rating: number }
) {
  return apiFetch<Review>(`/api/reviews/${id}`, {
    method: "PUT",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}

export async function deleteReview(id: string) {
  return apiFetch(`/api/reviews/${id}`, {
    method: "DELETE",
    headers: getAuthHeaders(),
  });
}
