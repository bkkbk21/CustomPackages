# Company.Common.Utils
공용 유틸리티 확장/함수 모음 (`net8.0`).

## 주요 기능
- 문자열: `Capitalize`, `Truncate`
- 날짜: `ToIsoDate`, `ToDateOnlyString`, `SafeParseIso`
- 수치: `Clamp` (int/double)

## 사용 예시
```csharp
using Company.Common.Utils;

"hello".Capitalize(); // "Hello"
"long text".Truncate(5); // "lo..."
DateTime.UtcNow.ToIsoDate();
MathHelpers.Clamp(12, 0, 10); // 10
```

## 빌드/배포
```bash
# 패키지 빌드
cd csharp-packages
dotnet pack src/Company.Common.Utils/Company.Common.Utils.csproj -c Release
# 결과: src/Company.Common.Utils/bin/Release/Company.Common.Utils.0.1.0.nupkg

# 내부 NuGet 피드로 배포 예시
# 사전: nuget.config에 사내 피드 추가, 필요 시 인증 설정
dotnet nuget push src/Company.Common.Utils/bin/Release/Company.Common.Utils.0.1.0.nupkg \
  --source company-internal
```
