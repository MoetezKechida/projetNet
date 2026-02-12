"use client";

import { useQuery } from "@tanstack/react-query";
import { fetchDashboardStats } from "@/lib/api/dashboard";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import { formatPrice, formatDate } from "@/lib/utils";
import { Users, DollarSign, Car, TrendingUp } from "lucide-react";

export default function DashboardPage() {
  const { data, isLoading } = useQuery({
    queryKey: ["dashboard-stats"],
    queryFn: fetchDashboardStats,
  });

  const sales = data?.sales ?? [];
  const bookings = data?.bookings ?? [];
  const totalSalesAmount = sales.reduce((sum, s) => sum + s.amount, 0);
  const totalBookingsAmount = bookings.reduce((sum, b) => sum + b.totalAmount, 0);

  return (
    <ProtectedRoute requiredRole="Admin">
      <PageLayout>
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="font-heading text-3xl font-bold text-dark">Admin Dashboard</h1>
            <p className="text-muted mt-1">Overview of platform activity</p>
          </div>
          <Link href="/dashboard/inspectors">
            <Button variant="outline" size="sm">
              <Users className="h-4 w-4 mr-2" />
              Manage Inspectors
            </Button>
          </Link>
        </div>

        {/* Stats Cards */}
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mb-10">
          {[
            { icon: DollarSign, label: "Total Sales", value: formatPrice(totalSalesAmount), color: "text-green-600 bg-green-100" },
            { icon: Car, label: "Sales Count", value: sales.length.toString(), color: "text-blue-600 bg-blue-100" },
            { icon: TrendingUp, label: "Bookings Revenue", value: formatPrice(totalBookingsAmount), color: "text-purple-600 bg-purple-100" },
            { icon: Users, label: "Bookings Count", value: bookings.length.toString(), color: "text-amber-600 bg-amber-100" },
          ].map((stat) => (
            <div key={stat.label} className="rounded-xl border border-border bg-white p-6 shadow-card">
              <div className="flex items-center gap-3 mb-3">
                <div className={`w-10 h-10 rounded-lg flex items-center justify-center ${stat.color}`}>
                  <stat.icon className="h-5 w-5" />
                </div>
                <p className="text-sm text-muted">{stat.label}</p>
              </div>
              <p className="font-heading text-2xl font-bold text-dark">{isLoading ? "..." : stat.value}</p>
            </div>
          ))}
        </div>

        {/* Sales Table */}
        <div className="mb-10">
          <h2 className="font-heading text-xl font-bold text-dark mb-4">Sales History</h2>
          {isLoading ? (
            <div className="rounded-xl border border-border p-8 animate-pulse">
              <div className="h-6 bg-gray-200 rounded w-1/3 mb-4" />
              <div className="h-4 bg-gray-200 rounded w-full" />
            </div>
          ) : sales.length === 0 ? (
            <div className="rounded-xl border-2 border-dashed border-border p-8 text-center text-muted">
              No sales recorded yet.
            </div>
          ) : (
            <div className="overflow-x-auto rounded-xl border border-border">
              <table className="w-full">
                <thead className="bg-gray-50 border-b border-border">
                  <tr>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Offer ID</th>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Buyer ID</th>
                    <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Amount</th>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Status</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-border">
                  {sales.map((sale) => (
                    <tr key={sale.id} className="hover:bg-gray-50">
                      <td className="px-6 py-4 text-sm text-dark font-mono">{sale.offerId.slice(0, 8)}...</td>
                      <td className="px-6 py-4 text-sm text-muted font-mono">{sale.buyerId.slice(0, 8)}...</td>
                      <td className="px-6 py-4 text-right font-semibold text-dark">{formatPrice(sale.amount)}</td>
                      <td className="px-6 py-4 text-sm capitalize text-muted">{sale.status}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </div>

        {/* Bookings Table */}
        <div>
          <h2 className="font-heading text-xl font-bold text-dark mb-4">Rent History</h2>
          {isLoading ? (
            <div className="rounded-xl border border-border p-8 animate-pulse">
              <div className="h-6 bg-gray-200 rounded w-1/3 mb-4" />
              <div className="h-4 bg-gray-200 rounded w-full" />
            </div>
          ) : bookings.length === 0 ? (
            <div className="rounded-xl border-2 border-dashed border-border p-8 text-center text-muted">
              No bookings recorded yet.
            </div>
          ) : (
            <div className="overflow-x-auto rounded-xl border border-border">
              <table className="w-full">
                <thead className="bg-gray-50 border-b border-border">
                  <tr>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Buyer ID</th>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Start Date</th>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">End Date</th>
                    <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Total</th>
                    <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Status</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-border">
                  {bookings.map((b) => (
                    <tr key={b.id} className="hover:bg-gray-50">
                      <td className="px-6 py-4 text-sm text-muted font-mono">{b.buyerId.slice(0, 8)}...</td>
                      <td className="px-6 py-4 text-sm text-dark">{formatDate(b.startDate)}</td>
                      <td className="px-6 py-4 text-sm text-dark">{formatDate(b.endDate)}</td>
                      <td className="px-6 py-4 text-right font-semibold text-dark">{formatPrice(b.totalAmount)}</td>
                      <td className="px-6 py-4 text-sm capitalize text-muted">{b.status}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </div>
      </PageLayout>
    </ProtectedRoute>
  );
}
