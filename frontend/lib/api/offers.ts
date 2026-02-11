import { apiFetch } from "./client";
import type { Offer } from "@/types";

export async function fetchOffers(): Promise<Offer[]> {
  const data = await apiFetch<Offer[]>("/api/offers");
  return Array.isArray(data) ? data : [];
}

export async function fetchOffer(id: string): Promise<Offer | null> {
  try {
    return await apiFetch<Offer>(`/api/offers/${id}`);
  } catch {
    return null;
  }
}
