
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    float horizontalInput = 0f;
    public float runSpeed = 5f;
    public float jumpForce = 6f;
    public int spacebarclick = 0;
    public bool isJumpPressed = false;
    public GameManager gameManager;
    private bool isUIMovePressed = false;

    void Start()
    {
        rb.simulated = false;
    }

    void Update()
    {
        if (!isUIMovePressed)
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            horizontalInput = moveInput;
        }
        if (Input.GetButtonDown("Jump"))
        {
            StartJump();
        }
        if (Input.GetButtonUp("Jump"))
        {
            StopJump();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * runSpeed, rb.linearVelocity.y);

        if (isJumpPressed && spacebarclick < 1)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            spacebarclick++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tilemap"))
        {
            spacebarclick = 0;
        }

        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("GroundDown"))
        {
            gameManager.GameOver();
        }
    }

    public void StartMoveRight()
    {
        horizontalInput = 1f;
        isUIMovePressed = true;
    }

    public void StartMoveLeft()
    {
        horizontalInput = -1f;
        isUIMovePressed = true;
    }

    public void StopMove()
    {
        horizontalInput = 0f;
        isUIMovePressed = false;
    }

    public void StartJump()
    {
        isJumpPressed = true;
        // isUIMovePressed = true;
    }

    public void StopJump()
    {
        isJumpPressed = false;
        // isUIMovePressed = false;
    }
}