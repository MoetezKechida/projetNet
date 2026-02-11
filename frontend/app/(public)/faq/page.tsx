import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";

export default function FAQPage() {
  return (
    <div className="min-h-screen">
      <Header />
      <main className="pt-24 pb-16 px-6">
        <div className="mx-auto max-w-3xl">
          <h1 className="font-heading text-4xl font-bold text-dark mb-8">
            Frequently Asked Questions
          </h1>
          <p className="text-muted">FAQ content coming soon.</p>
        </div>
      </main>
      <Footer />
    </div>
  );
}
