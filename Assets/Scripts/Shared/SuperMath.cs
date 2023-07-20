using UnityEngine;

public static class SuperMath
{
    public static float LinearLerp(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    public static float QuadraticLerp(float a, float b, float c, float t) 
    {
        float x = LinearLerp(a, b, t);
        float y = LinearLerp(b, c, t);

        return LinearLerp(x, y, t);
    }

    public static float CubicLerp(float a, float b, float c, float d, float t)
    {
        float ab = LinearLerp(a, b, t);

        float bc = LinearLerp(b, c, t);

        float cd = LinearLerp(c, d, t);

        float abc = LinearLerp(ab, bc, t);
        float bcd = LinearLerp(bc, cd, t);

        return LinearLerp(abc, bcd, t);
    }

    public static float QuarticBezier(float a, float b, float c, float d, float e, float t)
    {
        float ab = LinearLerp(a, b, t);
        float bc = LinearLerp(b, c, t);
        float cd = LinearLerp(c, d, t);
        float de = LinearLerp(d, e, t);

        float abc = LinearLerp(ab, bc, t);
        float bcd = LinearLerp(bc, cd, t);
        float cde = LinearLerp(cd, de, t);

        float abcd = LinearLerp(abc, bcd, t);
        float bcde = LinearLerp(bcd, cde, t);

        return LinearLerp(abcd, bcde, t);
    }


    public static float Remap(float value, float originalMin, float originalMax, float targetMin, float targetMax)
    {
        // Calculate the percentage of the original value within the original range
        float percentage = Mathf.InverseLerp(originalMin, originalMax, value);

        // Map the percentage to the target range
        float remappedValue = Mathf.Lerp(targetMin, targetMax, percentage);

        return remappedValue;
    }
}
