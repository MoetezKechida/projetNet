import { apiFetch, getAuthHeaders } from "./client";
import type { Offer } from "@/types";

export async function fetchMyOffers(): Promise<Offer[]> {
  return apiFetch<Offer[]>("/api/selleroffers", {
    headers: getAuthHeaders(),
  });
}

export async function fetchOfferDetails(id: string) {
  return apiFetch<{
    offer: Offer;
    vehicle: { id: string; brand: string; model?: string; year: number; imageUrl?: string; price?: number; rentalPrice?: number } | null;
  }>(`/api/selleroffers/${id}`, {
    headers: getAuthHeaders(),
  });
}

export async function fetchMyVehiclesForOffer() {
  return apiFetch<{ id: string; brand: string; model?: string; year: number }[]>(
    "/api/selleroffers/my-vehicles",
    { headers: getAuthHeaders() }
  );
}

export async function createOffer(data: {
  type: string;
  price: number;
  vehicleId: string;
}) {
  return apiFetch("/api/selleroffers", {
    method: "POST",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}

export async function updateOffer(
  id: string,
  data: { type: string; price: number; vehicleId: string; status: string }
) {
  return apiFetch(`/api/selleroffers/${id}`, {
    method: "PUT",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}

export async function deleteOffer(id: string) {
  return apiFetch(`/api/selleroffers/${id}`, {
    method: "DELETE",
    headers: getAuthHeaders(),
  });
}
