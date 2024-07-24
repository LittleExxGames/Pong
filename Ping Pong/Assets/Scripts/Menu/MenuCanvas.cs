using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public static MenuCanvas menuCanvas;
    public enum MENU
    { MAIN, SETTINGS, CHALLENGES }

    private MENU menu = MENU.MAIN;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject challengesMenu;

    private void Awake()
    {
        menuCanvas = this;
        Time.timeScale = 1f;
    }
    public void SetMenu(MENU swap)
    {
        DeactivateMenu();
        menu = swap;
        ActivateMenu();
    }
    public void SetToSOptions()
    {
        SetMenu(MENU.SETTINGS);
    }
    public void SetToMenu()
    {
        SetMenu(MENU.MAIN);
    }
    public void SetToChallenges()
    {
        SetMenu(MENU.CHALLENGES);
    }
    private void ActivateMenu()
    {
        switch (menu)
        {
            case MENU.MAIN:
                mainMenu.SetActive(true);
                break;

            case MENU.SETTINGS:
                settingsMenu.SetActive(true);
                break;

            case MENU.CHALLENGES:
                challengesMenu.SetActive(true);
                break;
        }
    }
    private void DeactivateMenu()
    {
        switch (menu)
        {
            case MENU.MAIN:
                mainMenu.SetActive(false);
                break;

            case MENU.SETTINGS:
                settingsMenu.SetActive(false);
                break;

            case MENU.CHALLENGES:
                challengesMenu.SetActive(false);
                break;
        }
    }
}