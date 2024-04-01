using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager inputManager;

    private void Awake()
    {
        inputManager = this;
        DontDestroyOnLoad(gameObject);
    }
}
