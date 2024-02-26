using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private void Awake()
    {
        // Allow mouse cursor to move around game window
        Cursor.lockState = CursorLockMode.Confined;
        // Make mouse cursor visible
        Cursor.visible = true;
    }
}
