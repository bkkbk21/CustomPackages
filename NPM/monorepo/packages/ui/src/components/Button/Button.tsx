import React from "react";

export type ButtonProps = React.ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: "primary" | "secondary";
};

const baseStyle: React.CSSProperties = {
  padding: "10px 16px",
  borderRadius: 6,
  border: "1px solid transparent",
  cursor: "pointer",
  fontWeight: 600,
  transition: "background 0.2s ease, color 0.2s ease, border-color 0.2s ease"
};

const variantStyles: Record<NonNullable<ButtonProps["variant"]>, React.CSSProperties> = {
  primary: {
    background: "#2563eb",
    color: "#fff",
    borderColor: "#1d4ed8"
  },
  secondary: {
    background: "#e5e7eb",
    color: "#111827",
    borderColor: "#d1d5db"
  }
};

export const Button: React.FC<ButtonProps> = ({
  variant = "primary",
  style,
  children,
  ...props
}) => {
  const variantStyle = variantStyles[variant];
  return (
    <button {...props} style={{ ...baseStyle, ...variantStyle, ...style }}>
      {children}
    </button>
  );
};
