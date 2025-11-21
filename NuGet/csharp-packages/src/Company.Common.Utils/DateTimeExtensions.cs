namespace Company.Common.Utils;

public static class DateTimeExtensions
{
    public static string ToIsoDate(this DateTime value)
    {
        return value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    }

    public static string ToDateOnlyString(this DateTime value)
    {
        return value.ToString("yyyy-MM-dd");
    }

    public static DateTime? SafeParseIso(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;
        if (DateTime.TryParse(input, out var dt)) return dt;
        return null;
    }
}
