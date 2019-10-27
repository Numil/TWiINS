using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouvement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public string pName;

    //Touches de mouvement
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode jump;
    public KeyCode activate;

    // Récupération des composants
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private AudioSource audioS;

    //Timer pour le saut plus permissif
    float groundedRemember = 0;
    float groundedRememberTime = 0.15f;

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

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        gravity = _rigidbody.gravityScale;

        
    }

    void Update()
    {
        //Ground check
        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(widthGroundDetector, 0.1f), 0, whatIsGround);

        #region Gauche et Droite
        // Bouger à gauche et à droite
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
        #endregion

        #region Saut




        //Permet un "timing de jump" plus permissif

        groundedRemember -= Time.deltaTime;
        if (isGrounded)
        {
            groundedRemember = groundedRememberTime;
        }

        

        if (groundedRemember > 0)
        {
            if (Input.GetKey(jump))
            {
                groundedRemember = 0;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce);
            }
        }

        //if (Input.GetKey(jump) && isGrounded)
        //{
        //    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpforce);
        //}
        #endregion

        if (_rigidbody.velocity.x < 0)
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

        #region Grimper à l'échelle

        // Si le joueur peut monter, alors on le fait monter
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
        #endregion
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
