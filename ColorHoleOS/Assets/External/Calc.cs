﻿/// <summary>
/// Main static calculations to use.
/// </summary>
public class Calc
{
    // Maps a value from one range to another.
    public static float map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
