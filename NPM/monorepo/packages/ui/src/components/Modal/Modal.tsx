import React, { ReactNode } from "react";

export type ModalProps = {
  isOpen: boolean;
  onClose: () => void;
  children: ReactNode;
};

const overlayStyle: React.CSSProperties = {
  position: "fixed",
  top: 0,
  left: 0,
  width: "100%",
  height: "100%",
  backgroundColor: "rgba(0, 0, 0, 0.5)",
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  zIndex: 1000
};

const modalStyle: React.CSSProperties = {
  background: "#fff",
  padding: "24px",
  borderRadius: 8,
  minWidth: 320,
  boxShadow: "0 10px 30px rgba(0, 0, 0, 0.12)"
};

export const Modal: React.FC<ModalProps> = ({ isOpen, onClose, children }) => {
  if (!isOpen) return null;

  return (
    <div style={overlayStyle} onClick={onClose}>
      <div
        style={modalStyle}
        onClick={(event) => {
          event.stopPropagation();
        }}
      >
        {children}
      </div>
    </div>
  );
};
