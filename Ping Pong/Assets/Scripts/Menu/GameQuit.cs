using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        //Maybe do something
    }
}
