using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public static float Difficulty = 1f;

    [Header("Difficulty (Step Ramp)")]
    [SerializeField]
    private float stepEverySeconds = 10; // 15 or 30 or 60

    [SerializeField]
    private float stepAmount = 0.25f; // +25% each step

    [SerializeField]
    private float maxDifficulty = 3f; // cap so it doesn't get insane

    private float elapsed;
    private int steps;

    [SerializeField]
    private GameObject fireballPrefab;

    [SerializeField]
    private float spawnInterval = 0.6f;

    [Header("Spawn Area (world space)")]
    [SerializeField]
    private float minX = -8f;

    [SerializeField]
    private float maxX = 8f;

    [SerializeField]
    private float spawnY = 6f;

    private float timer;

    // Instantiates fireball fallrate difficulty when the game starts.
    void Start()
    {
        Difficulty = 1f;
        elapsed = 0f;
        steps = 0;
    }

    void Update()
    {
        elapsed += Time.deltaTime;

        // Increase difficulty in steps based on elapsed time:
        int newSteps = Mathf.FloorToInt(elapsed / stepEverySeconds);
        if (newSteps != steps)
        {
            steps = newSteps;

            // float oldDifficulty = Difficulty;

            Difficulty = Mathf.Min(1f + steps * stepAmount, maxDifficulty);

            // Debug.Log(
            //     $"Difficulty increased! Old: {oldDifficulty:F2} → New: {Difficulty:F2} at {elapsed:F1}s"
            // );
        }

        // Spawn new fireballs at a fixed interval here:
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, spawnY, 0f);
        Instantiate(fireballPrefab, pos, Quaternion.identity);
    }
}
