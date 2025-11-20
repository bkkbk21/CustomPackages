# GitLab 온프레미스 배포 가이드

GitLab npm 패키지 레지스트리 주소를 사용하도록 `.npmrc`와 `publishConfig`를 GitLab 인스턴스 기준으로 설정했어요. 도메인과 프로젝트/그룹 경로는 실제 환경에 맞게 바꾸세요.

## 준비
- GitLab Personal Access Token: `api` 혹은 최소 `read_api`, `write_api`, `read_registry`, `write_registry` 권한.
- 패키지 이름 스코프: `@company/*` (이미 설정됨).
- 레지스트리 URL 예시(인스턴스 전역): `https://gitlab.example.com/api/v4/packages/npm/`
- 토큰 환경 변수: `export NPM_TOKEN=<your_token>`

## 코드/설정 변경 사항
- 루트 및 각 패키지 `.npmrc`: `@company` 스코프가 GitLab npm 레지스트리로 지정, `always-auth=true`, 토큰은 `NPM_TOKEN` 환경 변수 사용.
- 각 패키지 `publishConfig.registry`: GitLab npm 레지스트리로 지정.

## 퍼블리시 절차 (로컬)
1) `npm install` (루트)로 의존성 설치
2) `npm run build` (루트)로 dist 생성
3) 패키지별 퍼블리시 (`packages/ui` 예시):
   ```bash
   cd packages/ui
   npm version patch   # 필요 시 버전 올리기
   npm run publish:registry
   ```

## 다른 프로젝트에서 설치
프로젝트의 `.npmrc`에 동일 레지스트리/토큰 설정을 추가:
```ini
@company:registry=https://gitlab.example.com/api/v4/packages/npm/
//gitlab.example.com/api/v4/packages/npm/:_authToken=${NPM_TOKEN}
```
그 후 `npm install @company/ui` 등으로 설치.

## GitLab 주소 맞추기
- 인스턴스 전역 레지스트리: `https://<gitlab-host>/api/v4/packages/npm/`
- 프로젝트별 레지스트리: `https://<gitlab-host>/api/v4/projects/<project-id>/packages/npm/`
- 그룹별 레지스트리: `https://<gitlab-host>/api/v4/groups/<group-id>/-/packages/npm/`
위 URL을 `.npmrc`와 `publishConfig.registry`에 동일하게 맞춰주세요.
