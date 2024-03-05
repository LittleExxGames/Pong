using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip wallSound;
    public AudioClip paddleSound;

    public void PlayWallSound()
    {
        audioS.PlayOneShot(wallSound);
    }
    public void PlayPaddleSound()
    {
        audioS.PlayOneShot(paddleSound);
    }
}
