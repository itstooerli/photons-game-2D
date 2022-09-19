using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    /// <summary>
    /// The score of the game
    /// </summary>
    public static float score = 0;

    /// <summary>
    /// The text componet for the score
    /// </summary>
    private static TMP_Text scoreText;

    /// <summary>
    /// The interval at which the goal color changes
    /// </summary>
    public float colorInterval = 10;

    /// <summary>
    /// The time when the goal color should change
    /// </summary>
    public float TimeToChangeColors = 0;

    /// <summary>
    /// The goal colors for the game (as strings)
    /// </summary>
    private string[] gameColors = new string[] { "Red", "Orange","Yellow","Green","Blue","Magenta","Cyan" };

    /// <summary>
    /// The index for which color in the gameColor array is being used, randomly updated
    /// </summary>
    private int colorChoice;

    /// <summary>
    /// The string at gameColor[colorChoice]
    /// </summary>
    private static string currentColorString;

    /// <summary>
    /// The equivalent color currentColorString matches as a Color object
    /// </summary>
    public static Color currentColor;

    /// <summary>
    /// AudioClip for when the goal color changes
    /// </summary>
    public AudioClip scoreAudio;

    /// <summary>
    /// The AudioSource component for this object
    /// </summary>
    private static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        TimeToChangeColors = Time.time;
        UpdateColorGoal();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update the score with scoreToAdd and the text to new score
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public static void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score + "\n" + "Color: " + currentColorString;
    }

    /// <summary>
    /// Returns the current score, primarily for GameOver scene's access
    /// </summary>
    /// <returns></returns>
    public static float ReturnScore()
    {
        return score;
    }

    /// <summary>
    /// Reset the score to 0, primarily for restarting the game
    /// </summary>
    public static void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// Update the current goal color and match to a Color object such that
    /// the Light objects can easily compare colors for updating the score
    /// </summary>
    private void UpdateColorGoal()
    {
        colorChoice = Random.Range(0, 7);
        currentColorString = gameColors[colorChoice];
        scoreText.text = "Score: " + score + "\n" + "Color: " + currentColorString;
        TimeToChangeColors += colorInterval;

        switch (currentColorString)
        {
            case "Red": 
                currentColor = Color.red;
                break;
            case "Orange":
                currentColor = new Color(1.0f, 0.64f, 0.0f);
                break;
            case "Yellow":
                currentColor = Color.yellow;
                break;
            case "Green":
                currentColor = Color.green;
                break;
            case "Blue":
                currentColor = Color.blue;
                break;
            case "Magenta":
                currentColor = Color.magenta;
                break;
            case "Cyan":
                currentColor = Color.cyan;
                break;
        }
    }

    /// <summary>
    /// Call UpdateColorGoal when TimeToChangeColors and play audio cue for player
    /// </summary>
    void Update()
    {
        if (Time.time > TimeToChangeColors)
        {
            UpdateColorGoal();
            audioSource.PlayOneShot(scoreAudio);
        }
    }

}
