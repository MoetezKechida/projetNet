import Link from "next/link";
import { Button } from "@/components/ui/Button";

export default function NotFound() {
  return (
    <div className="min-h-screen flex items-center justify-center px-6">
      <div className="text-center max-w-md">
        <h1 className="font-heading text-8xl font-bold text-[#ff4655] mb-4">404</h1>
        <h2 className="font-heading text-2xl font-bold text-dark mb-3">
          Page Not Found
        </h2>
        <p className="text-muted mb-8 leading-relaxed">
          The page you're looking for doesn't exist or has been moved. Let's get you back on the road.
        </p>
        <div className="flex flex-wrap justify-center gap-4">
          <Link href="/">
            <Button size="md">Back to Home</Button>
          </Link>
          <Link href="/cars">
            <Button variant="outline" size="md">Browse Cars</Button>
          </Link>
        </div>
      </div>
    </div>
  );
}
