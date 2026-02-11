import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";

export default function AboutPage() {
  return (
    <div className="min-h-screen">
      <Header />
      <main className="pt-24 pb-16 px-6">
        <div className="mx-auto max-w-3xl">
          <h1 className="font-heading text-4xl font-bold text-dark mb-8">
            About DRIVOXE
          </h1>
          <p className="text-muted leading-relaxed">
            Your journey, your car, your way. We connect car owners with renters
            and buyers.
          </p>
        </div>
      </main>
      <Footer />
    </div>
  );
}
