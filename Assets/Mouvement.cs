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
    public KeyCode up;
    public KeyCode jump;
    public KeyCode activate;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public float widthGroundDetector = 0.7f;

    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;
    private float gravity;
    private bool canClimb = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        gravity = _rigidbody.gravityScale;

        
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(widthGroundDetector, 0.1f), 0, whatIsGround);
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
        }
        else if(_rigidbody.velocity.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetBool("Grounded", isGrounded);


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (Input.GetKey(up) && canClimb)
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }

        if (isClimbing)
        {
            inputVertical = 1;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, inputVertical * speed);
            _rigidbody.gravityScale = 0;
        }
        else
        {
            _rigidbody.gravityScale = gravity;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            canClimb = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        canClimb = false;
    }

    private bool IsGrounded()
    {
        int layerMask = LayerMask.GetMask("Ground");
        return Physics2D.Raycast(transform.position, -Vector3.up, 0.06f, layerMask);
    }

    

}
