using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    public bool isPositive = false;   // false = Blue, true = Red
    public float magneticForce = 10f;
    public float detectionRadius = 5f;

    private Rigidbody2D rb;
    private Transform player;
    private PlayerController playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();

        UpdateColor();
    }

    void FixedUpdate()
{
    if (player == null) return;

    float distance = Vector2.Distance(transform.position, player.position);

    if (distance < detectionRadius)
    {
        Vector2 direction = (player.position - transform.position).normalized;

        float strength = magneticForce / distance; // weaker when far

        if (isPositive != playerController.isPositive)
        {
            rb.AddForce(direction * strength);
        }
        else
        {
            rb.AddForce(-direction * strength);
        }
    }
}

    void UpdateColor()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (isPositive)
            sr.color = Color.red;
        else
            sr.color = Color.blue;
    }
}