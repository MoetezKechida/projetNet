import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { Shield, Zap, Users, Car, Bot, Eye } from "lucide-react";

const values = [
  {
    icon: Shield,
    title: "Trust & Safety",
    description: "Every transaction is secured. Verified sellers and professional inspections give you peace of mind.",
  },
  {
    icon: Zap,
    title: "Speed",
    description: "Browse, book, and drive — all in minutes. Real-time notifications keep you in the loop instantly.",
  },
  {
    icon: Users,
    title: "Community",
    description: "A growing network of car enthusiasts, buyers, and sellers building a transparent marketplace.",
  },
  {
    icon: Eye,
    title: "Transparency",
    description: "Honest listings, real photos, and verified reviews so you always know what you're getting.",
  },
  {
    icon: Bot,
    title: "AI-Powered",
    description: "Our intelligent assistant helps you find the perfect vehicle based on your preferences and budget.",
  },
  {
    icon: Car,
    title: "Quality Fleet",
    description: "From compact city cars to luxury SUVs — a curated selection of vehicles for every need.",
  },
];

export default function AboutPage() {
  return (
    <div className="min-h-screen">
      <Header />
      <main className="pt-24 pb-16 px-6">
        <div className="mx-auto max-w-5xl">
          {/* Hero */}
          <div className="text-center mb-20">
            <h1 className="font-heading text-5xl font-bold text-dark mb-6">
              About DRIVOXE
            </h1>
            <p className="text-lg text-muted max-w-2xl mx-auto leading-relaxed">
              DRIVOXE is a modern vehicle marketplace that connects car owners with
              buyers and renters. We believe finding your next car should be simple,
              transparent, and enjoyable.
            </p>
          </div>

          {/* Mission */}
          <div className="grid md:grid-cols-2 gap-12 items-center mb-24">
            <div>
              <h2 className="font-heading text-3xl font-bold text-dark mb-4">Our Mission</h2>
              <p className="text-muted leading-relaxed mb-4">
                We're building the most trusted car marketplace — one where buyers
                can shop with confidence and sellers reach the right audience effortlessly.
              </p>
              <p className="text-muted leading-relaxed">
                Through professional inspections, real-time booking, and AI-powered
                recommendations, we're making the car buying and renting experience
                better for everyone.
              </p>
            </div>
            <div className="relative">
              <img
                src="https://images.unsplash.com/photo-1449965408869-ebd13bc0c322?w=600&q=80"
                alt="Cars on road"
                className="rounded-2xl shadow-lg object-cover w-full aspect-[4/3]"
              />
            </div>
          </div>

          {/* Values */}
          <div className="mb-24">
            <h2 className="font-heading text-3xl font-bold text-dark text-center mb-12">
              What We Stand For
            </h2>
            <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-8">
              {values.map((v) => (
                <div
                  key={v.title}
                  className="rounded-xl border border-border p-6 hover:shadow-lg transition-shadow duration-200"
                >
                  <div className="flex h-12 w-12 items-center justify-center rounded-xl bg-[#ff4655]/10 text-[#ff4655] mb-4">
                    <v.icon className="h-6 w-6" />
                  </div>
                  <h3 className="font-heading font-bold text-dark text-lg mb-2">{v.title}</h3>
                  <p className="text-sm text-muted leading-relaxed">{v.description}</p>
                </div>
              ))}
            </div>
          </div>

          {/* Stats */}
          <div className="rounded-2xl bg-[#1a1a1a] text-white p-12 text-center">
            <h2 className="font-heading text-3xl font-bold mb-8">DRIVOXE in Numbers</h2>
            <div className="grid grid-cols-2 md:grid-cols-4 gap-8">
              {[
                { label: "Vehicles Listed", value: "50+" },
                { label: "Happy Users", value: "12.5K+" },
                { label: "Cities Covered", value: "10+" },
                { label: "Inspections Done", value: "500+" },
              ].map((stat) => (
                <div key={stat.label}>
                  <p className="font-heading text-3xl font-bold text-[#ff4655]">{stat.value}</p>
                  <p className="text-sm text-gray-400 mt-1">{stat.label}</p>
                </div>
              ))}
            </div>
          </div>
        </div>
      </main>
      <Footer />
    </div>
  );
}
