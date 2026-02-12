"use client";

import { useQuery, useMutation } from "@tanstack/react-query";
import { fetchBrandsWithModels, createSellerVehicle } from "@/lib/api/seller-vehicles";
import { ProtectedRoute } from "@/components/auth/ProtectedRoute";
import PageLayout from "@/components/layout/PageLayout";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState, useMemo } from "react";
import { toast } from "sonner";
import { ArrowLeft } from "lucide-react";

export default function CreateVehiclePage() {
  const router = useRouter();

  const { data: brandsWithModels = {} } = useQuery({
    queryKey: ["brands-models"],
    queryFn: fetchBrandsWithModels,
  });

  const brands = useMemo(() => Object.keys(brandsWithModels), [brandsWithModels]);

  const [form, setForm] = useState({
    vin: "",
    brand: "",
    model: "",
    year: new Date().getFullYear(),
    price: "",
    rentalPrice: "",
    mileage: "",
    location: "",
    description: "",
  });
  const [imageFile, setImageFile] = useState<File | null>(null);
  const [preview, setPreview] = useState<string>("");

  const models = useMemo(
    () => (form.brand ? brandsWithModels[form.brand] || [] : []),
    [form.brand, brandsWithModels]
  );

  const createMutation = useMutation({
    mutationFn: createSellerVehicle,
    onSuccess: () => {
      toast.success("Vehicle created successfully!");
      router.push("/seller/vehicles");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      const validTypes = ["image/jpeg", "image/png", "image/gif", "image/webp"];
      if (!validTypes.includes(file.type)) {
        toast.error("Please select a valid image file (jpg, png, gif, webp)");
        return;
      }
      setImageFile(file);
      setPreview(URL.createObjectURL(file));
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("vin", form.vin);
    formData.append("brand", form.brand);
    formData.append("model", form.model);
    formData.append("year", String(form.year));
    if (form.price) formData.append("price", form.price);
    if (form.rentalPrice) formData.append("rentalPrice", form.rentalPrice);
    if (form.mileage) formData.append("mileage", form.mileage);
    if (form.location) formData.append("location", form.location);
    if (form.description) formData.append("description", form.description);
    if (imageFile) formData.append("imageFile", imageFile);

    createMutation.mutate(formData);
  };

  return (
    <ProtectedRoute requiredRole="Seller">
      <PageLayout>
        <div className="max-w-2xl mx-auto">
          <Link
            href="/seller/vehicles"
            className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
          >
            <ArrowLeft className="h-4 w-4" /> Back to My Vehicles
          </Link>

          <h1 className="font-heading text-3xl font-bold text-dark mb-8">
            Add New Vehicle
          </h1>

          <form onSubmit={handleSubmit} className="space-y-6">
            <Input
              label="VIN"
              required
              value={form.vin}
              onChange={(e) => setForm({ ...form, vin: e.target.value })}
              placeholder="Vehicle Identification Number"
            />

            <div className="grid grid-cols-2 gap-4">
              <div className="flex flex-col gap-1.5">
                <label className="text-sm font-medium text-foreground">Brand</label>
                <select
                  value={form.brand}
                  onChange={(e) => setForm({ ...form, brand: e.target.value, model: "" })}
                  className="h-12 rounded-lg border border-border bg-white px-4 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                  required
                >
                  <option value="">Select brand</option>
                  {brands.map((b) => (
                    <option key={b} value={b}>{b}</option>
                  ))}
                </select>
              </div>

              <div className="flex flex-col gap-1.5">
                <label className="text-sm font-medium text-foreground">Model</label>
                <select
                  value={form.model}
                  onChange={(e) => setForm({ ...form, model: e.target.value })}
                  className="h-12 rounded-lg border border-border bg-white px-4 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                  required
                  disabled={!form.brand}
                >
                  <option value="">Select model</option>
                  {models.map((m) => (
                    <option key={m} value={m}>{m}</option>
                  ))}
                </select>
              </div>
            </div>

            <Input
              label="Year"
              type="number"
              required
              value={form.year}
              onChange={(e) => setForm({ ...form, year: Number(e.target.value) })}
            />

            <div className="grid grid-cols-2 gap-4">
              <Input
                label="Sale Price (€)"
                type="number"
                value={form.price}
                onChange={(e) => setForm({ ...form, price: e.target.value })}
                placeholder="0"
              />
              <Input
                label="Rental Price (€/day)"
                type="number"
                value={form.rentalPrice}
                onChange={(e) => setForm({ ...form, rentalPrice: e.target.value })}
                placeholder="0"
              />
            </div>

            <div className="grid grid-cols-2 gap-4">
              <Input
                label="Mileage (km)"
                type="number"
                value={form.mileage}
                onChange={(e) => setForm({ ...form, mileage: e.target.value })}
                placeholder="0"
              />
              <Input
                label="Location"
                value={form.location}
                onChange={(e) => setForm({ ...form, location: e.target.value })}
                placeholder="City, Country"
              />
            </div>

            <div className="flex flex-col gap-1.5">
              <label className="text-sm font-medium text-foreground">Vehicle Image</label>
              <input
                type="file"
                accept="image/jpeg,image/png,image/gif,image/webp"
                onChange={handleImageChange}
                className="text-sm file:mr-4 file:py-2 file:px-4 file:rounded-full file:border-0 file:text-sm file:font-semibold file:bg-primary/10 file:text-primary hover:file:bg-primary/20"
              />
              {preview && (
                <img src={preview} alt="Preview" className="mt-2 h-40 w-auto rounded-lg object-cover" />
              )}
            </div>

            <div className="flex flex-col gap-1.5">
              <label className="text-sm font-medium text-foreground">Description</label>
              <textarea
                value={form.description}
                onChange={(e) => setForm({ ...form, description: e.target.value })}
                className="h-24 rounded-lg border border-border bg-white px-4 py-3 text-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                placeholder="Describe your vehicle..."
              />
            </div>

            <div className="flex gap-3">
              <Button type="submit" disabled={createMutation.isPending}>
                {createMutation.isPending ? "Creating..." : "Create Vehicle"}
              </Button>
              <Link href="/seller/vehicles">
                <Button variant="ghost" type="button">Cancel</Button>
              </Link>
            </div>
          </form>
        </div>
      </PageLayout>
    </ProtectedRoute>
  );
}
