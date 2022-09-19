using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photon : MonoBehaviour
{
    /// <summary>
    /// Safeguard in case a photon breaks through the walls, destroy it.
    /// </summary>
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
