# Corp Frontend Sample

예제 React 앱에서 퍼블리시된 `@company/ui`, `@company/hooks`, `@company/utils`를 사용합니다.

## 사전 준비
- `.npmrc`에 사내 NPM 레지스트리와 토큰 설정
- `NPM_TOKEN` 환경 변수에 접근 토큰 설정

## 설치 및 실행
```bash
cd sample-frontend
npm install
npm run dev    # http://localhost:5173
```

## 주요 사용처
- UI: `@company/ui`의 `Button`, `Modal`
- Hooks: `useToggle`, `useBoolean`, `useDebounce`
- Utils: `formatDate`, `clamp`, `capitalize`
