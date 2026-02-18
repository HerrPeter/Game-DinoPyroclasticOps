using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject pauseButton; // optional: hide while paused

    private bool isPaused;

    void Start()
    {
        SetPaused(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        SetPaused(true);
    }

    public void Resume()
    {
        SetPaused(false);
    }

    public void Quit()
    {
        // In a built game: quits the app
        Application.Quit();

#if UNITY_EDITOR
        // In the editor: stops play mode
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void SetPaused(bool paused)
    {
        isPaused = paused;

        if (pausePanel != null)
            pausePanel.SetActive(paused);

        if (pauseButton != null)
            pauseButton.SetActive(!paused);

        Time.timeScale = paused ? 0f : 1f;
    }
}
