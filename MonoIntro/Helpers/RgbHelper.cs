using System;
using Microsoft.Xna.Framework;

namespace Helpers.RGB;

public class RgbHelper
{
    public float _hue = 0f; // 0 to 360

    public Color HsvToRgb(float h, float s, float v)
    {
        float c = v * s;
        float x = c * (1 - Math.Abs(h / 60f % 2 - 1));
        float m = v - c;

        float r, g, b;
        if      (h < 60)  { r = c; g = x; b = 0; }
        else if (h < 120) { r = x; g = c; b = 0; }
        else if (h < 180) { r = 0; g = c; b = x; }
        else if (h < 240) { r = 0; g = x; b = c; }
        else if (h < 300) { r = x; g = 0; b = c; }
        else              { r = c; g = 0; b = x; }

        return new Color(r + m, g + m, b + m);
    }
}