using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 3;

    [SerializeField]
    private HealthUI healthUI;

    private int lives;
    private bool dead;

    private Rigidbody2D rb;
    private MonoBehaviour[] movementScripts; // optional: disables movement on death

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Optional: if your movement script is on the same object, we can disable it on death
        // Put your movement script type(s) here if you want specific control
        movementScripts = GetComponents<MonoBehaviour>();
    }

    void Start()
    {
        lives = maxLives;

        if (healthUI == null)
            healthUI = FindFirstObjectByType<HealthUI>();

        if (healthUI != null)
        {
            healthUI.SetHearts(lives);
            healthUI.ShowGameOver(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dead)
            return;
        if (!other.CompareTag("Fireball"))
            return;

        TakeHit();
    }

    private void TakeHit()
    {
        lives = Mathf.Max(0, lives - 1);

        if (healthUI != null)
            healthUI.SetHearts(lives);

        if (lives <= 0)
            Die();
    }

    private void Die()
    {
        dead = true;

        // Stop movement/physics
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        // Optional: disable all scripts except PlayerHealth itself (quick MVP)
        foreach (var s in movementScripts)
        {
            if (s == null)
                continue;
            if (s == this)
                continue;
            s.enabled = false;
        }

        if (healthUI != null)
            healthUI.ShowGameOver(true);

        GameTimer timer = FindFirstObjectByType<GameTimer>();
        if (timer != null)
        {
            timer.StopTimer();
        }
    }
}
