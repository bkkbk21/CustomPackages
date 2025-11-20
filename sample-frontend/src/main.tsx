import React from "react";
import { createRoot } from "react-dom/client";
import { Button, Modal } from "@company/ui";
import { useToggle, useBoolean, useDebounce } from "@company/hooks";
import { formatDate, clamp, capitalize } from "@company/utils";

function App() {
  const [modalOpen, toggleModal] = useToggle(false);
  const { value, setTrue, setFalse, toggle } = useBoolean(false);
  const debounced = useDebounce(value, 300);

  const today = formatDate(new Date());
  const clamped = clamp(12, 0, 10);
  const title = capitalize("hello team");

  return (
    <div style={{ fontFamily: "Inter, system-ui, sans-serif", padding: 24 }}>
      <h1 style={{ marginTop: 0 }}>{title}</h1>
      <p>Today: {today}</p>
      <p>Clamp(12, 0, 10): {clamped}</p>

      <div style={{ display: "flex", gap: 8, margin: "16px 0" }}>
        <Button onClick={toggle}>useBoolean toggle ({String(value)})</Button>
        <Button variant="secondary" onClick={setTrue}>
          setTrue
        </Button>
        <Button variant="secondary" onClick={setFalse}>
          setFalse
        </Button>
      </div>
      <p>Debounced value: {String(debounced)}</p>

      <Button onClick={toggleModal}>Open Modal</Button>
      <Modal isOpen={modalOpen} onClose={toggleModal}>
        <h3 style={{ marginTop: 0 }}>Hello!</h3>
        <p>This modal uses @company/ui.</p>
        <Button variant="secondary" onClick={toggleModal}>
          Close
        </Button>
      </Modal>
    </div>
  );
}

const root = createRoot(document.getElementById("root")!);
root.render(<App />);
