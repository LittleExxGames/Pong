using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMenu : MonoBehaviour
{
    public static ArenaMenu arenaMenu;

    public enum MENU
    { NONE, SETTINGS, SOPTIONS, WIN, LOSE }

    private MENU menu = MENU.NONE;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject sOptions;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;

    private void Awake()
    {
        arenaMenu = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu != MENU.WIN && menu != MENU.LOSE)
        {
            Debug.Log(menu);
            if (menu == MENU.SETTINGS || menu == MENU.SOPTIONS)
            {
                SetMenu(MENU.NONE);
                Time.timeScale = 1f;
            }
            else
            {
                SetMenu(MENU.SETTINGS);
                Time.timeScale = 0;
            }
        }
    }

    public void SetMenu(MENU swap)
    {
        DeactivateMenu();
        menu = swap;
        ActivateMenu();
    }

    public void SetToSOptions()
    {
        SetMenu(MENU.SOPTIONS);
    }
    public void SetToSettings()
    {
        SetMenu(MENU.SETTINGS);
    }

    private void ActivateMenu()
    {
        switch (menu)
        {
            case MENU.SETTINGS:
                settings.SetActive(true);
                break;

            case MENU.SOPTIONS:
                sOptions.SetActive(true);
                break;

            case MENU.WIN:
                win.SetActive(true);
                break;

            case MENU.LOSE:
                lose.SetActive(true);
                break;
        }
    }

    private void DeactivateMenu()
    {
        switch (menu)
        {
            case MENU.SETTINGS:
                settings.SetActive(false);
                break;

            case MENU.SOPTIONS:
                sOptions.SetActive(false);
                break;

            case MENU.WIN:
                win.SetActive(false);
                break;

            case MENU.LOSE:
                lose.SetActive(false);
                break;
        }
    }
}