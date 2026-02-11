import { cn } from "@/lib/utils";

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: "primary" | "secondary" | "outline" | "ghost";
  size?: "sm" | "md" | "lg";
  children: React.ReactNode;
  className?: string;
}

const variantClasses = {
  primary: "bg-[#ff4655] text-white hover:bg-[#e63946] shadow-sm hover:shadow-md",
  secondary: "bg-[#1a1a1a] text-white hover:bg-[#1a1a1a]/90",
  outline: "border-2 border-current bg-transparent hover:bg-black/5",
  ghost: "bg-transparent hover:bg-black/5",
};

const sizeClasses = {
  sm: "h-10 px-5 text-sm",
  md: "h-12 px-8 text-base",
  lg: "h-14 px-10 text-lg",
};

export function Button({
  variant = "primary",
  size = "md",
  children,
  className,
  ...props
}: ButtonProps) {
  return (
    <button
      className={cn(
        "inline-flex items-center justify-center rounded-full font-semibold transition-all duration-150 ease-out",
        "hover:scale-[1.02] focus:outline-none focus:ring-2 focus:ring-[#ff4655] focus:ring-offset-2",
        variantClasses[variant],
        sizeClasses[size],
        className
      )}
      {...props}
    >
      {children}
    </button>
  );
}
