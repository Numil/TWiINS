using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupActivation : MonoBehaviour
{

    public GameObject lever;
    public GameObject[] buttons;
    public GameObject GroupWhenOn;
    public GameObject GroupWhenOff;
    public bool onlyOneActivation;
    public bool alreadyActivated;

    void Awake()
    {
        // On initie les groupes actifs ou non
        GroupWhenOff.SetActive(false);
        GroupWhenOn.SetActive(true);
        alreadyActivated = false;
    }


    void Update()
    {
        int countActivated = 0;


        // Si le groupe est en mode une seule activation, on check alors s'il a déjà été activé
        if ((!alreadyActivated && onlyOneActivation) || !onlyOneActivation)
        {
            // On check l'état du levier afin d'activer les bons groupes
            if (lever != null)
            {
                if (lever.GetComponent<Lever>().isActivated)
                {
                    GroupWhenOff.SetActive(false);
                    GroupWhenOn.SetActive(true);
                }
                else
                {
                    GroupWhenOff.SetActive(true);
                    GroupWhenOn.SetActive(false);
                }
            }


            if (buttons.Length != 0)
            {
                // On compte les boutons actifs
                foreach (GameObject button in buttons)
                {
                    if (button.GetComponent<Buttons>().isSwitchOn)
                    {
                        countActivated++;
                    }
                }

                // Si tous les boutons sont actifs on change l'état du groupe
                if (countActivated == buttons.Length)
                {
                    alreadyActivated = true;

                    GroupWhenOff.SetActive(true);
                    GroupWhenOn.SetActive(false);
                }
                else
                {
                    GroupWhenOff.SetActive(false);
                    GroupWhenOn.SetActive(true);

                }
            }
        }
        
    }
}
