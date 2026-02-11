import Link from "next/link";
import { Facebook, Instagram, Youtube } from "lucide-react";

const socialLinks = [
  { icon: Instagram, href: "#", label: "Instagram" },
  { icon: Facebook, href: "#", label: "Facebook" },
  { icon: Youtube, href: "#", label: "YouTube" },
];

export function Footer() {
  return (
    <footer className="bg-dark text-white py-16 px-6">
      <div className="mx-auto max-w-7xl">
        <div className="flex flex-col md:flex-row md:items-center md:justify-between gap-8">
          <div>
            <Link href="/" className="font-heading text-2xl font-bold">
              DRIVOXE
            </Link>
            <p className="mt-3 text-muted max-w-md">
              Your journey, your car, your way. Browse our fleet and find the
              perfect vehicle for rent or sale.
            </p>
          </div>

          <div className="flex items-center gap-6">
            {socialLinks.map(({ icon: Icon, href, label }) => (
              <a
                key={label}
                href={href}
                aria-label={label}
                className="text-white/70 hover:text-white transition-colors"
              >
                <Icon className="h-6 w-6" />
              </a>
            ))}
          </div>
        </div>

        <div className="mt-12 pt-8 border-t border-white/10 flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4">
          <p className="text-sm text-muted">
            © {new Date().getFullYear()} DRIVOXE. All rights reserved.
          </p>
          <div className="flex gap-6">
            <Link href="/privacy" className="text-sm text-muted hover:text-white">
              Privacy
            </Link>
            <Link href="/terms" className="text-sm text-muted hover:text-white">
              Terms
            </Link>
          </div>
        </div>
      </div>
    </footer>
  );
}
