using UnityEngine;

public class MagneticBox : MonoBehaviour
{
    public float force = 15f;

    private Rigidbody2D rb;
    private Transform player;
    private PlayerController playerController;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
            playerController = p.GetComponent<PlayerController>();
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > 5f) return;

        Vector2 direction = (player.position - transform.position);
        direction.y = 0;
        direction = direction.normalized;

        float strength = force / distance;

        if (playerController.polarity == -1)
        {
            rb.AddForce(direction * strength);
        }
        else if (playerController.polarity == 1)
        {
            rb.AddForce(-direction * strength);
        }
    }
}