using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The prefab to use for the photon this object fires
    /// </summary>
    public GameObject photonPrefab;

    /// <summary>
    /// The factor the player can move forward by
    /// </summary>
    public float acceleration = 5;

    /// <summary>
    /// The factor the player can rotate by
    /// </summary>
    public float rotateSpeed = 100;

    /// <summary>
    /// The original velocity of the photon the player shoots
    /// </summary>
    public float photonVelocity = 10;

    /// <summary>
    /// The score at which the game ends - the negation of this float is the lower bound
    /// That is, if set to 10, the game will end at 10 or -10
    /// </summary>
    public float GoalScore = 10;

    /// <summary>
    /// The rigidBody of this object
    /// </summary>
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Allow the player to shoot photons
    /// Send the player to GameOver if Escape or Cancel 
    /// button is pressed or if GoalScore is reached.
    /// </summary>
    void Update()
    {
        if (Input.GetButtonUp("Fire"))
        {
            var photon = Instantiate(photonPrefab, transform.position + (transform.right * 1.2f), Quaternion.identity);
            Rigidbody2D photonRigidBody = photon.GetComponent<Rigidbody2D>();
            photonRigidBody.velocity = photonVelocity * transform.right;
        }

        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonUp("Cancel") || Mathf.Abs(ScoreKeeper.ReturnScore()) == GoalScore)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    /// <summary>
    /// Allow player to move
    /// </summary>
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 force = new Vector2(x, y) * acceleration;
        rigidBody.AddForce(force);

        float r = Input.GetAxis("Rotate");
        rigidBody.angularVelocity = r * rotateSpeed;
    }
}
