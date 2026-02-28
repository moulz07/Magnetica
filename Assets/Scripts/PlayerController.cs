using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Polarity Settings")]
    public bool isPositive = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    void Update()
    {
        // Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Switch to Negative (Blue)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isPositive = false;
            UpdateColor();
        }

        // Switch to Positive (Red)
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPositive = true;
            UpdateColor();
        }
    }

    void UpdateColor()
    {
        if (isPositive)
            spriteRenderer.color = Color.red;
        else
            spriteRenderer.color = Color.blue;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}