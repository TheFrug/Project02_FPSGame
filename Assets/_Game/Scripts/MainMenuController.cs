using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] public TextMeshProUGUI _highScoreTextView;

    private void Awake()
    {
        // Allow mouse cursor to move around game window
        Cursor.lockState = CursorLockMode.Confined;
        // Make mouse cursor visible
        Cursor.visible = true;
    }

    private void Start()
    {
        // load high score display
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();

        if(_menuMusic != null)
        {
            AudioManager.Instance.PlayMusic(_menuMusic);
        }
    }

    public void HighScoreReset()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }

}
