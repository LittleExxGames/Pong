using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings settings;
    private float audioVolume;
    private bool musicEnabled = true;
    private bool effectsSoundEnabled = true;

    private int ballCount = 1;
    private float paddleSize;
    private float paddleSpeed;
    private void Awake()
    {
        if (settings == null)
        {
            settings = this;
        }
    }
    public void SetBallCount(int count)
    {
        ballCount = count;
    }
    public int GetBallCount()
    {
        return ballCount;
    }

}
