using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Text component for the Game Over Text
    /// </summary>
    private static TMP_Text GameOverText;

    /// <summary>
    /// Set initial game over text and pause the time scale for the game
    /// </summary>
    void Start()
    {
        GameOverText = GetComponent<TMP_Text>();
        GameOverText.text = "Game Over\n" + "Score: " + ScoreKeeper.ReturnScore() + "\n\n" + "Press Any Key to Play Again";
        Time.timeScale = 0.0f;
    }

    /// <summary>
    /// Allow player to reload the game, reset the score, and restart the time scale
    /// </summary>
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main Level");
            ScoreKeeper.ResetScore();
            Time.timeScale = 1.0f;
        }
    }
}
