"use client";

import { useParams, useRouter } from "next/navigation";
import Image from "next/image";
import Link from "next/link";
import { useQuery, useMutation } from "@tanstack/react-query";
import { fetchVehicleDetails } from "@/lib/api/vehicles";
import { createBooking } from "@/lib/api/bookings";
import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { Button } from "@/components/ui/Button";
import { formatPrice, formatDate } from "@/lib/utils";
import { CarDetailSkeleton } from "@/components/cars/CarDetailSkeleton";
import { ReviewsSection } from "@/components/reviews/ReviewsSection";
import { useAuth } from "@/contexts/AuthContext";
import { useState, useMemo } from "react";
import { toast } from "sonner";
import { ArrowLeft, Car, Calendar, Gauge, MapPin, Tag, ShoppingCart, Star, Phone, Mail, BadgeCheck } from "lucide-react";

export default function CarDetailPage() {
  const params = useParams();
  const router = useRouter();
  const { isAuthenticated } = useAuth();
  const id = params.id as string;

  const [showRentForm, setShowRentForm] = useState(false);
  const [showBuyForm, setShowBuyForm] = useState(false);
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");

  const { data, isLoading } = useQuery({
    queryKey: ["vehicle-details", id],
    queryFn: () => fetchVehicleDetails(id),
    enabled: !!id,
  });

  const vehicle = data?.vehicle ?? null;
  const seller = data?.seller ?? null;

  const bookingMutation = useMutation({
    mutationFn: createBooking,
    onSuccess: () => {
      toast.success("Booking request submitted successfully!");
      setShowRentForm(false);
      setShowBuyForm(false);
      setStartDate("");
      setEndDate("");
      router.push("/bookings");
    },
    onError: (e: Error) => toast.error(e.message),
  });

  const label = [vehicle?.brand, vehicle?.model].filter(Boolean).join(" ") || "Car";
  const imageUrl =
    vehicle?.imageUrl ||
    `https://placehold.co/800x500/1a1a1a/fff?text=${encodeURIComponent(label)}`;

  const hasSalePrice = (vehicle?.price ?? 0) > 0;
  const hasRentalPrice = (vehicle?.rentalPrice ?? 0) > 0;

  const rentalTotal = useMemo(() => {
    if (!startDate || !endDate || !vehicle?.rentalPrice) return 0;
    const start = new Date(startDate);
    const end = new Date(endDate);
    const days = Math.max(1, Math.ceil((end.getTime() - start.getTime()) / (1000 * 60 * 60 * 24)));
    return days * vehicle.rentalPrice;
  }, [startDate, endDate, vehicle?.rentalPrice]);

  const today = new Date().toISOString().split("T")[0];

  if (!id) {
    router.replace("/cars");
    return null;
  }

  if (isLoading) {
    return (
      <div className="min-h-screen">
        <Header />
        <main className="pt-24 pb-16">
          <CarDetailSkeleton />
        </main>
        <Footer />
      </div>
    );
  }

  if (!vehicle) {
    return (
      <div className="min-h-screen">
        <Header />
        <main className="pt-24 pb-16 text-center">
          <p className="text-muted">Vehicle not found.</p>
        </main>
        <Footer />
      </div>
    );
  }

  const handleRentSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!startDate || !endDate) {
      toast.error("Please select both start and end dates");
      return;
    }
    if (new Date(endDate) <= new Date(startDate)) {
      toast.error("End date must be after start date");
      return;
    }
    bookingMutation.mutate({
      vehicleId: vehicle.id,
      bookingType: "Rent",
      startDate,
      endDate,
    });
  };

  const handleBuySubmit = () => {
    bookingMutation.mutate({
      vehicleId: vehicle.id,
      bookingType: "Buy",
    });
  };

  return (
    <div className="min-h-screen">
      <Header />

      <main className="pt-24 pb-16 px-6">
        <div className="mx-auto max-w-7xl">
          <Link
            href="/cars"
            className="inline-flex items-center gap-2 text-muted hover:text-dark mb-6 transition-colors"
          >
            <ArrowLeft className="h-4 w-4" /> Back to Listings
          </Link>

          <div className="grid lg:grid-cols-[1.2fr_1fr] gap-12">
            {/* Vehicle Image */}
            <div>
              <div className="relative aspect-[16/10] rounded-xl overflow-hidden bg-gray-100">
                <Image
                  src={imageUrl}
                  alt={`${vehicle.brand} ${vehicle.model ?? ""}`}
                  fill
                  className="object-cover"
                  sizes="(max-width: 1024px) 100vw, 60vw"
                  priority
                />
              </div>

              {/* Status Badge */}
              <div className="mt-4 flex gap-3">
                {vehicle.status && (
                  <span
                    className={`inline-flex items-center px-3 py-1 rounded-full text-sm font-medium ${
                      vehicle.status === "accepted"
                        ? "bg-green-50 text-green-700"
                        : vehicle.status === "pending"
                        ? "bg-amber-50 text-amber-700"
                        : "bg-gray-100 text-gray-700"
                    }`}
                  >
                    {vehicle.status}
                  </span>
                )}
              </div>
            </div>

            {/* Vehicle Details */}
            <div>
              <h1 className="font-heading text-4xl font-bold text-dark mb-4">
                {vehicle.brand} {vehicle.model ?? ""}
              </h1>

              {/* Prices */}
              <div className="flex gap-4 mb-6">
                {hasSalePrice && (
                  <div className="rounded-lg bg-green-50 px-4 py-2">
                    <p className="text-xs text-green-600 font-medium">Sale Price</p>
                    <p className="text-2xl font-bold text-green-700">{formatPrice(vehicle.price!)}</p>
                  </div>
                )}
                {hasRentalPrice && (
                  <div className="rounded-lg bg-blue-50 px-4 py-2">
                    <p className="text-xs text-blue-600 font-medium">Rental Price</p>
                    <p className="text-2xl font-bold text-blue-700">{formatPrice(vehicle.rentalPrice!)}/day</p>
                  </div>
                )}
              </div>

              {vehicle.description && (
                <p className="text-muted leading-relaxed mb-8">{vehicle.description}</p>
              )}

              {/* Specifications */}
              <div className="mb-8">
                <h3 className="text-sm font-semibold uppercase tracking-wider text-muted mb-4">
                  Specifications
                </h3>
                <div className="grid grid-cols-2 gap-4">
                  <div className="flex items-center gap-3">
                    <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                      <Car className="h-5 w-5" />
                    </div>
                    <div>
                      <p className="text-sm text-muted">Brand</p>
                      <p className="font-medium">{vehicle.brand}</p>
                    </div>
                  </div>
                  <div className="flex items-center gap-3">
                    <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                      <Calendar className="h-5 w-5" />
                    </div>
                    <div>
                      <p className="text-sm text-muted">Year</p>
                      <p className="font-medium">{vehicle.year}</p>
                    </div>
                  </div>
                  {vehicle.mileage != null && (
                    <div className="flex items-center gap-3">
                      <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                        <Gauge className="h-5 w-5" />
                      </div>
                      <div>
                        <p className="text-sm text-muted">Mileage</p>
                        <p className="font-medium">{vehicle.mileage.toLocaleString()} km</p>
                      </div>
                    </div>
                  )}
                  {vehicle.location && (
                    <div className="flex items-center gap-3">
                      <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                        <MapPin className="h-5 w-5" />
                      </div>
                      <div>
                        <p className="text-sm text-muted">Location</p>
                        <p className="font-medium">{vehicle.location}</p>
                      </div>
                    </div>
                  )}
                  {vehicle.vin && (
                    <div className="flex items-center gap-3 col-span-2">
                      <div className="w-10 h-10 rounded-lg bg-primary/10 flex items-center justify-center text-primary">
                        <Tag className="h-5 w-5" />
                      </div>
                      <div>
                        <p className="text-sm text-muted">VIN</p>
                        <p className="font-medium font-mono text-sm">{vehicle.vin}</p>
                      </div>
                    </div>
                  )}
                </div>
              </div>

              {/* Seller Info */}
              {seller && (
                <div className="mb-8 rounded-xl border border-border bg-gray-50 p-5">
                  <h3 className="text-sm font-semibold uppercase tracking-wider text-muted mb-4">
                    Seller Information
                  </h3>
                  <div className="flex items-start gap-4">
                    <div className="w-14 h-14 rounded-full bg-primary/20 flex items-center justify-center text-primary font-bold text-lg shrink-0">
                      {(seller.firstName?.[0] ?? seller.email?.[0] ?? "S").toUpperCase()}
                    </div>
                    <div className="flex-1 space-y-2">
                      <div className="flex items-center gap-2">
                        <p className="font-heading font-semibold text-dark text-lg">
                          {[seller.firstName, seller.lastName].filter(Boolean).join(" ") || "Seller"}
                        </p>
                        {seller.isVerifiedSeller && (
                          <span className="inline-flex items-center gap-1 px-2 py-0.5 rounded-full bg-blue-50 text-blue-700 text-xs font-medium">
                            <BadgeCheck className="h-3 w-3" /> Verified
                          </span>
                        )}
                      </div>
                      {seller.rating > 0 && (
                        <div className="flex items-center gap-2">
                          <div className="flex">
                            {[1, 2, 3, 4, 5].map((i) => (
                              <Star
                                key={i}
                                className={`h-4 w-4 ${
                                  i <= Math.round(seller.rating)
                                    ? "fill-amber-400 text-amber-400"
                                    : "text-gray-300"
                                }`}
                              />
                            ))}
                          </div>
                          <span className="text-sm text-muted">
                            {seller.rating.toFixed(1)} ({seller.reviewCount} reviews)
                          </span>
                        </div>
                      )}
                      <div className="flex flex-wrap gap-4 text-sm text-muted">
                        {seller.email && (
                          <span className="flex items-center gap-1.5">
                            <Mail className="h-4 w-4" /> {seller.email}
                          </span>
                        )}
                        {seller.phoneNumber && (
                          <span className="flex items-center gap-1.5">
                            <Phone className="h-4 w-4" /> {seller.phoneNumber}
                          </span>
                        )}
                      </div>
                    </div>
                  </div>
                </div>
              )}

              {/* Booking Actions */}
              {isAuthenticated ? (
                <div className="space-y-4">
                  <div className="flex gap-3">
                    {hasRentalPrice && (
                      <Button
                        size="lg"
                        className="flex-1 bg-blue-600 hover:bg-blue-700"
                        onClick={() => {
                          setShowRentForm(!showRentForm);
                          setShowBuyForm(false);
                        }}
                      >
                        <Calendar className="h-5 w-5 mr-2" />
                        Rent this Vehicle
                      </Button>
                    )}
                    {hasSalePrice && (
                      <Button
                        size="lg"
                        className="flex-1"
                        onClick={() => {
                          setShowBuyForm(!showBuyForm);
                          setShowRentForm(false);
                        }}
                      >
                        <ShoppingCart className="h-5 w-5 mr-2" />
                        Buy this Vehicle
                      </Button>
                    )}
                  </div>

                  {!hasSalePrice && !hasRentalPrice && (
                    <div className="rounded-lg bg-amber-50 border border-amber-200 p-4 text-amber-800 text-sm">
                      This vehicle is not currently available for sale or rent.
                    </div>
                  )}

                  {/* Rent Form */}
                  {showRentForm && hasRentalPrice && (
                    <form
                      onSubmit={handleRentSubmit}
                      className="rounded-xl border border-blue-200 bg-blue-50/50 p-6 space-y-4"
                    >
                      <h4 className="font-heading font-semibold text-dark">Rent this Vehicle</h4>
                      <div className="grid grid-cols-2 gap-4">
                        <div>
                          <label className="block text-sm font-medium text-dark mb-1">Start Date</label>
                          <input
                            type="date"
                            value={startDate}
                            min={today}
                            onChange={(e) => setStartDate(e.target.value)}
                            className="w-full h-11 rounded-lg border border-border px-3 text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                            required
                          />
                        </div>
                        <div>
                          <label className="block text-sm font-medium text-dark mb-1">End Date</label>
                          <input
                            type="date"
                            value={endDate}
                            min={startDate || today}
                            onChange={(e) => setEndDate(e.target.value)}
                            className="w-full h-11 rounded-lg border border-border px-3 text-sm focus:ring-2 focus:ring-blue-500 focus:outline-none"
                            required
                          />
                        </div>
                      </div>
                      <div className="text-sm text-muted">
                        Daily rate: <span className="font-semibold text-dark">{formatPrice(vehicle.rentalPrice!)}</span>
                        {rentalTotal > 0 && (
                          <span className="ml-4">
                            Estimated total: <span className="font-semibold text-blue-700">{formatPrice(rentalTotal)}</span>
                          </span>
                        )}
                      </div>
                      <div className="flex gap-3">
                        <Button
                          type="submit"
                          className="bg-blue-600 hover:bg-blue-700"
                          disabled={bookingMutation.isPending}
                        >
                          {bookingMutation.isPending ? "Submitting..." : "Submit Rent Request"}
                        </Button>
                        <Button
                          type="button"
                          variant="ghost"
                          onClick={() => setShowRentForm(false)}
                        >
                          Cancel
                        </Button>
                      </div>
                    </form>
                  )}

                  {/* Buy Form */}
                  {showBuyForm && hasSalePrice && (
                    <div className="rounded-xl border border-green-200 bg-green-50/50 p-6 space-y-4">
                      <h4 className="font-heading font-semibold text-dark">Buy this Vehicle</h4>
                      <p className="text-2xl font-bold text-green-700">{formatPrice(vehicle.price!)}</p>
                      <p className="text-sm text-muted">
                        Your purchase request will be sent to the seller who will contact you to finalize the transaction.
                      </p>
                      <div className="flex gap-3">
                        <Button
                          className="bg-green-600 hover:bg-green-700"
                          onClick={handleBuySubmit}
                          disabled={bookingMutation.isPending}
                        >
                          {bookingMutation.isPending ? "Submitting..." : "Submit Purchase Request"}
                        </Button>
                        <Button variant="ghost" onClick={() => setShowBuyForm(false)}>
                          Cancel
                        </Button>
                      </div>
                    </div>
                  )}
                </div>
              ) : (
                <div className="rounded-lg bg-gray-50 border border-border p-4 text-sm text-muted">
                  Please{" "}
                  <Link href="/auth/login" className="text-primary font-medium hover:underline">
                    log in
                  </Link>{" "}
                  to rent or purchase this vehicle.
                </div>
              )}
            </div>
          </div>

          {/* Reviews Section */}
          <div className="mt-20">
            <ReviewsSection targetId={vehicle.id} />
          </div>
        </div>
      </main>

      <Footer />
    </div>
  );
}
