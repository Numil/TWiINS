using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer[] door = new SpriteRenderer[2];
    private Animator animator;
    // Update is called once per frame
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsTriggered", false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach(SpriteRenderer sr in door)
        {
            sr.enabled = true;
        }
        animator.SetBool("IsTriggered", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (SpriteRenderer sr in door)
        {
            sr.enabled = false;
        }
        animator.SetBool("IsTriggered", false);
    }
}
