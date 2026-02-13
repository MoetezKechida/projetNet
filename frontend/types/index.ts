export interface Vehicle {
  id: string;
  vin: string;
  brand: string;
  model?: string;
  year: number;
  ownerId: string;
  imageUrl?: string;
  price?: number;
  rentalPrice?: number;
  description?: string;
  mileage?: number;
  location?: string;
  status?: string;
}

export interface Offer {
  id: string;
  type: string;
  price: number;
  status: string;
  vehicleId: string;
  sellerId: string;
}

export interface Review {
  id: string;
  reviewerId: string;
  targetId: string;
  comment: string;
  rating: number;
  createdAt: string;
}

export interface UserInfo {
  id: string;
  email: string;
  fullName: string;
  role?: string;
  isEmailVerified: boolean;
  isPhoneVerified: boolean;
}

export interface AuthResponse {
  token: string;
  refreshToken: string;
  expiresAt: string;
  user: UserInfo;
}

export type CarType = "sedan" | "suv" | "sports" | "coupe" | "convertible";

export interface CarFilters {
  brand?: string;
  minYear?: number;
  maxYear?: number;
  minPrice?: number;
  maxPrice?: number;
  type?: string;
}

// Booking types
export interface Booking {
  id: string;
  vehicleId: string;
  buyerId: string;
  bookingType: string;
  startDate: string;
  endDate: string;
  totalAmount: number;
  status: string;
}

export interface BookingDetails {
  booking: Booking;
  vehicle: {
    id: string;
    brand: string;
    model?: string;
    year: number;
    imageUrl?: string;
    price?: number;
    rentalPrice?: number;
  } | null;
  user: {
    id: string;
    firstName?: string;
    lastName?: string;
    email?: string;
    phoneNumber?: string;
  } | null;
}

// Inspection types
export interface Inspection {
  id: string;
  vehicleId: string;
  inspectorId?: string;
  reason?: string;
}

// VehicleSale types
export interface VehicleSale {
  id: string;
  offerId: string;
  buyerId: string;
  amount: number;
  status: string;
}

// Dashboard stats
export interface DashboardStats {
  sales: VehicleSale[];
  bookings: Booking[];
}

// Inspector types
export interface InspectorUser {
  id: string;
  email: string;
  firstName?: string;
  lastName?: string;
  phoneNumber?: string;
}

// Brands with models
export type BrandsWithModels = Record<string, string[]>;

// Real-time SignalR notification from the backend
export interface BookingNotification {
  id: string;
  vehicleId: string;
  vehicleModel: string;
  buyerName: string;
  bookingType: string;
  startDate: string;
  endDate: string;
  totalAmount: number;
  createdAt: string;
}
