# @company/utils

Lightweight TypeScript utilities shared across @company projects.

## Installation

```bash
npm install @company/utils
```

## Usage

```ts
import { formatDate, clamp, capitalize } from "@company/utils";

formatDate(new Date());
clamp(10, 0, 5); // 5
capitalize("hello"); // "Hello"
```
