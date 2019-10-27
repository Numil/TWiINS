using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    // Destruction à la fin de l'animation
    void EndDestroy()
    {
        Destroy(gameObject);
    }
}
