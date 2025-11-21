# Company Common C# Packages

두 개의 공통 NuGet 패키지를 제공합니다 (`net8.0`).
- `Company.Common.Utils`: 문자열/날짜/수치 유틸
- `Company.Common.Http`: HttpClient JSON 헬퍼

## 구조
- `Directory.Build.props`: 공통 타겟/버전/패키징 설정 (0.1.0)
- `nuget.config`: 내부 피드 예시(`company-internal` → http://localhost:5555/v3/index.json)
- `Company.Common.sln`: 두 패키지용 솔루션
- `src/Company.Common.Utils/*`
- `src/Company.Common.Http/*`

## 빌드 & 패키징
```bash
cd csharp-packages
# 솔루션 빌드
dotnet build Company.Common.sln -c Release

# 패키지 빌드 (각 패키지)
dotnet pack src/Company.Common.Utils/Company.Common.Utils.csproj -c Release
# => src/Company.Common.Utils/bin/Release/Company.Common.Utils.0.1.0.nupkg

dotnet pack src/Company.Common.Http/Company.Common.Http.csproj -c Release
# => src/Company.Common.Http/bin/Release/Company.Common.Http.0.1.0.nupkg
```

## 사내 NuGet에 배포 예시
- `nuget.config`에 사내 피드 추가 (`company-internal`) 후:
```bash
dotnet nuget push src/Company.Common.Utils/bin/Release/Company.Common.Utils.0.1.0.nupkg --source company-internal
dotnet nuget push src/Company.Common.Http/bin/Release/Company.Common.Http.0.1.0.nupkg --source company-internal
```

## 사용 예시 (소비 프로젝트)
`NuGet.config`에 사내 피드 추가 후:
```bash
<ItemGroup>
  <PackageReference Include="Company.Common.Utils" Version="0.1.0" />
  <PackageReference Include="Company.Common.Http" Version="0.1.0" />
</ItemGroup>
```

```csharp
using Company.Common.Utils;
using Company.Common.Http;
using Microsoft.Extensions.DependencyInjection;

"hello".Capitalize();
var iso = DateTime.UtcNow.ToIsoDate();
var clamped = MathHelpers.Clamp(12, 0, 10);

var services = new ServiceCollection();
services.AddJsonClient<JsonClient>("https://api.example.com");
var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<JsonClient>();
var data = await client.GetAsync<object>("/v1/ping");
```
