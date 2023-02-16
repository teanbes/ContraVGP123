using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    //Components
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Transform tr;

    //Movement Variables
    public float speed;
    public float jumpForce;

    //Ground Check stuff
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius;

    //PICKUPS
    public int maxLives = 5;
    private int _lives = 3;

    Coroutine jumpForceChange;
    Coroutine speedChange;
    Coroutine scaleChange;


    //lives
    public int lives
    {
        get { return _lives; }
        set 
        { 
            //if(_leves > value)
            // we lost a life - we need to respawn
            _lives = value; 

            if(_lives > maxLives)
                _lives = maxLives;

            // if (_lives <0)
            //gameover

            Debug.Log("Lives have beenset to: " + _lives.ToString());  
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
        

        if (speed <= 0)
        {
            speed = 6.0f;
            Debug.Log("Speed was set incorrect, defaulting to " + speed.ToString());
        }

        if (jumpForce <= 0)
        {
            jumpForce = 300f;
            Debug.Log("Jump Force was set incorrect, defaulting to " + jumpForce.ToString());
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.Log("Ground Check Radius was set incorrect, defaulting to " + groundCheckRadius.ToString());
        }

        if (!groundCheck)
        {
            groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
            Debug.Log("Ground Check not found, finding it manually!");
        }


    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        float vInput = Input.GetAxisRaw("Vertical");
        if (vInput < 0) 
        { 
            anim.SetTrigger("isCrouching");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("isShooting");
        }
        if (!Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("notShooting");
        }

        //Input.GetButtonDown("Fire1") &&
        if ( vInput > 0)
        {
            anim.SetFloat("vInput", 1f);
        }
        if (vInput == 0)
        {
            anim.SetFloat("vInput", 0f);
        }

        if (Input.GetButtonDown("Fire1") && Mathf.Abs(vInput) > 0 && Mathf.Abs(hInput) > 0)
        {
            anim.SetTrigger("isDiagShooting");
        }

        if (Input.GetButtonDown("Fire1") && Mathf.Abs(vInput) > 0 && Mathf.Abs(hInput) == 0)
        {
            anim.SetTrigger("isShootingUp");
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("hInput", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);

        //check for flipped and create an algorithm to flip your character
        if (hInput != 0)
            sr.flipX = (hInput < 0);
    

    }
    // Jump higher power up
    public void StartJumpForceChange()
    {
        if (jumpForceChange == null)
        {
            jumpForceChange = StartCoroutine(JumpForceChange());
        }
        else
        {
            StopCoroutine(jumpForceChange);
            jumpForceChange = null;
            jumpForce /= 2;
            jumpForceChange = StartCoroutine(JumpForceChange());

        }

    }

    IEnumerator JumpForceChange() 
    {
        jumpForce *= 2;

        yield return new WaitForSeconds(5.0f);

        jumpForce /= 2;
        jumpForceChange = null;
    }

    // speed power up
    public void StartspeedChange()
    {
        if (speedChange == null)
        {
            speedChange = StartCoroutine(SpeedChange());
        }
        else
        {
            StopCoroutine(speedChange);
            speedChange = null;
            speed /= 2;
            speedChange = StartCoroutine(SpeedChange());

        }

    }
   
    IEnumerator SpeedChange()
    {
        speed *= 2;

        yield return new WaitForSeconds(5.0f);

        speed /= 2;
        speedChange = null;
    }

    // BigSize power up
    private Vector3 scaleCh;
    
    public void StartScaleChange()
     {
         if (scaleChange == null)
         {
             scaleChange = StartCoroutine(ScaleChange());
         }
         else
         {
            StopCoroutine(scaleChange);
            scaleChange = null;
            tr.transform.localScale = scaleCh;
            scaleChange = StartCoroutine(ScaleChange());
                
         }

     }

     IEnumerator ScaleChange()
     {
        scaleCh = new Vector3 (1.0f, 1.0f,0.0f);

        tr.transform.localScale += scaleCh;

        yield return new WaitForSeconds(5.0f);

        tr.transform.localScale = scaleCh;
        scaleChange = null;
     }

}
