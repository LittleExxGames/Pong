using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings settings;
    private float audioVolume = 1f;
    private bool musicEnabled = true;

    private void Awake()
    {
        if (settings == null)
        {
            settings = this;
        }
    } 

    public void SetVolume(float volume)
    {
        audioVolume = volume;
    }

    public float GetVolume()
    {
        return audioVolume;
    }

    public void SetMusicEnabled(bool enabled)
    {
        musicEnabled = enabled;
    }
    public bool GetMusicEnabled()
    {
        return musicEnabled;
    }
}
