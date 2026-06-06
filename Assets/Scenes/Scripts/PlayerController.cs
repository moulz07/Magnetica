using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public int polarity = 0;
    public float repelForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        // NEGATIVE (BLUE)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            polarity = -1;
            sr.color = Color.blue;
        }

        // POSITIVE (RED)
        if (Input.GetKeyDown(KeyCode.E))
        {
            polarity = 1; // repel
            sr.color = Color.red;

            ApplyRepelBoost();
        }

        // NEUTRAL
        if (Input.GetKeyDown(KeyCode.R))
        {
            polarity = 0;
            sr.color = Color.white;
        }
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
    void ApplyRepelBoost()
    {
    Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2f);

    foreach (Collider2D hit in hits)
    {
        if (hit.CompareTag("MetalBox"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            Vector2 dir = (transform.position - hit.transform.position).normalized;

            // Strong upward push
            Vector2 boost = new Vector2(dir.x, 1f) * repelForce;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // reset Y
            rb.AddForce(boost, ForceMode2D.Impulse);
        }
    }
}
}