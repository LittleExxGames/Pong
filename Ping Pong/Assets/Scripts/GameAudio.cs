using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip wallSound;
    public AudioClip paddleSound;
    private void Start()
    {
        GameMaster.gm.gameAudio = this;
    }

    public void PlayWallSound()
    {
        audioS.PlayOneShot(wallSound);
    }
    public void PlayPaddleSound()
    {
        audioS.PlayOneShot(paddleSound);
    }
}
