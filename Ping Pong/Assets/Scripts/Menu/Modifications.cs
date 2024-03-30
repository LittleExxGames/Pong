using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifications : MonoBehaviour
{
    private Settings settings;
    private LevelSettings levelSettings;

    [SerializeField]
    private int ballCount = 1;
    [SerializeField]
    private string challenge = "Default";
    [SerializeField]
    private bool doubleAI = false;
    public void SetModification()
    {
        settings = Settings.settings;
        levelSettings = LevelSettings.levelSettings;
        settings.SetBallCount(ballCount);
        levelSettings.SetBallCount(ballCount);
        levelSettings.SetDoubleAI(doubleAI);
        MenuCanvas.menuCanvas.SetMenu(MenuCanvas.MENU.MAIN);
    }
}
