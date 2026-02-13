"use client";

import { useState } from "react";
import { Header } from "@/components/layout/Header";
import { Footer } from "@/components/layout/Footer";
import { ChevronDown } from "lucide-react";
import { cn } from "@/lib/utils";

const faqs = [
  {
    category: "Buying & Renting",
    items: [
      {
        q: "How do I book a vehicle?",
        a: "Browse our fleet on the Cars page, click on a vehicle you like, and use the booking form to select your dates. You'll receive a confirmation once the seller accepts.",
      },
      {
        q: "What's the difference between buying and renting?",
        a: "Buying transfers full ownership of the vehicle to you. Renting gives you temporary access for a specified period at a daily rate.",
      },
      {
        q: "Can I cancel a booking?",
        a: "Bookings can be managed from your dashboard. Contact the seller directly for cancellation or modifications.",
      },
      {
        q: "How is the rental price calculated?",
        a: "The total rental cost is the daily rate multiplied by the number of days. The exact amount is shown before you confirm.",
      },
    ],
  },
  {
    category: "Selling",
    items: [
      {
        q: "How do I list a vehicle for sale or rent?",
        a: "Register as a seller, go to your Seller Dashboard, and click 'Add Vehicle'. Fill in the details including photos, price, and description.",
      },
      {
        q: "How do I manage booking requests?",
        a: "Incoming requests appear on your Booking Requests page in real-time. You can complete transactions directly from there.",
      },
      {
        q: "Can I set both a sale price and a rental price?",
        a: "Yes. When listing a vehicle you can set a purchase price, a daily rental rate, or both.",
      },
    ],
  },
  {
    category: "Inspections",
    items: [
      {
        q: "What is a vehicle inspection?",
        a: "An inspection is a professional check of a vehicle's condition. Buyers can request one, and a certified inspector will review the car.",
      },
      {
        q: "Who performs inspections?",
        a: "Our verified inspectors handle all inspection requests. They provide detailed reports on the vehicle's condition.",
      },
    ],
  },
  {
    category: "Account & Security",
    items: [
      {
        q: "How do I create an account?",
        a: "Click 'Sign Up' in the top navigation, fill in your details, and choose your role (buyer or seller).",
      },
      {
        q: "Is my data secure?",
        a: "Yes. We use encrypted connections and follow industry-standard security practices to protect your information.",
      },
      {
        q: "I forgot my password. What do I do?",
        a: "Use the 'Forgot Password' link on the login page. You'll receive an email with instructions to reset it.",
      },
    ],
  },
];

function AccordionItem({ question, answer }: { question: string; answer: string }) {
  const [open, setOpen] = useState(false);

  return (
    <div className="border-b border-border">
      <button
        onClick={() => setOpen(!open)}
        className="flex w-full items-center justify-between py-5 text-left"
      >
        <span className="font-semibold text-dark pr-4">{question}</span>
        <ChevronDown
          className={cn(
            "h-5 w-5 shrink-0 text-muted transition-transform duration-200",
            open && "rotate-180"
          )}
        />
      </button>
      <div
        className={cn(
          "overflow-hidden transition-all duration-200",
          open ? "max-h-40 pb-5" : "max-h-0"
        )}
      >
        <p className="text-muted leading-relaxed">{answer}</p>
      </div>
    </div>
  );
}

export default function FAQPage() {
  return (
    <div className="min-h-screen">
      <Header />
      <main className="pt-24 pb-16 px-6">
        <div className="mx-auto max-w-3xl">
          <h1 className="font-heading text-4xl font-bold text-dark mb-3">
            Frequently Asked Questions
          </h1>
          <p className="text-muted mb-12">
            Everything you need to know about using DRIVOXE.
          </p>

          {faqs.map((section) => (
            <div key={section.category} className="mb-10">
              <h2 className="font-heading text-xl font-bold text-dark mb-4">
                {section.category}
              </h2>
              <div className="rounded-xl border border-border bg-white px-6">
                {section.items.map((item) => (
                  <AccordionItem key={item.q} question={item.q} answer={item.a} />
                ))}
              </div>
            </div>
          ))}
        </div>
      </main>
      <Footer />
    </div>
  );
}
