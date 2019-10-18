using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Rigidbody2D _rigidbody = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            _rigidbody.velocity = new Vector2(boxCollider.transform.up.x*20, boxCollider.transform.up.y*20); 
            animator.SetBool("IsUnloaded", true);
            StartCoroutine(ReenableSpring());
        }
    }


    IEnumerator ReenableSpring()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("IsUnloaded", false);
    }
}
