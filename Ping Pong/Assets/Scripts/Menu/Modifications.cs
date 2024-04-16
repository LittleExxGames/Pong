using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Modifications : MonoBehaviour
{
    private Settings settings;

    [SerializeField]
    private int ballCount = 1;
    [SerializeField]
    private string challenge = "Default";
    [SerializeField]
    private bool doubleAI = false;
    [SerializeField]
    private int chID = 0;
    private static GameObject check;

    public Image selected;

    [SerializeField]
    private Sprite[] images = new Sprite[2];
    public void SetModification()
    {
        settings = Settings.settings;
        settings.SetBallCount(ballCount);
        LevelSettings.SetBallCount(ballCount);
        LevelSettings.SetDoubleAI(doubleAI);
        LevelSettings.SetID(chID);
        MenuCanvas.menuCanvas.SetMenu(MenuCanvas.MENU.MAIN);
        check = gameObject;
    }

    private void Update()
    {
        switch (chID)
        {
            case 1:
                selected.sprite = (SaveData.chOneCompleted) ? images[1] : images[0];
                break;
            case 2:
                selected.sprite = (SaveData.chTwoCompleted) ? images[1] : images[0];
                break;
        }
        SetOpacity();

    }
    private void SetOpacity()
    {
        if (check == gameObject)
        {
            selected.color = new Color32(255, 255, 255, 255);
            Debug.Log(gameObject.name);
        }
        else
        {
            selected.color = new Color32(255, 255, 255, 150);
        }
    }
}
