using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject[] buttons;
    public GameObject explosion;

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

        if (countActivated == buttons.Length)
        {
            Instantiate(explosion, transform.position, new Quaternion());
            Destroy(gameObject);
        }
        
    }


}
