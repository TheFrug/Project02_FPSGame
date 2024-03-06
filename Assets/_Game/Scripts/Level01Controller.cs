using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreTextView;
    private int _currentScore;

    private void Awake()
    {

        // Lock mouse to camera
        Cursor.lockState = CursorLockMode.Locked;
        // Make mouse cursor not visible
        Cursor.visible = false;
    }

    private void Update()
    {
        // increase the score
        // TODO replace with real implementation later
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            IncreaseScore(5);
        }
        // note this is with NEW input system
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ExitLevel();
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        // increase score
        _currentScore += scoreIncrease;
        // update score display, so that we see new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }

    public void ExitLevel()
    {
        // compare score to high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(_currentScore > highScore)
        {
            // save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
