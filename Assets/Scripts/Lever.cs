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
    private AudioSource audioS;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // On check si le personnage est dans la zone de trigger
        if (isTriggered)
        {
            // S'il appui on active le levier en changeant la valeur isActivated à True ou False selon l'état précédent
            if (Input.GetKeyDown(colliders.GetComponent<Mouvement>().activate))
            {
                isActivated = !isActivated;
                audioS.Play();
                animator.SetBool("IsLeverOn", isActivated);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isTriggered = true;
        colliders = collision;

        // Si le personnage rentre dans la zone de trigger, on active le texte d'aide
        if (shownText == null)
        {
            shownText = Instantiate(text, new Vector3(transform.position.x, transform.position.y +1, transform.position.z), new Quaternion(), canvas.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;

        // Si le personnage sort de la zone de trigger, on désactive le texte d'aide
        if (shownText != null)
        {
            Destroy(shownText.gameObject);
            shownText = null;
        }

    }

}
