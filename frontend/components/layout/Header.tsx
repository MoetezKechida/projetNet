"use client";

import Link from "next/link";
import { useState, useEffect, useMemo } from "react";
import { Search, Menu, X, User, ChevronDown } from "lucide-react";
import { Button } from "@/components/ui/Button";
import { useAuth } from "@/contexts/AuthContext";
import { cn } from "@/lib/utils";

const publicLinks = [
  { href: "/", label: "Home" },
  { href: "/cars", label: "Cars" },
  { href: "/faq", label: "FAQ" },
  { href: "/about", label: "About" },
];

export function Header() {
  const { user, isAuthenticated, logout } = useAuth();
  const [scrolled, setScrolled] = useState(false);
  const [mobileOpen, setMobileOpen] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);

  useEffect(() => {
    const onScroll = () => setScrolled(window.scrollY > 100);
    window.addEventListener("scroll", onScroll);
    return () => window.removeEventListener("scroll", onScroll);
  }, []);

  // Close dropdown when clicking outside
  useEffect(() => {
    if (!dropdownOpen) return;
    const handler = () => setDropdownOpen(false);
    document.addEventListener("click", handler);
    return () => document.removeEventListener("click", handler);
  }, [dropdownOpen]);

  const roleLinks = useMemo(() => {
    if (!user?.role) return [];
    switch (user.role) {
      case "Admin":
        return [
          { href: "/dashboard", label: "Dashboard" },
          { href: "/dashboard/inspectors", label: "Inspectors" },
        ];
      case "Seller":
        return [
          { href: "/seller/vehicles", label: "My Vehicles" },
          { href: "/seller/offers", label: "My Offers" },
          { href: "/bookings/requests", label: "Booking Requests" },
        ];
      case "Buyer":
        return [
          { href: "/bookings", label: "My Bookings" },
          { href: "/reviews", label: "My Reviews" },
        ];
      case "Inspector":
        return [
          { href: "/inspector", label: "Pending Vehicles" },
          { href: "/inspector/history", label: "My Inspections" },
        ];
      default:
        return [];
    }
  }, [user?.role]);

  const allLinks = [...publicLinks, ...roleLinks];

  return (
    <header
      className={cn(
        "fixed top-0 left-0 right-0 z-50 h-20 transition-all duration-300",
        scrolled
          ? "bg-white/90 backdrop-blur-md shadow-sm"
          : "bg-transparent"
      )}
    >
      <nav className="mx-auto flex h-full max-w-7xl items-center justify-between px-6 lg:px-8">
        <Link href="/" className="flex items-center gap-2">
          <span className="font-heading text-2xl font-bold text-dark">
            DRIVOXE
          </span>
        </Link>

        <div className="hidden md:flex md:items-center md:gap-8">
          {publicLinks.map((link) => (
            <Link
              key={link.href}
              href={link.href}
              className="text-base font-semibold text-dark hover:underline hover:underline-offset-4 hover:decoration-2 hover:decoration-primary"
            >
              {link.label}
            </Link>
          ))}
          {roleLinks.length > 0 && (
            <div className="relative">
              <button
                onClick={(e) => {
                  e.stopPropagation();
                  setDropdownOpen(!dropdownOpen);
                }}
                className="flex items-center gap-1 text-base font-semibold text-dark hover:text-primary transition-colors"
              >
                {user?.role === "Admin" ? "Admin" : user?.role === "Inspector" ? "Inspector" : "My Account"}
                <ChevronDown className="h-4 w-4" />
              </button>
              {dropdownOpen && (
                <div className="absolute right-0 top-full mt-2 w-48 rounded-xl bg-white border border-border shadow-lg py-2 z-50">
                  {roleLinks.map((link) => (
                    <Link
                      key={link.href}
                      href={link.href}
                      className="block px-4 py-2.5 text-sm font-medium text-dark hover:bg-gray-50 hover:text-primary transition-colors"
                      onClick={() => setDropdownOpen(false)}
                    >
                      {link.label}
                    </Link>
                  ))}
                </div>
              )}
            </div>
          )}
        </div>

        <div className="flex items-center gap-4">
          <Link
            href="/cars"
            className="text-dark hover:text-primary transition-colors p-2"
            aria-label="Search"
          >
            <Search className="h-6 w-6" />
          </Link>

          {isAuthenticated ? (
            <div className="hidden md:flex items-center gap-3">
              <div className="flex items-center gap-2">
                <div className="w-8 h-8 rounded-full bg-primary/20 flex items-center justify-center">
                  <User className="h-4 w-4 text-primary" />
                </div>
                <div className="text-sm">
                  <p className="font-medium text-dark">{user?.fullName}</p>
                  <p className="text-xs text-muted capitalize">{user?.role}</p>
                </div>
              </div>
              <Button variant="outline" size="sm" onClick={() => logout()}>
                Logout
              </Button>
            </div>
          ) : (
            <div className="hidden md:flex items-center gap-3">
              <Link href="/auth/login">
                <Button variant="ghost" size="sm">
                  Log in
                </Button>
              </Link>
              <Link href="/auth/register">
                <Button size="sm" className="min-w-[120px]">
                  Sign Up
                </Button>
              </Link>
            </div>
          )}

          <button
            className="md:hidden p-2 text-dark"
            onClick={() => setMobileOpen(!mobileOpen)}
            aria-label="Toggle menu"
          >
            {mobileOpen ? <X className="h-6 w-6" /> : <Menu className="h-6 w-6" />}
          </button>
        </div>
      </nav>

      {mobileOpen && (
        <div className="md:hidden absolute top-full left-0 right-0 bg-white shadow-lg border-t border-border py-4 px-6">
          <div className="flex flex-col gap-3">
            {allLinks.map((link) => (
              <Link
                key={link.href}
                href={link.href}
                onClick={() => setMobileOpen(false)}
                className="font-semibold text-dark py-1"
              >
                {link.label}
              </Link>
            ))}
            <hr className="border-border" />
            {isAuthenticated ? (
              <>
                <div className="text-sm text-muted py-1">
                  {user?.fullName} ({user?.role})
                </div>
                <button
                  onClick={() => {
                    logout();
                    setMobileOpen(false);
                  }}
                  className="text-left font-semibold text-dark py-1"
                >
                  Logout
                </button>
              </>
            ) : (
              <>
                <Link href="/auth/login" onClick={() => setMobileOpen(false)} className="font-semibold text-dark py-1">
                  Log in
                </Link>
                <Link href="/auth/register" onClick={() => setMobileOpen(false)}>
                  <Button size="sm">Sign Up</Button>
                </Link>
              </>
            )}
          </div>
        </div>
      )}
    </header>
  );
}
