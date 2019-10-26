using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{

    public Canvas canvas;
    public Text text;
    private Text shownText = null;
    public bool isActivated;
    private bool isTriggered;
    private Collider2D colliders;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (isTriggered)
        {
            if (Input.GetKeyDown(colliders.GetComponent<Mouvement>().activate))
            {
                isActivated = !isActivated;
                animator.SetBool("IsLeverOn", isActivated);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isTriggered = true;
        colliders = collision;
        if(shownText == null)
        {
            shownText = Instantiate(text, new Vector3(transform.position.x, transform.position.y +1, transform.position.z), new Quaternion(), canvas.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
        if(shownText != null)
        {
            Destroy(shownText.gameObject);
            shownText = null;
        }

    }

}
