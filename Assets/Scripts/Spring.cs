using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;
    AudioSource audioS;
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioS = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Lorsqu'un joueur entre dans la zone de trigger on le fait sauter
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D _rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            _rigidbody.velocity = new Vector2(boxCollider.transform.up.x * 20, boxCollider.transform.up.y * 20);
            animator.SetBool("IsUnloaded", true);
            StartCoroutine(ReenableSpring());
            // on joue le son du bumper
            audioS.Play();
        }
    }

    // Permet de "recharger" le bumper
    IEnumerator ReenableSpring()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("IsUnloaded", false);
    }
}
