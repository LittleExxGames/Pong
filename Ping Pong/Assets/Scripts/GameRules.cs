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
    private bool gameInput = false;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;

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
        GameMaster.gameRules = this;
        GameStart();
    }
    public void GameStart()
    {
        for (int i = 1; i <= ballCount; i++)
        {
            ball = ballManager.SpawnBall();
        }
        PlayerController.CanControl(true);
        AIController.CanMove(true);
    }
    public void GameEnd()
    {
        ballManager.BallDrop();
        GameMaster.gameAudio.GetComponent<AudioSetter>().doAL = true;
        PlayerController.CanControl(false);
        AIController.CanMove(false);
        StartCoroutine(MenuDelay(loseScreen));
    }
    public void GameWin()
    {
        PlayerController.CanControl(false);
        AIController.CanMove(false);
        StartCoroutine(MenuDelay(winScreen));
    }
    IEnumerator MenuDelay(GameObject screen)
    {
        yield return new WaitForSeconds(1);
        screen.SetActive(true);
    }
}
