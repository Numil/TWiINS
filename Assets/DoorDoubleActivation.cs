using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDoubleActivation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] levers;
    public GameObject[] buttons;
    public GameObject[] doorParts;
    public bool oneOrAnother =false;
    public bool alwaysOn;
    Animator[] doorAnimators;
    BoxCollider2D[] doorColliders;
    bool isOn = false;

    private void Awake()
    {
        List<Animator> listAnim = new List<Animator>();
        List<BoxCollider2D> listCollider = new List<BoxCollider2D>();
        foreach (GameObject door in doorParts)
        {
            listAnim.Add(door.GetComponent<Animator>());
            listCollider.Add(door.GetComponent<BoxCollider2D>());
        }
        doorAnimators = listAnim.ToArray();
        doorColliders = listCollider.ToArray();
    }

    private void Update()
    {

        int countActivated = 0;

        foreach (GameObject button in buttons)
        {
            if (button.GetComponent<SwitchActivated>().isSwitchOn)
            {
                countActivated++;
            }
        }

        foreach (GameObject lever in levers)
        {
            if (lever.GetComponent<Lever>().isActivated)
            {
                countActivated++;
            }
        }


        if ((countActivated == buttons.Length + levers.Length && !oneOrAnother) || (countActivated != 0 && oneOrAnother))
        {
            for (int i = 0; i < doorAnimators.Length; i++)
            {
                doorAnimators[i].SetBool("DoorIsOpen", true);
                doorColliders[i].enabled = false;
            }
        }
        else
        {
            if (!alwaysOn)
            {
                for (int i = 0; i < doorAnimators.Length; i++)
                {
                    doorAnimators[i].SetBool("DoorIsOpen", false);
                    doorColliders[i].enabled = true;
                }
            }
        }

    }


}
