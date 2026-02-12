"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchMyInspections, deleteInspection } from "@/lib/api/inspections";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import Link from "next/link";
import { toast } from "sonner";
import { ArrowLeft, Trash2, ClipboardList } from "lucide-react";
import type { Inspection } from "@/types";

export default function MyInspectionsPage() {
  const queryClient = useQueryClient();

  const { data: inspections = [], isLoading } = useQuery({
    queryKey: ["my-inspections"],
    queryFn: fetchMyInspections,
  });

  const deleteMutation = useMutation({
    mutationFn: deleteInspection,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["my-inspections"] });
      toast.success("Inspection record deleted");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  return (
    <ProtectedRoute requiredRole="Inspector">
      <PageLayout>
        <Link
          href="/inspector"
          className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
        >
          <ArrowLeft className="h-4 w-4" /> Back to Pending Vehicles
        </Link>

        <div className="mb-8">
          <h1 className="font-heading text-3xl font-bold text-dark">My Inspections</h1>
          <p className="text-muted mt-1">History of vehicles you have inspected</p>
        </div>

        {isLoading ? (
          <div className="rounded-xl border border-border p-8 animate-pulse">
            <div className="h-6 bg-gray-200 rounded w-1/3 mb-4" />
            <div className="h-4 bg-gray-200 rounded w-full mb-2" />
            <div className="h-4 bg-gray-200 rounded w-3/4" />
          </div>
        ) : inspections.length === 0 ? (
          <div className="rounded-xl border-2 border-dashed border-border p-12 text-center">
            <ClipboardList className="h-12 w-12 mx-auto text-muted mb-4" />
            <h3 className="font-heading text-xl font-semibold text-dark mb-2">No Inspections Yet</h3>
            <p className="text-muted mb-4">You haven&#39;t declined any vehicles yet.</p>
            <Link href="/inspector">
              <Button size="sm">View Pending Vehicles</Button>
            </Link>
          </div>
        ) : (
          <div className="overflow-x-auto rounded-xl border border-border">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-border">
                <tr>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Vehicle ID</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Reason</th>
                  <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Actions</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-border">
                {inspections.map((inspection: Inspection) => (
                  <tr key={inspection.id} className="hover:bg-gray-50">
                    <td className="px-6 py-4 text-sm font-mono text-dark">
                      {inspection.vehicleId.slice(0, 8)}...
                    </td>
                    <td className="px-6 py-4 text-sm text-dark max-w-md">
                      <p className="line-clamp-2">{inspection.reason || "—"}</p>
                    </td>
                    <td className="px-6 py-4 text-right">
                      <Button
                        variant="ghost"
                        size="sm"
                        className="text-red-500 hover:bg-red-50"
                        onClick={() => {
                          if (confirm("Delete this inspection record?"))
                            deleteMutation.mutate(inspection.id);
                        }}
                      >
                        <Trash2 className="h-4 w-4" />
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
