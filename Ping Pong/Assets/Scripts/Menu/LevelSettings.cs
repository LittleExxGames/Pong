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

    private void Awake()
    {
        if (levelSettings == null)
        {
            levelSettings = this;
        }
    }
    public void SetBallCount(int count)
    {
        ballCount = count;
    }
    public int GetBallCount()
    {
        return ballCount;
    }
    public void SetDoubleAI(bool a)
    {
        doubleAI = a;
    }
    public bool GetDoubleAI()
    {
        return doubleAI;
    }
}
