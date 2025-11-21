namespace Company.Common.Utils;

public static class StringExtensions
{
    public static string Capitalize(this string value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        if (value.Length == 1) return value.ToUpperInvariant();
        return char.ToUpperInvariant(value[0]) + value[1..];
    }

    public static string Truncate(this string value, int maxLength, string ellipsis = "...")
    {
        if (string.IsNullOrEmpty(value) || maxLength <= 0) return string.Empty;
        if (value.Length <= maxLength) return value;
        if (ellipsis.Length >= maxLength) return value[..maxLength];
        var sliceLength = maxLength - ellipsis.Length;
        return value[..sliceLength] + ellipsis;
    }
}
