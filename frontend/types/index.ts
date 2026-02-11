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
