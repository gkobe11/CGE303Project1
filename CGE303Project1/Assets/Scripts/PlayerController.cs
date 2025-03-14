using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player movement speed
    public float moveSpeed = 5f;

    //jump force
    public float jumpForce = 10f;

    //layer mask for ground check
    public LayerMask groundLayer;
    public Transform GroundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;

    //reference to rigid body comp
    private Rigidbody2D rb;

    //player input
    private float horizontalInput;
    private float verticalInput;

    //player audio
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //attach rigid body comp to rb
        rb = GetComponent<Rigidbody2D>();

        //check ground check is assigned
        if (GroundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to player controller");
        }

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        //check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void FixedUpdate()
    {
        //move player using rigid body
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //check if player is grounded
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, groundLayer);

        //add animation here 

        //ensure player is facing in movement direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //facing left
        }
    }
}
