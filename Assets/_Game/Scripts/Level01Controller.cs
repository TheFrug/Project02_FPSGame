using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Level01Controller : MonoBehaviour
{

    private void Awake()
    {
        // Allow mouse cursor to move around game window
        Cursor.lockState = CursorLockMode.Locked;
        // Make mouse cursor not visible
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ExitLevel();
        }
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
