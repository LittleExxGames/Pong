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
    private int chID;
    [SerializeField]
    private GameObject[] challenges;

    private void Awake()
    {
        ballCount = LevelSettings.GetBallCount();
        ballManager = GetComponent<BallManager>();
        ScoreKeeper.SetPointsNeeded(LevelSettings.GetPointsNeeded());
        GameMaster.gameRules = this;
        chID = LevelSettings.GetID();
        Time.timeScale = 1;
        
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
        StartCoroutine(MenuDelay(ArenaMenu.MENU.LOSE));
    }
    public void GameWin()
    {
        ballManager.BallDrop();
        PlayerController.CanControl(false);
        AIController.CanMove(false);
        StartCoroutine(MenuDelay(ArenaMenu.MENU.WIN));
        CompleteChallenge();
        SaveData.Save();
    }
    IEnumerator MenuDelay(ArenaMenu.MENU swap)
    {
        yield return new WaitForSeconds(1);
        ArenaMenu.arenaMenu.SetMenu(swap);
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
            case 3:
                SaveData.chThreeCompleted = true;
                break;
        }
    }

    private void SetChallenge()
    {
        switch (chID)
        {
            case 0:
                Ball.SetBrightness(0);
                challenges[0].SetActive(true);
                AIController.SetSpeed(6.5f);
                break;
            case 1:
                Ball.SetBrightness(0);
                challenges[0].SetActive(true);
                ballManager.SetSpawnPositions(new Vector2[] { new Vector2(0, 3), Vector2.zero, new Vector2(0, -3) });
                AIController.SetSpeed(7f);
                break;
            case 2:
                Ball.SetBrightness(0);
                challenges[1].SetActive(true);
                ballManager.SetSpawnPositions(new Vector2[] { new Vector2(-4, 0), new Vector2(4, 0) });
                ballManager.SetCap(new Vector2(2.5f, 9f));
                AIController.SetSpeed(5);
                break;
            case 3:
                challenges[2].SetActive(true);
                Ball.SetBrightness(3.85f);
                AIController.SetSpeed(5);
                ballManager.SetCap(new Vector2(3.5f, 14f));
                break;
        }
    }
}
