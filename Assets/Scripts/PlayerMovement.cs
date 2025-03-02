using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;

    private Vector2 velocity = Vector2.zero;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isMoving = false;

    //  Sons
    public AudioSource audioSource; // AudioSource général pour les sons
    public AudioClip footstepSound; // Son des pas
    public AudioClip jumpSound; // Son du saut

    private bool isPlayingFootstep = false;

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);
    }

    void Update()
    {
        // Vérifie si le joueur est au sol
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
        }
        else
        {
            isGrounded = false;
        }

        // Gestion du saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Gestion du son des pas
        HandleFootstepSound();
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        CancelInvoke("PlayFootstepSound"); // Arrête le son des pas
        isPlayingFootstep = false;

        //  Joue le son du saut
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void HandleFootstepSound()
    {
        bool isWalking = Mathf.Abs(rb.linearVelocity.x) > 0.1f && isGrounded;

        if (isWalking)
        {
            if (!isMoving)
            {
                isMoving = true;
                if (!isPlayingFootstep)
                {
                    isPlayingFootstep = true;
                    InvokeRepeating("PlayFootstepSound", 0f, 0.4f);
                }
            }
        }
        else
        {
            isMoving = false;
            isPlayingFootstep = false;
            CancelInvoke("PlayFootstepSound");
        }
    }

    void PlayFootstepSound()
    {
        if (audioSource != null && footstepSound != null)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }
}