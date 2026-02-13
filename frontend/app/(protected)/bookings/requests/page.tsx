"use client";

import { useCallback, useMemo } from "react";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchBookingRequests, completeTransaction } from "@/lib/api/bookings";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import { formatPrice, formatDate, cn } from "@/lib/utils";
import { toast } from "sonner";
import { ArrowLeft, CheckCircle } from "lucide-react";
import { useSignalR } from "@/hooks/useSignalR";
import type { BookingNotification } from "@/types";

export default function BookingRequestsPage() {
  const queryClient = useQueryClient();

  const { data: bookings = [], isLoading } = useQuery({
    queryKey: ["booking-requests"],
    queryFn: fetchBookingRequests,
  });

  // ── Real-time: listen for new bookings via SignalR ──
  const signalRHandlers = useMemo(
    () => ({
      NewBookingReceived: (notification: BookingNotification) => {
        // Refresh the booking list so the new entry appears instantly
        queryClient.invalidateQueries({ queryKey: ["booking-requests"] });

        toast.info("New booking request!", {
          description: `${notification.buyerName} wants to ${notification.bookingType.toLowerCase()} your ${notification.vehicleModel}`,
          duration: 6000,
        });
      },
    }),
    [queryClient]
  );

  useSignalR("/hubs/booking", signalRHandlers);

  const completeMutation = useMutation({
    mutationFn: completeTransaction,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["booking-requests"] });
      toast.success("Transaction completed successfully!");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleComplete = useCallback(
    (id: string) => {
      if (confirm("Are you sure you want to complete this transaction?")) {
        completeMutation.mutate(id);
      }
    },
    [completeMutation]
  );

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        <Link
          href="/seller/vehicles"
          className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
        >
          <ArrowLeft className="h-4 w-4" /> Back to Vehicles
        </Link>

        <div className="mb-8">
          <h1 className="font-heading text-3xl font-bold text-dark">Booking Requests</h1>
          <p className="text-muted mt-1">Manage incoming booking requests from buyers</p>
        </div>

        {isLoading ? (
          <div className="space-y-4">
            {[1, 2, 3].map((i) => (
              <div key={i} className="rounded-xl border border-border p-6 animate-pulse">
                <div className="h-6 bg-gray-200 rounded w-1/3 mb-3" />
                <div className="h-4 bg-gray-200 rounded w-1/2" />
              </div>
            ))}
          </div>
        ) : bookings.length === 0 ? (
          <div className="text-center py-20 rounded-xl border-2 border-dashed border-border">
            <p className="text-muted text-lg">No booking requests yet.</p>
          </div>
        ) : (
          <div className="overflow-x-auto rounded-xl border border-border">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-border">
                <tr>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Vehicle</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Buyer</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Type</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Period</th>
                  <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Total</th>
                  <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Action</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-border">
                {bookings.map((bd) => (
                  <tr key={bd.booking.id} className="hover:bg-gray-50 transition-colors">
                    <td className="px-6 py-4 font-semibold text-dark">
                      {bd.vehicle ? `${bd.vehicle.brand} ${bd.vehicle.model || ""}` : "Unknown"}
                    </td>
                    <td className="px-6 py-4">
                      <p className="text-sm text-dark">{bd.user?.firstName} {bd.user?.lastName}</p>
                      <p className="text-xs text-muted">{bd.user?.email}</p>
                      {bd.user?.phoneNumber && (
                        <p className="text-xs text-muted">{bd.user.phoneNumber}</p>
                      )}
                    </td>
                    <td className="px-6 py-4">
                      <span
                        className={cn(
                          "px-3 py-1 rounded-full text-xs font-semibold",
                          bd.booking.bookingType === "Buy"
                            ? "bg-primary/10 text-primary"
                            : "bg-green-100 text-green-800"
                        )}
                      >
                        {bd.booking.bookingType}
                      </span>
                    </td>
                    <td className="px-6 py-4 text-sm text-muted">
                      {bd.booking.bookingType === "Rent"
                        ? `${formatDate(bd.booking.startDate)} — ${formatDate(bd.booking.endDate)}`
                        : "One-time purchase"}
                    </td>
                    <td className="px-6 py-4 text-right font-semibold text-dark">
                      {formatPrice(bd.booking.totalAmount)}
                    </td>
                    <td className="px-6 py-4 text-right">
                      <Button
                        size="sm"
                        onClick={() => handleComplete(bd.booking.id)}
                        disabled={completeMutation.isPending}
                      >
                        <CheckCircle className="h-4 w-4 mr-1" />
                        Complete
                      </Button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </PageLayout>
    </ProtectedRoute>
  );
}
