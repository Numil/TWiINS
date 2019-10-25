using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    Animation a;


    private void Awake()
    {
        a = GetComponent<Animation>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!a.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
