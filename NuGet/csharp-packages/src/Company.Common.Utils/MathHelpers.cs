namespace Company.Common.Utils;

public static class MathHelpers
{
    public static double Clamp(double value, double min, double max)
    {
        if (min > max) throw new ArgumentException("min cannot be greater than max", nameof(min));
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static int Clamp(int value, int min, int max)
    {
        if (min > max) throw new ArgumentException("min cannot be greater than max", nameof(min));
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }
}
