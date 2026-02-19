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
        timerText.text = elapsedTime.ToString("F2");
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
