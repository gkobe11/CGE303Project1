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

    // player audio
    public AudioClip jumpSound;
    public AudioClip collectSound;
    public AudioClip missSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource playerAudio;

    //animation
    public Animator animator;

    private bool oneSecondDelay = false;


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

        if (isGrounded && oneSecondDelay)
        {
            Debug.Log("ground");
            animator.SetBool("IsJumping", false);
        }

        //check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //jumping animation
            animator.SetBool("IsJumping", true);

            //trigger one second delay
            StartCoroutine(ToggleBooleanAfterDelay());
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }


// Coroutine to handle the delay
private IEnumerator ToggleBooleanAfterDelay()
{
        oneSecondDelay = false;

        yield return new WaitForSeconds(0.5f); // Wait for 1 second
    oneSecondDelay = true; // Toggle the boolean
    Debug.Log("Boolean toggled: " + oneSecondDelay);
}


    void FixedUpdate()
    {
        //move player using rigid body
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //check if player is grounded
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, groundLayer);

        //walking animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

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



    public void PlayCollectSound()
    {
        playerAudio.PlayOneShot(collectSound, 1.0f);
    }

    public void PlayMissSound()
    {
        playerAudio.PlayOneShot(missSound, 4.0f);
    }

    public void PlayWinSound()
    {
        playerAudio.PlayOneShot(winSound, 2.0f);
    }

    public void PlayLoseSound()
    {
        playerAudio.PlayOneShot(loseSound, 1.0f);
    }
}
