using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public Vector2 gameStart;
    public Vector2 gameRamp;
    private GameObject ball;
    private int ballCount;
    private BallManager ballManager;
    public bool gameEnd = false;

    private void Update()
    {
        if (gameEnd)
        {
            GameEnd();
            gameEnd = false;
        }
    }
    private void Awake()
    {
        ballCount = LevelSettings.levelSettings.GetBallCount();
        ballManager = GetComponent<BallManager>();
        GameStart();
    }
    public void GameStart()
    {
        for (int i = 1; i <= ballCount; i++)
        {
            ball = ballManager.SpawnBall();
        }
       
    }
    public void GameEnd()
    {
        ballManager.BallDrop();
        GameMaster.gm.gameAudio.GetComponent<AudioSetter>().doAL = true;
    }
    public void GameWin()
    {

    }
}
