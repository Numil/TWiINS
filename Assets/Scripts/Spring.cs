using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;
    AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D _rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            _rigidbody.velocity = new Vector2(boxCollider.transform.up.x * 20, boxCollider.transform.up.y * 20);
            animator.SetBool("IsUnloaded", true);
            StartCoroutine(ReenableSpring());
            audio.Play();
        }
    }


    IEnumerator ReenableSpring()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("IsUnloaded", false);
    }
}
