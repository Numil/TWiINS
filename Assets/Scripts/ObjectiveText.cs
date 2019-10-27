using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Permet l'affichage des textes de début de niveau
public class ObjectiveText : MonoBehaviour
{
    GameObject t;
    void Awake()
    {
        gameObject.SetActive(true);
        StartCoroutine(DisableText());
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

}
