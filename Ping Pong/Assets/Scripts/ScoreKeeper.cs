using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int pointsPlayer;
    public int pointsNeeded;
    private int pointsAI;
    [SerializeField]
    private TextMeshProUGUI playerText;
    [SerializeField]
    private TextMeshProUGUI neededPointsText;
    [SerializeField]
    private TextMeshProUGUI aiText;

    private void Update()
    {
        playerText.text = string.Format("{0, -10}" + pointsPlayer, "Player: ");
        neededPointsText.text = string.Format("{0, -10}" + pointsNeeded,"First To: ");
        aiText.text = string.Format("{0, -10}" + pointsAI, "AI: ");
    }
    public void UpdatePlayerScore()
    {
        pointsPlayer++;
        ScoreCheck();
    }
    public void UpdateAIScore()
    {
        pointsAI++;
        ScoreCheck();
    }
    private void ScoreCheck()
    {
        if(pointsPlayer == pointsNeeded)
        {

        }
        else if(pointsAI == pointsNeeded)
        {
            GameMaster.gm.gameRules.GameEnd();
        }
    }
}
