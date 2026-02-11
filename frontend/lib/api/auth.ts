import { apiFetch, getAuthHeaders } from "./client";
import type { AuthResponse, UserInfo } from "@/types";

export async function register(data: {
  email: string;
  password: string;
  confirmPassword: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  userType?: string;
}) {
  return apiFetch<AuthResponse>("/api/auth/register", {
    method: "POST",
    body: JSON.stringify(data),
  });
}

export async function login(data: { email: string; password: string }) {
  return apiFetch<AuthResponse>("/api/auth/login", {
    method: "POST",
    body: JSON.stringify(data),
  });
}

export async function refreshToken(refreshToken: string) {
  return apiFetch<AuthResponse>("/api/auth/refresh-token", {
    method: "POST",
    body: JSON.stringify({ refreshToken }),
  });
}

export async function getMe() {
  return apiFetch<UserInfo>("/api/auth/me", {
    headers: getAuthHeaders(),
  });
}

export async function logout() {
  await apiFetch("/api/auth/logout", {
    method: "POST",
    headers: getAuthHeaders(),
  }).catch(() => {});
}
