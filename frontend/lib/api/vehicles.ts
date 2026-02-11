import { apiFetch, getAuthHeaders } from "./client";
import type { Vehicle } from "@/types";

export async function fetchVehicles(): Promise<Vehicle[]> {
  const data = await apiFetch<Vehicle[]>("/api/vehicles");
  return Array.isArray(data) ? data : [];
}

export async function fetchVehicle(id: string): Promise<Vehicle | null> {
  try {
    return await apiFetch<Vehicle>(`/api/vehicles/${id}`);
  } catch {
    return null;
  }
}

export async function createVehicle(vehicle: Partial<Vehicle>) {
  return apiFetch<Vehicle>("/api/vehicles", {
    method: "POST",
    body: JSON.stringify(vehicle),
    headers: getAuthHeaders(),
  });
}
