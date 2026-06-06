using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public float fallLimit = -5f; // adjust based on your level

    void Update()
    {
        if (transform.position.y < fallLimit)
        {
            GameManager.instance.GameOver();
        }
    }
}