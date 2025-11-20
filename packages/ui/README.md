# @company/ui

React UI component library for @company projects. Ships simple defaults with Storybook examples.

## Installation

```bash
npm install @company/ui
```

## Usage

```tsx
import { Button, Modal } from "@company/ui";

export function Example() {
  return (
    <div>
      <Button variant="primary">Click me</Button>
      <Modal isOpen onClose={() => {}}>
        Modal content
      </Modal>
    </div>
  );
}
```
