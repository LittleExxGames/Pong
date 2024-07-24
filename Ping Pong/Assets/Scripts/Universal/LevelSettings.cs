using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSettings : MonoBehaviour
{
    public static LevelSettings levelSettings;
    private static int ballCount = 1;
    private static bool doubleAI;
    private static int pointsNeeded = 5;
    private static int chID;

    public static void ResetLevelSettings()
    {
        ballCount = 1;
        doubleAI = false;
        pointsNeeded = 5;
        chID = 0;
    }

    private void Awake()
    {
        if (levelSettings == null)
        {
            levelSettings = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is one of the scenes to reset values
        if (scene.name == "MainMenu")
        {
            ResetLevelSettings();
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

    public static void SetPointsNeeded(int newPointsNeeded)
    {
        pointsNeeded = newPointsNeeded;
    }

    public static int GetPointsNeeded()
    {
        return pointsNeeded;
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