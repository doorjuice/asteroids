using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    private static int score = 0;

    public static void AddScore(int inc = 1)
    {
        score += inc;
        Debug.Log($"Score: {score} (+{inc})"); // Equivalent a Debug.Log("Score: " + score + "(+" + inc + ")");
    }
}
