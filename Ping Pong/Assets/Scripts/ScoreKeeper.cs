using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int pointsPlayer;
    private int pointsAI;
    public int pointsNeeded;
    [SerializeField]
    private TextMeshProUGUI aiText;
    [SerializeField]
    private TextMeshProUGUI playerText;
    [SerializeField]
    private TextMeshProUGUI neededPointsText;

    private void Update()
    {
        playerText.text = "Player: " + pointsPlayer;
        aiText.text = "AI: " + pointsAI;
        neededPointsText.text = "Points nedded: " + pointsNeeded;
    }
    public void UpdatePlayerScore()
    {
        pointsPlayer++;
    }
    public void UpdateAIScore()
    {
        pointsAI++;
    }
}
