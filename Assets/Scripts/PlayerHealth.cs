using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float restartDelay = 0.25f;
    private bool dead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dead)
            return;

        // simplest MVP: anything tagged Fireball kills you
        if (other.CompareTag("Fireball"))
        {
            dead = true;
            Invoke(nameof(Restart), restartDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
