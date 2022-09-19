using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The prefab to use for the original colored lights
    /// </summary>
    public GameObject coloredLightPrefab;
    
    /// <summary>
    /// Original speed of the original colored lights
    /// </summary>
    public float lightSpeed = 1;

    /// <summary>
    /// Initializing the original colored lights of various colors, position, and velocity vectors
    /// </summary>
    void Start()
    {
        
        var redLight = Instantiate(coloredLightPrefab, new Vector2(-1, -1), Quaternion.identity);
        redLight.GetComponent<SpriteRenderer>().color = Color.red;
        redLight.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * lightSpeed;

        var orangeLight = Instantiate(coloredLightPrefab, new Vector2(2, 0), Quaternion.identity);
        orangeLight.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.64f, 0.0f);
        orangeLight.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * lightSpeed;

        var yellowLight = Instantiate(coloredLightPrefab, new Vector2(0, 2), Quaternion.identity);
        yellowLight.GetComponent<SpriteRenderer>().color = Color.yellow;
        yellowLight.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 1) * lightSpeed;

        var greenLight = Instantiate(coloredLightPrefab, new Vector2(1, 1), Quaternion.identity);
        greenLight.GetComponent<SpriteRenderer>().color = Color.green;
        greenLight.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 1) * lightSpeed;

        var blueLight = Instantiate(coloredLightPrefab, new Vector2(0, -2), Quaternion.identity);
        blueLight.GetComponent<SpriteRenderer>().color = Color.blue;
        blueLight.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * lightSpeed;

        var magentaLight = Instantiate(coloredLightPrefab, new Vector2(3, 4), Quaternion.identity);
        magentaLight.GetComponent<SpriteRenderer>().color = Color.magenta;
        magentaLight.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -0.7f) * lightSpeed;

        var cyanLight = Instantiate(coloredLightPrefab, new Vector2(-4, -3), Quaternion.identity);
        cyanLight.GetComponent<SpriteRenderer>().color = Color.cyan;
        cyanLight.GetComponent<Rigidbody2D>().velocity = new Vector2(0.6f, -0.8f) * lightSpeed;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
