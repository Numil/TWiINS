using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject button;
    private bool alreadyActivated = false;
    public GameObject Explosion;

    private void Update()
    {
        if (!alreadyActivated)
        {
            if (button.GetComponent<SwitchActivated>().isSwitchOn)
            {
                Instantiate(Explosion, transform.position, new Quaternion());
                alreadyActivated = true;
                Destroy(gameObject);
            }
        }
        
    }


}
