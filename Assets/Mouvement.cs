using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouvement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public string pName;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public GameObject playerName;
    private GameObject text;

    public GameObject cursorBlue;
    private GameObject curs;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        //Player name follow
        text = Instantiate(playerName, new Vector3(transform.position.x - 1, transform.position.y + 2), Quaternion.Euler(0,0,0), transform);
        text.GetComponent<TextMesh>().text = pName;

        //Blue player cursor
        curs = Instantiate(cursorBlue, new Vector3(transform.position.x, transform.position.y + 3), Quaternion.identity, transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey(left))
        {
            _rigidbody.velocity = new Vector2(-speed, _rigidbody.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }


        if (Input.GetKey(jump) && isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce);
        }

        if(_rigidbody.velocity.x < 0)
        {          
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            text.transform.localRotation = Quaternion.Euler(0, -180, 0);
            text.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 2);
        }
        else if(_rigidbody.velocity.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            text.transform.localRotation = Quaternion.Euler(0, 0, 0);
            text.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 2);
        }

        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetBool("Grounded", isGrounded);
        

        

    }

}
