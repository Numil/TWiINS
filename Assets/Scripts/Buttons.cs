using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public bool isSwitchOn;
    private Animator animator;
    private BoxCollider2D boxCollider;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("IsTriggered", false);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        // Si le joueur entre dans la zone de trigger du bouton on l'active 
        if (boxCollider.isTrigger)
        {
            isSwitchOn = true;
            animator.SetBool("IsTriggered", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si le joueur sort de la zone de trigger du bouton on le désactive 
        if (boxCollider.isTrigger)
        {
            isSwitchOn = false;
            animator.SetBool("IsTriggered", false);
        }
    }

}
