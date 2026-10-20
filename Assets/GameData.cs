using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static float healthScore = 100;  // Backing field for HealthScore
    public static int livesCount = 3;     // Backing field for LivesCount
    public static float SurvivalScore = 100;
    public static float time=600.0f;
    public static float HealthScore
    {
        get => healthScore;
        set => healthScore = Mathf.Clamp(value, 0, 100);
    }

    public static int LivesCount
    {
        get => livesCount;
        set => livesCount = Mathf.Clamp(value, 0, 3);
    }
    public static float survivalScore
    {
        get => SurvivalScore;
        set => SurvivalScore = Mathf.Clamp(value, 0, 100);
    }
    public static float Timer
    {
        get => time;
        set => time = Mathf.Clamp(value, 0, 600);
    }


}
