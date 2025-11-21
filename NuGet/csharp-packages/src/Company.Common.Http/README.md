# Company.Common.Http
HttpClient 기반 JSON 클라이언트 도우미 (`net8.0`).

## 주요 기능
- `JsonClient`: `GetAsync<T>`, `PostAsync<TRequest, TResponse>` 등 JSON 편의 메서드
- 의존성 주입 등록 헬퍼: `AddJsonClient`

## 사용 예시
```csharp
using Company.Common.Http;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddJsonClient<JsonClient>("https://api.example.com");
var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<JsonClient>();

var result = await client.GetAsync<MyDto>("/v1/items");
```

## 빌드/배포
```bash
cd csharp-packages
dotnet pack src/Company.Common.Http/Company.Common.Http.csproj -c Release
# 결과: src/Company.Common.Http/bin/Release/Company.Common.Http.0.1.0.nupkg

dotnet nuget push src/Company.Common.Http/bin/Release/Company.Common.Http.0.1.0.nupkg \
  --source company-internal
```
