"use client";

import { useQuery } from "@tanstack/react-query";
import { fetchMyBookings } from "@/lib/api/bookings";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import { formatPrice, formatDate } from "@/lib/utils";
import { cn } from "@/lib/utils";
import { ShoppingBag } from "lucide-react";

export default function MyBookingsPage() {
  const { data: bookings = [], isLoading } = useQuery({
    queryKey: ["my-bookings"],
    queryFn: fetchMyBookings,
  });

  return (
    <ProtectedRoute requiredRole="Buyer">
      <PageLayout>
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="font-heading text-3xl font-bold text-dark">My Bookings</h1>
            <p className="text-muted mt-1">Track your vehicle bookings</p>
          </div>
          <Link href="/cars">
            <Button variant="outline" size="sm">Browse Vehicles</Button>
          </Link>
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
            <ShoppingBag className="h-12 w-12 text-muted mx-auto mb-4" />
            <p className="text-muted text-lg mb-4">You haven&apos;t made any bookings yet.</p>
            <Link href="/cars">
              <Button>Browse Vehicles</Button>
            </Link>
          </div>
        ) : (
          <div className="overflow-x-auto rounded-xl border border-border">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-border">
                <tr>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Vehicle</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Seller</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Type</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Period</th>
                  <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Total</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-border">
                {bookings.map((bd) => (
                  <tr key={bd.booking.id} className="hover:bg-gray-50 transition-colors">
                    <td className="px-6 py-4">
                      <p className="font-semibold text-dark">
                        {bd.vehicle ? `${bd.vehicle.brand} ${bd.vehicle.model || ""}` : "Unknown"}
                      </p>
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
