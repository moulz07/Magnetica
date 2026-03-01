using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool isPositive = true; // true = Red, false = Blue

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (isPositive)
            sr.color = Color.red;
        else
            sr.color = Color.blue;
    }
}