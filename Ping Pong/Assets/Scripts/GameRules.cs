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
    private int chID;
    [SerializeField]
    private GameObject[] challenges;

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
        ballCount = LevelSettings.GetBallCount();
        ballManager = GetComponent<BallManager>();
        GameMaster.gameRules = this;
        chID = LevelSettings.GetID();
        SetChallenge();
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
        ballManager.BallDrop();
        PlayerController.CanControl(false);
        AIController.CanMove(false);
        StartCoroutine(MenuDelay(winScreen));
        CompleteChallenge();
        LevelSettings.ResetLevelSettings();
    }
    IEnumerator MenuDelay(GameObject screen)
    {
        yield return new WaitForSeconds(1);
        screen.SetActive(true);
    }

    private void CompleteChallenge()
    {
        switch (chID)
        {
            case 0:
                break;
                case 1:
                SaveData.chOneCompleted = true;
                break;
                case 2:
                SaveData.chTwoCompleted = true;
                break;
        }
    }

    private void SetChallenge()
    {
        switch (chID)
        {
            case 0:
                challenges[0].SetActive(true);
                break;
            case 1:
                challenges[0].SetActive(true);
                ballManager.SetSpawnPositions(new Vector2[] { new Vector2(0, 3), Vector2.zero, new Vector2(0, -3) });
                break;
            case 2:
                challenges[1].SetActive(true);
                ballManager.SetSpawnPositions(new Vector2[] { new Vector2(-4, 0), new Vector2(4, 0) });
                break;
        }
    }
}
