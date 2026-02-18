using UnityEngine;

public class FireballSource : MonoBehaviour
{
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

    void Update()
    {
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
