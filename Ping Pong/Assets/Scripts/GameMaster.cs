using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public GameAudio gameAudio;
    private void Awake()
    {
        gm = this;
    }
}
