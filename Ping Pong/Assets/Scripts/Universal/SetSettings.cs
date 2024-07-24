using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSettings : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;
    // Update audio source volume
    private void Start()
    {
        volumeSlider.value = Settings.settings.GetVolume();
    }
    public void OnVolumeSliderChanged(float newVolume)
    {
        newVolume = volumeSlider.value;
        if (GameMaster.gameAudio != null)
        {
            GameMaster.gameAudio.GetComponent<AudioSource>().volume = newVolume/10f;
        }
        Settings.settings.SetVolume(newVolume);
    }
}