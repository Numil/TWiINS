using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    public GameObject[] buttons;
    public GameObject explosion;
    private AudioSource explosionSound;

    private void Awake()
    {
        explosionSound =  explosion.GetComponent<AudioSource>();
    }

    private void Update()
    {
        int countActivated = 0;
        // On compte les boutons actifs
        foreach (GameObject button in buttons)
        {
            if (button.GetComponent<Buttons>().isSwitchOn)
            {
                countActivated++;
            }
        }

        // Si tous les boutons sont actifs, on active l'animation d'explosion et on détruit l'objet
        if (countActivated == buttons.Length)
        {
            Instantiate(explosion, transform.position, new Quaternion());
            Destroy(gameObject);
        }
        
    }


}
