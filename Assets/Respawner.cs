using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    /// <summary>
    /// If an object does fly off screen through the impenetrable walls, send them back on screen
    /// </summary>
    void OnBecameInvisible()
    {
        transform.position = new Vector2(-2.2f, 0.0f);
    }
}
