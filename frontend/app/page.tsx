import Link from "next/link";
import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { Button } from "@/components/ui/Button";
import { CarGrid } from "@/components/cars/CarGrid";

const categories = [
  "Sedan",
  "Sports",
  "SUV",
  "Coupe",
  "Convertible",
];

export default function Home() {
  return (
    <div className="min-h-screen">
      <Header />

      <main>
        {/* Hero Section */}
        <section className="relative min-h-[90vh] flex items-center px-6 pt-24 pb-16 lg:pt-32">
          <div className="mx-auto max-w-7xl w-full grid lg:grid-cols-2 gap-12 items-center">
            <div className="space-y-8">
              <h1 className="font-heading text-5xl sm:text-6xl lg:text-7xl font-bold text-dark leading-[1.1] tracking-tight">
                Your Journey,
                <br />
                Your Car,
                <br />
                Your Way
              </h1>
              <p className="text-lg text-muted max-w-xl">
                Browse our impressive fleet of vehicles for rent and sale. Find
                the perfect car for every occasion.
              </p>
              <div className="flex flex-wrap gap-4">
                <Link href="/cars">
                  <Button size="lg" className="h-14 px-10">
                    Get Started
                  </Button>
                </Link>
              </div>

              {/* Stats Badge */}
              <div className="flex items-center gap-8 pt-4">
                <div className="rounded-2xl bg-white shadow-card px-6 py-4 border border-border">
                  <p className="font-heading text-xl font-bold text-dark">
                    50+ Car Types
                  </p>
                  <p className="text-sm text-muted">Available</p>
                </div>
                <div className="flex items-center gap-2">
                  <div className="flex -space-x-2">
                    {[1, 2, 3, 4].map((i) => (
                      <div
                        key={i}
                        className="w-10 h-10 rounded-full bg-primary/20 border-2 border-white"
                      />
                    ))}
                  </div>
                  <span className="text-sm font-medium text-muted">
                    12.5K+ People
                  </span>
                </div>
              </div>
            </div>

            {/* Hero Image */}
            <div className="relative hidden lg:block">
              <div className="relative aspect-square max-w-lg ml-auto">
                <img
                  src="https://images.unsplash.com/photo-1494976388531-d1058494cdd8?w=800&q=80"
                  alt="Luxury car"
                  className="object-cover rounded-2xl shadow-2xl transform -rotate-6"
                />
              </div>
            </div>
          </div>
        </section>

        {/* Category Pills */}
        <section className="py-12 px-6 border-y border-border">
          <div className="mx-auto max-w-7xl flex flex-wrap justify-center gap-4">
            {categories.map((cat) => (
              <Link
                key={cat}
                href={`/cars?type=${cat.toLowerCase()}`}
                className="px-6 py-3 rounded-full border-2 border-dark font-semibold text-dark hover:bg-dark hover:text-white transition-colors duration-200"
              >
                {cat}
              </Link>
            ))}
          </div>
        </section>

        {/* Fleet Section */}
        <section className="py-20 px-6">
          <div className="mx-auto max-w-7xl">
            <h2 className="font-heading text-4xl font-bold text-center text-dark mb-12">
              Our Impressive Fleet
            </h2>
            <CarGrid featuredFirst />
          </div>
        </section>
      </main>

      <Footer />
    </div>
  );
}
