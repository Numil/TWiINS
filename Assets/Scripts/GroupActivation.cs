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
    // Update is called once per frame
    public bool alreadyActivated;

    void Awake()
    {

        if (buttons.Length != 0)
        {
            GroupWhenOff.SetActive(false);
            GroupWhenOn.SetActive(true);
        }

        alreadyActivated = false;
    }


    void Update()
    {
        int countActivated = 0;

        if ((!alreadyActivated && onlyOneActivation) || !onlyOneActivation)
        {
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

                foreach (GameObject button in buttons)
                {
                    if (button.GetComponent<SwitchActivated>().isSwitchOn)
                    {
                        countActivated++;
                    }
                }
                if (countActivated == buttons.Length)
                {
                    alreadyActivated = true;

                    GroupWhenOff.SetActive(true);
                    GroupWhenOn.SetActive(false);
                }
            }
        }
        
    }
}
