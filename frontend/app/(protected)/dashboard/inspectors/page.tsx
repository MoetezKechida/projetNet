"use client";

import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { fetchInspectors, createInspector, updateInspector, deleteInspector } from "@/lib/api/dashboard";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import Link from "next/link";
import { useState } from "react";
import { toast } from "sonner";
import { ArrowLeft, Plus, Pencil, Trash2, X } from "lucide-react";
import type { InspectorUser } from "@/types";

export default function ManageInspectorsPage() {
  const queryClient = useQueryClient();
  const [showCreate, setShowCreate] = useState(false);
  const [editingId, setEditingId] = useState<string | null>(null);

  const [form, setForm] = useState({ email: "", firstName: "", lastName: "", password: "" });
  const [editForm, setEditForm] = useState({ email: "", firstName: "", lastName: "" });

  const { data: inspectors = [], isLoading } = useQuery({
    queryKey: ["inspectors"],
    queryFn: fetchInspectors,
  });

  const createMutation = useMutation({
    mutationFn: createInspector,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["inspectors"] });
      setShowCreate(false);
      setForm({ email: "", firstName: "", lastName: "", password: "" });
      toast.success("Inspector created successfully");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const updateMutation = useMutation({
    mutationFn: ({ id, ...data }: { id: string; email: string; firstName: string; lastName: string }) =>
      updateInspector(id, data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["inspectors"] });
      setEditingId(null);
      toast.success("Inspector updated successfully");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const deleteMutation = useMutation({
    mutationFn: deleteInspector,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["inspectors"] });
      toast.success("Inspector deleted successfully");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const startEdit = (inspector: InspectorUser) => {
    setEditingId(inspector.id);
    setEditForm({
      email: inspector.email,
      firstName: inspector.firstName || "",
      lastName: inspector.lastName || "",
    });
  };

  return (
    <ProtectedRoute requiredRole="Admin">
      <PageLayout>
        <Link
          href="/dashboard"
          className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
        >
          <ArrowLeft className="h-4 w-4" /> Back to Dashboard
        </Link>

        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="font-heading text-3xl font-bold text-dark">Manage Inspectors</h1>
            <p className="text-muted mt-1">Add, edit, or remove inspectors</p>
          </div>
          <Button size="sm" onClick={() => setShowCreate(!showCreate)}>
            {showCreate ? <X className="h-4 w-4 mr-2" /> : <Plus className="h-4 w-4 mr-2" />}
            {showCreate ? "Cancel" : "Add Inspector"}
          </Button>
        </div>

        {/* Create Form */}
        {showCreate && (
          <div className="rounded-xl border border-border bg-white p-6 shadow-card mb-8">
            <h3 className="font-heading font-semibold text-dark mb-4">Add New Inspector</h3>
            <form
              onSubmit={(e) => {
                e.preventDefault();
                createMutation.mutate(form);
              }}
              className="grid grid-cols-1 sm:grid-cols-2 gap-4"
            >
              <Input
                label="Email"
                type="email"
                required
                value={form.email}
                onChange={(e) => setForm({ ...form, email: e.target.value })}
              />
              <Input
                label="Password"
                type="password"
                required
                value={form.password}
                onChange={(e) => setForm({ ...form, password: e.target.value })}
              />
              <Input
                label="First Name"
                required
                value={form.firstName}
                onChange={(e) => setForm({ ...form, firstName: e.target.value })}
              />
              <Input
                label="Last Name"
                required
                value={form.lastName}
                onChange={(e) => setForm({ ...form, lastName: e.target.value })}
              />
              <div className="sm:col-span-2">
                <Button type="submit" disabled={createMutation.isPending}>
                  {createMutation.isPending ? "Creating..." : "Add Inspector"}
                </Button>
              </div>
            </form>
          </div>
        )}

        {/* Inspectors Table */}
        {isLoading ? (
          <div className="rounded-xl border border-border p-8 animate-pulse">
            <div className="h-6 bg-gray-200 rounded w-1/3 mb-4" />
            <div className="h-4 bg-gray-200 rounded w-full mb-2" />
            <div className="h-4 bg-gray-200 rounded w-3/4" />
          </div>
        ) : inspectors.length === 0 ? (
          <div className="rounded-xl border-2 border-dashed border-border p-8 text-center text-muted">
            No inspectors found. Add one above.
          </div>
        ) : (
          <div className="overflow-x-auto rounded-xl border border-border">
            <table className="w-full">
              <thead className="bg-gray-50 border-b border-border">
                <tr>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Email</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">First Name</th>
                  <th className="text-left px-6 py-4 text-sm font-semibold text-dark">Last Name</th>
                  <th className="text-right px-6 py-4 text-sm font-semibold text-dark">Actions</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-border">
                {inspectors.map((inspector) => (
                  <tr key={inspector.id} className="hover:bg-gray-50">
                    {editingId === inspector.id ? (
                      <>
                        <td className="px-6 py-3">
                          <input
                            className="w-full h-10 rounded-lg border border-border px-3 text-sm focus:ring-2 focus:ring-primary focus:outline-none"
                            value={editForm.email}
                            onChange={(e) => setEditForm({ ...editForm, email: e.target.value })}
                          />
                        </td>
                        <td className="px-6 py-3">
                          <input
                            className="w-full h-10 rounded-lg border border-border px-3 text-sm focus:ring-2 focus:ring-primary focus:outline-none"
                            value={editForm.firstName}
                            onChange={(e) => setEditForm({ ...editForm, firstName: e.target.value })}
                          />
                        </td>
                        <td className="px-6 py-3">
                          <input
                            className="w-full h-10 rounded-lg border border-border px-3 text-sm focus:ring-2 focus:ring-primary focus:outline-none"
                            value={editForm.lastName}
                            onChange={(e) => setEditForm({ ...editForm, lastName: e.target.value })}
                          />
                        </td>
                        <td className="px-6 py-3 text-right">
                          <div className="flex justify-end gap-2">
                            <Button
                              size="sm"
                              onClick={() =>
                                updateMutation.mutate({ id: inspector.id, ...editForm })
                              }
                              disabled={updateMutation.isPending}
                            >
                              Save
                            </Button>
                            <Button variant="ghost" size="sm" onClick={() => setEditingId(null)}>
                              Cancel
                            </Button>
                          </div>
                        </td>
                      </>
                    ) : (
                      <>
                        <td className="px-6 py-4 text-sm text-dark">{inspector.email}</td>
                        <td className="px-6 py-4 text-sm text-dark">{inspector.firstName}</td>
                        <td className="px-6 py-4 text-sm text-dark">{inspector.lastName}</td>
                        <td className="px-6 py-4 text-right">
                          <div className="flex justify-end gap-2">
                            <Button variant="ghost" size="sm" onClick={() => startEdit(inspector)}>
                              <Pencil className="h-4 w-4" />
                            </Button>
                            <Button
                              variant="ghost"
                              size="sm"
                              className="text-red-500 hover:bg-red-50"
                              onClick={() => {
                                if (confirm("Delete this inspector?"))
                                  deleteMutation.mutate(inspector.id);
                              }}
                            >
                              <Trash2 className="h-4 w-4" />
                            </Button>
                          </div>
                        </td>
                      </>
                    )}
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
