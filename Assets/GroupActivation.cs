using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupActivation : MonoBehaviour
{

    public GameObject lever;
    public GameObject GroupWhenOn;
    public GameObject GroupWhenOff;
    // Update is called once per frame
    void Update()
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
}
