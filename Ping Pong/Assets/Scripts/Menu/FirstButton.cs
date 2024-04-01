using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstButton : MonoBehaviour
{
    private void OnEnable()
    {
        if (InputManager.inputManager != null)
        {
            InputManager.inputManager.GetComponent<EventSystem>().SetSelectedGameObject(gameObject);
        }
    }
}
