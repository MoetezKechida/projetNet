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

export interface VehicleWithSeller {
  vehicle: Vehicle;
  seller: {
    id: string;
    firstName?: string;
    lastName?: string;
    email?: string;
    phoneNumber?: string;
    rating: number;
    reviewCount: number;
    isVerifiedSeller?: boolean;
  } | null;
}

export async function fetchVehicleDetails(id: string): Promise<VehicleWithSeller | null> {
  try {
    return await apiFetch<VehicleWithSeller>(`/api/vehicles/${id}/details`);
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
