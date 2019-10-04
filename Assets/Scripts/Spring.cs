using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Rigidbody2D _rigidbody = collision.collider.gameObject.GetComponent<Rigidbody2D>();
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 20);
            Debug.Log(collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity);
        }
    }
}
