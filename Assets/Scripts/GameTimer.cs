using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    private float elapsedTime;
    private bool running = true;

    void Update()
    {
        if (!running)
            return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int centiseconds = Mathf.FloorToInt((elapsedTime * 100f) % 100f);

        timerText.text = $"{minutes:00}:{seconds:00}.{centiseconds:00}";
    }

    public void StopTimer()
    {
        running = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        running = true;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
