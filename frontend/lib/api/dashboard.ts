import { apiFetch, getAuthHeaders } from "./client";
import type { DashboardStats, InspectorUser } from "@/types";

export async function fetchDashboardStats(): Promise<DashboardStats> {
  return apiFetch<DashboardStats>("/api/dashboard/stats", {
    headers: getAuthHeaders(),
  });
}

export async function fetchInspectors(): Promise<InspectorUser[]> {
  return apiFetch<InspectorUser[]>("/api/dashboard/inspectors", {
    headers: getAuthHeaders(),
  });
}

export async function createInspector(data: {
  email: string;
  firstName: string;
  lastName: string;
  password: string;
}) {
  return apiFetch("/api/dashboard/inspectors", {
    method: "POST",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}

export async function updateInspector(
  id: string,
  data: { email: string; firstName: string; lastName: string }
) {
  return apiFetch(`/api/dashboard/inspectors/${id}`, {
    method: "PUT",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}

export async function deleteInspector(id: string) {
  return apiFetch(`/api/dashboard/inspectors/${id}`, {
    method: "DELETE",
    headers: getAuthHeaders(),
  });
}
