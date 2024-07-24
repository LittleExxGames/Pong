using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudio : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<AudioSource>().volume = Settings.settings.GetVolume()/10;
    }
}
