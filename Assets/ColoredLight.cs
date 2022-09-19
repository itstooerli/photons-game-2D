using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredLight : MonoBehaviour
{
    /// <summary>
    /// The prefab to use for the colored lights
    /// </summary>
    public GameObject coloredLightPrefab;

    /// <summary>
    /// Original speed of the colored lights
    /// </summary>
    public float lightSpeed = 1;

    /// <summary>
    /// AudioClip to play when score increments
    /// </summary>
    public AudioClip ScoreUpAudio;

    /// <summary>
    /// AudioClip to play when score decrements
    /// </summary>
    public AudioClip ScoreDownAudio;

    /// <summary>
    /// AudioSource component for this object
    /// </summary>
    private static AudioSource audioSource;

    /// <summary>
    /// Color component for this object
    /// </summary>
    private Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myColor = GetComponent<SpriteRenderer>().color;
    }

    /// <summary>
    /// When a photon collides with this object, destroy the photon and replace the photon
    /// with a Light object of this object's color in the photon's position
    /// Update the score based on this object's color
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Photon")
        {
            Vector2 newPosition = collision.collider.transform.position;
            Destroy(collision.collider.gameObject);
            var newLight = Instantiate(coloredLightPrefab, newPosition, Quaternion.identity);
            newLight.GetComponent<SpriteRenderer>().color = myColor;
            newLight.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 0.5f) * lightSpeed;

            if (myColor == ScoreKeeper.currentColor)
            {
                ScoreKeeper.UpdateScore(1);
                audioSource.PlayOneShot(ScoreUpAudio);
            }
            else
            {
                ScoreKeeper.UpdateScore(-1);
                audioSource.PlayOneShot(ScoreDownAudio);
            }
        }
    }
}
