using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer[] door = new SpriteRenderer[2];
    BoxCollider2D boxCollider;
    private Animator animator;
    // Update is called once per frame
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsTriggered", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (boxCollider.isTrigger)
        {
            foreach (SpriteRenderer sr in door)
            {
                sr.enabled = true;
            }
            animator.SetBool("IsTriggered", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (boxCollider.isTrigger)
        {
            foreach (SpriteRenderer sr in door)
            {
                sr.enabled = false;
            }
            animator.SetBool("IsTriggered", false);

        }
    }
}
