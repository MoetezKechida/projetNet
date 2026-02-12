import { apiFetch, getAuthHeaders } from "./client";
import type { Vehicle, Inspection } from "@/types";

export async function fetchPendingVehicles(brand?: string): Promise<Vehicle[]> {
  const params = brand ? `?brand=${brand}` : "";
  return apiFetch<Vehicle[]>(`/api/inspections/pending-vehicles${params}`, {
    headers: getAuthHeaders(),
  });
}

export async function fetchMyInspections(): Promise<Inspection[]> {
  return apiFetch<Inspection[]>("/api/inspections", {
    headers: getAuthHeaders(),
  });
}

export async function acceptVehicle(vehicleId: string) {
  return apiFetch(`/api/inspections/${vehicleId}/accept`, {
    method: "POST",
    headers: getAuthHeaders(),
  });
}

export async function declineVehicle(vehicleId: string, reason: string) {
  return apiFetch("/api/inspections/decline", {
    method: "POST",
    body: JSON.stringify({ vehicleId, reason }),
    headers: getAuthHeaders(),
  });
}

export async function deleteInspection(id: string) {
  return apiFetch(`/api/inspections/${id}`, {
    method: "DELETE",
    headers: getAuthHeaders(),
  });
}
