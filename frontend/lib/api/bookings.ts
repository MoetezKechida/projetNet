import { apiFetch, getAuthHeaders } from "./client";
import type { BookingDetails } from "@/types";

export async function createBooking(data: {
  vehicleId: string;
  bookingType: string;
  startDate?: string;
  endDate?: string;
}) {
  return apiFetch("/api/bookings", {
    method: "POST",
    body: JSON.stringify(data),
    headers: getAuthHeaders(),
  });
}

export async function fetchMyBookings(): Promise<BookingDetails[]> {
  return apiFetch<BookingDetails[]>("/api/bookings/my-bookings", {
    headers: getAuthHeaders(),
  });
}

export async function fetchBookingRequests(): Promise<BookingDetails[]> {
  return apiFetch<BookingDetails[]>("/api/bookings/requests", {
    headers: getAuthHeaders(),
  });
}

export async function completeTransaction(id: string) {
  return apiFetch(`/api/bookings/${id}/complete`, {
    method: "POST",
    headers: getAuthHeaders(),
  });
}
