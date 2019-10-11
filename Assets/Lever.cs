using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{

    public Canvas canvas;
    public Text text;
    private Text shownText = null;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(shownText == null)
        {
            shownText = Instantiate(text, new Vector3(transform.position.x, transform.position.y +1, transform.position.z), new Quaternion(), canvas.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(shownText != null)
        {

            Destroy(shownText.gameObject);
            shownText = null;
        }

    }
}
