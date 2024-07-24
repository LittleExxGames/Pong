using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveData
{
    public static bool chOneCompleted;
    public static bool chTwoCompleted;
    public static bool chThreeCompleted;

    public static float volume = 1;

    public static void Save()
    {
        PlayerPrefs.SetInt("ChallengeOne", chOneCompleted ? 1 : 0);
        PlayerPrefs.SetInt("ChallengeTwo", chTwoCompleted ? 1 : 0);
        PlayerPrefs.SetInt("ChallengeThree", chThreeCompleted ? 1 : 0);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public static void Load()
    {
        chOneCompleted = PlayerPrefs.GetInt("ChallengeOne", 0) == 1;
        chTwoCompleted = PlayerPrefs.GetInt("ChallengeTwo", 0) == 1;
        chThreeCompleted = PlayerPrefs.GetInt("ChallengeThree", 0) == 1;
        volume = PlayerPrefs.GetFloat("Volume", 1);
    }

}
