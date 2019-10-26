using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveText : MonoBehaviour
{
    GameObject t;
    // Start is called before the first frame update
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
