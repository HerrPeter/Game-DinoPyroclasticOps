using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed = 6f;

    [SerializeField]
    private float destroyBelowY = -10f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Constant downward speed
        rb.linearVelocity = Vector2.down * fallSpeed;

        // Cleanup when off-screen (or below gameplay area)
        if (transform.position.y < destroyBelowY)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
