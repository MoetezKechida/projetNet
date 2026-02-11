const API_BASE = process.env.NEXT_PUBLIC_API_URL || "http://localhost:5234";

export async function apiFetch<T>(
  path: string,
  options?: RequestInit & { params?: Record<string, string> }
): Promise<T> {
  const { params, ...rest } = options ?? {};
  const url = params
    ? `${API_BASE}${path}?${new URLSearchParams(params)}`
    : `${API_BASE}${path}`;

  const res = await fetch(url, {
    ...rest,
    headers: {
      "Content-Type": "application/json",
      ...getAuthHeaders(),
      ...rest.headers,
    },
  });

  if (!res.ok) {
    const body = await res.json().catch(() => ({}));
    const err = body as { message?: string; errors?: { field?: string; message?: string }[] };
    const details = Array.isArray(err.errors) && err.errors.length > 0
      ? err.errors.map((e) => e.message ?? e.field).filter(Boolean).join(". ")
      : null;
    const msg = details ?? err.message ?? res.statusText ?? "Request failed";
    throw new Error(msg);
  }

  if (res.status === 204) return undefined as T;
  return res.json();
}

export function getAuthHeaders(): Record<string, string> {
  if (typeof window === "undefined") return {};
  const token = localStorage.getItem("token");
  return token ? { Authorization: `Bearer ${token}` } : {};
}
