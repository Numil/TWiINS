using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDoubleActivation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Levers;
    public GameObject[] buttons;
    public SpriteRenderer[] openedDoor;
    public bool oneOrAnother =false;
    public SpriteRenderer[] closedDoor;

    private void Update()
    {

        int countPressedButtons = 0;
        foreach (GameObject button in buttons)
        {
            if (button.GetComponent<SwitchActivated>().isSwitchOn)
            {
                countPressedButtons++;
            }
        }
        if ((countPressedButtons == buttons.Length && !oneOrAnother) || (countPressedButtons != 0 && oneOrAnother))
        {
            foreach (SpriteRenderer door in openedDoor)
            {
                door.gameObject.SetActive(true);
            }
            foreach (SpriteRenderer door in closedDoor)
            {
                door.gameObject.SetActive(false);
            }
        }
        else if (openedDoor[0].enabled != false)
        {
            foreach (SpriteRenderer door in openedDoor)
            {
                door.gameObject.SetActive(false);
            }
            foreach (SpriteRenderer door in closedDoor)
            {
                door.gameObject.SetActive(true);
            }
        }

    }


}
