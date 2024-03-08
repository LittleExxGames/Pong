using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    public Vector2 gameStart;
    public Vector2 gameRamp;
    private GameObject ball;
    private int ballCount = 2;
    private BallManager ballManager;
    private void Awake()
    {
        ballManager = GetComponent<BallManager>();
        GameStart();
    }
    public void NextLevel()
    {
        ball.transform.position = new Vector3(0, 0, 0);
        //ball.GetComponent<Rigidbody2D>().velocity = gameStart;
        ball.GetComponent<Ball>().SetVelocity(gameStart);
    }
    public void GameStart()
    {
        for (int i = 1; i <= ballCount; i++)
        {
            ball = ballManager.SpawnBall();
        }
       
    }
}
