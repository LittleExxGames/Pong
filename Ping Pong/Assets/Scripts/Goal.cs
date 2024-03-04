using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerGoal;
    public ScoreKeeper scoreKeeper;
    public GameRules gameRules;
    public BallManager ballManager;
    public void Scored(GameObject go)
    {
        if (isPlayerGoal)
        {
            scoreKeeper.UpdateAIScore();
        }
        else
        {
            scoreKeeper.UpdatePlayerScore();
        }
        ballManager.Center(go);
        //gameRules.GameStart();
    }

}
