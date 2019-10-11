using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivated : MonoBehaviour
{

    public bool isSwitchOn;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        isSwitchOn = true;
        animator.SetBool("IsTriggered", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isSwitchOn = false;
        animator.SetBool("IsTriggered", false);
    }

}
