using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Polarity Settings")]
    public bool isPositive = true;

    [Header("Magnet Settings")]
    public Transform redMagnet;
    public Transform blueMagnet;
    public float magnetForce = 15f;

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

   void FixedUpdate()
{
    Magnet[] magnets = FindObjectsOfType<Magnet>();

    foreach (Magnet magnet in magnets)
    {
        float distance = Vector2.Distance(transform.position, magnet.transform.position);

        if (distance < 5f)
        {
            Vector2 direction = magnet.transform.position - transform.position;

            float forceMultiplier = 1f;

            // Reduce magnet force when grounded (so jump works)
            if (isGrounded)
                forceMultiplier = 0.4f;

            if (isPositive == magnet.isPositive)
            {
                // SAME → REPEL
                rb.AddForce(-direction.normalized * magnetForce * forceMultiplier);
            }
            else
            {
                // OPPOSITE → ATTRACT
                rb.AddForce(direction.normalized * magnetForce * forceMultiplier);
            }
        }
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