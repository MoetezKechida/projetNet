"use client";

import { useState } from "react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { Button } from "@/components/ui/Button";
import { Input } from "@/components/ui/Input";
import { register as apiRegister } from "@/lib/api/auth";
import { useAuth } from "@/contexts/AuthContext";
import { toast } from "sonner";

const schema = z
  .object({
    email: z.string().email("Invalid email"),
    password: z.string().min(6, "At least 6 characters"),
    confirmPassword: z.string(),
    firstName: z.string().min(1, "Required"),
    lastName: z.string().min(1, "Required"),
    phoneNumber: z.string().min(1, "Required"),
    userType: z.enum(["Buyer", "Seller"]),
  })
  .refine((d) => d.password === d.confirmPassword, {
    message: "Passwords must match",
    path: ["confirmPassword"],
  });

type FormData = z.infer<typeof schema>;

export default function RegisterPage() {
  const router = useRouter();
  const { setUser } = useAuth();
  const [isLoading, setIsLoading] = useState(false);

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
    defaultValues: { userType: "Buyer" },
  });

  const onSubmit = async (data: FormData) => {
    setIsLoading(true);
    try {
      const res = await apiRegister({
        email: data.email,
        password: data.password,
        confirmPassword: data.confirmPassword,
        firstName: data.firstName,
        lastName: data.lastName,
        phoneNumber: data.phoneNumber,
        userType: data.userType,
      });
      localStorage.setItem("token", res.token);
      localStorage.setItem("refreshToken", res.refreshToken);
      setUser(res.user);
      toast.success("Account created! Welcome.");
      router.push("/");
    } catch (e: unknown) {
      toast.error((e as Error).message || "Registration failed");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 px-4 py-12">
      <div className="w-full max-w-md">
        <Link
          href="/"
          className="font-heading text-2xl font-bold text-dark block mb-8"
        >
          DRIVOXE
        </Link>
        <div className="bg-white rounded-2xl shadow-card p-8">
          <h1 className="font-heading text-2xl font-bold text-dark mb-6">
            Create account
          </h1>
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
            <div className="grid grid-cols-2 gap-4">
              <Input
                label="First name"
                {...register("firstName")}
                error={errors.firstName?.message}
              />
              <Input
                label="Last name"
                {...register("lastName")}
                error={errors.lastName?.message}
              />
            </div>
            <Input
              label="Email"
              type="email"
              {...register("email")}
              error={errors.email?.message}
            />
            <Input
              label="Phone"
              type="tel"
              {...register("phoneNumber")}
              error={errors.phoneNumber?.message}
            />
            <Input
              label="Password"
              type="password"
              {...register("password")}
              error={errors.password?.message}
            />
            <Input
              label="Confirm password"
              type="password"
              {...register("confirmPassword")}
              error={errors.confirmPassword?.message}
            />
            <div>
              <label className="block text-sm font-medium text-dark mb-2">I want to</label>
              <div className="grid grid-cols-2 gap-3">
                <label
                  className={`flex items-center justify-center gap-2 rounded-xl border-2 p-3 cursor-pointer transition-all ${
                    watch("userType") === "Buyer"
                      ? "border-primary bg-primary/5 text-primary"
                      : "border-border hover:border-gray-300"
                  }`}
                >
                  <input
                    type="radio"
                    value="Buyer"
                    {...register("userType")}
                    className="sr-only"
                  />
                  <span className="text-lg">🛒</span>
                  <span className="font-medium">Buy / Rent</span>
                </label>
                <label
                  className={`flex items-center justify-center gap-2 rounded-xl border-2 p-3 cursor-pointer transition-all ${
                    watch("userType") === "Seller"
                      ? "border-primary bg-primary/5 text-primary"
                      : "border-border hover:border-gray-300"
                  }`}
                >
                  <input
                    type="radio"
                    value="Seller"
                    {...register("userType")}
                    className="sr-only"
                  />
                  <span className="text-lg">🚗</span>
                  <span className="font-medium">Sell Cars</span>
                </label>
              </div>
              {errors.userType && (
                <p className="mt-1 text-sm text-red-500">{errors.userType.message}</p>
              )}
            </div>
            <Button
              type="submit"
              className="w-full"
              disabled={isLoading}
            >
              {isLoading ? "Creating account..." : "Sign up"}
            </Button>
          </form>
          <p className="mt-6 text-center text-sm text-muted">
            Already have an account?{" "}
            <Link href="/auth/login" className="text-primary font-semibold hover:underline">
              Log in
            </Link>
          </p>
        </div>
      </div>
    </div>
  );
}
