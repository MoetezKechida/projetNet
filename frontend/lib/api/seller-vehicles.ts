import { apiFetch, getAuthHeaders } from "./client";
import type { Vehicle, BrandsWithModels } from "@/types";

export async function fetchMyVehicles(status?: string): Promise<Vehicle[]> {
  const params = status ? `?status=${status}` : "";
  return apiFetch<Vehicle[]>(`/api/sellervehicles${params}`, {
    headers: getAuthHeaders(),
  });
}

export async function fetchBrandsWithModels(): Promise<BrandsWithModels> {
  return apiFetch<BrandsWithModels>("/api/sellervehicles/brands");
}

export async function createSellerVehicle(formData: FormData) {
  const token =
    typeof window !== "undefined" ? localStorage.getItem("token") : null;
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_API_URL || "http://localhost:5234"}/api/sellervehicles`,
    {
      method: "POST",
      headers: token ? { Authorization: `Bearer ${token}` } : {},
      body: formData,
    }
  );
  if (!res.ok) {
    const body = await res.json().catch(() => ({}));
    throw new Error(body.message || "Failed to create vehicle");
  }
  return res.json();
}

export async function updateSellerVehicle(id: string, formData: FormData) {
  const token =
    typeof window !== "undefined" ? localStorage.getItem("token") : null;
  const res = await fetch(
    `${process.env.NEXT_PUBLIC_API_URL || "http://localhost:5234"}/api/sellervehicles/${id}`,
    {
      method: "PUT",
      headers: token ? { Authorization: `Bearer ${token}` } : {},
      body: formData,
    }
  );
  if (!res.ok) {
    const body = await res.json().catch(() => ({}));
    throw new Error(body.message || "Failed to update vehicle");
  }
  return res.json();
}

export async function deleteSellerVehicle(id: string) {
  return apiFetch(`/api/sellervehicles/${id}`, {
    method: "DELETE",
    headers: getAuthHeaders(),
  });
}

export async function fetchDeclineReason(vehicleId: string) {
  return apiFetch<{ vehicle: Vehicle; inspection: { id: string; vehicleId: string; inspectorId: string; reason: string } | null }>(
    `/api/sellervehicles/${vehicleId}/reason`,
    { headers: getAuthHeaders() }
  );
}
