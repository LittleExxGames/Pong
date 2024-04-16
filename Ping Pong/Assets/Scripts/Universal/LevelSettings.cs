using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public static LevelSettings levelSettings;
    private static int ballCount = 1;
    private static float paddleSize;
    private static float paddleSpeed;
    private static bool doubleAI;
    private static int chID;

    public static void ResetLevelSettings()
    {
        ballCount = 1;
        paddleSize = 1;
        paddleSpeed = 1;
        doubleAI = false;
        chID = 0;
    }

    private void Awake()
    {
        if (levelSettings == null)
        {
            levelSettings = this;
        }
    }
    public static void SetBallCount(int count)
    {
        ballCount = count;
    }
    public static int GetBallCount()
    {
        return ballCount;
    }
    public static void SetDoubleAI(bool a)
    {
        doubleAI = a;
    }
    public static bool GetDoubleAI()
    {
        return doubleAI;
    }
    public static void SetID(int id)
    {
        chID = id;
    }
    public static int GetID()
    {
        return chID;
    }
}
