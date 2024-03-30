using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChallenges : MonoBehaviour
{
    public void ChallengeMenu()
    {
        MenuCanvas.menuCanvas.SetMenu(MenuCanvas.MENU.CHALLENGES);
    }
}
