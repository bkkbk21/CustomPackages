# @company/hooks

Reusable React hooks for @company projects.

## Installation

```bash
npm install @company/hooks
```

## Usage

```tsx
import { useToggle, useBoolean, useDebounce } from "@company/hooks";

function Example() {
  const [isOn, toggle] = useToggle();
  const { value, setTrue, setFalse } = useBoolean();
  const debounced = useDebounce(value, 300);

  return (
    <div>
      <button onClick={toggle}>{isOn ? "On" : "Off"}</button>
      <button onClick={setTrue}>True</button>
      <button onClick={setFalse}>False</button>
      <div>Debounced: {String(debounced)}</div>
    </div>
  );
}
```
