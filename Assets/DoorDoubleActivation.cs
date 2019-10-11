using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDoubleActivation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] buttons;
    public SpriteRenderer[] openedDoor;

    private void Update()
    {
        isOpen();
    }

    public bool isOpen()
    {
        int countPressedButtons = 0;


        foreach(GameObject button in buttons)
        {
            if (button.GetComponent<SwitchActivated>().isSwitchOn)
            {
                countPressedButtons++;
            }
        }
        if (countPressedButtons == buttons.Length)
        {
            foreach (SpriteRenderer door in openedDoor)
            {
                door.enabled = true;
            }
        }
        else if (openedDoor[0].enabled != false)
        {
            foreach (SpriteRenderer door in openedDoor)
            {
                door.enabled = false;
            }
        }
        return true;
    }

}
