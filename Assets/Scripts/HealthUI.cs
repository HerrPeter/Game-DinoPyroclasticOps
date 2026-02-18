using UnityEngine;
using UnityEngine.UI;
#if TMP_PRESENT
using TMPro;
#endif

public class HealthUI : MonoBehaviour
{
    [Header("Hearts (left to right)")]
    [SerializeField]
    private Image[] hearts; // Heart1, Heart2, Heart3

    [Header("Colors")]
    [SerializeField]
    private Color aliveColor = Color.white;

    [SerializeField]
    private Color deadColor = new Color(0.4f, 0.4f, 0.4f, 1f);

    [Header("Game Over Text (optional)")]
    [SerializeField]
    private GameObject gameOverObject; // GameOverText object

    [SerializeField]
    private GameObject newGameButton;

    public void SetHearts(int currentLives)
    {
        // Example: currentLives = 3 => all alive
        // currentLives = 2 => gray out rightmost
        // currentLives = 1 => gray out two rightmost
        // currentLives = 0 => all gray

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == null)
                continue;
            hearts[i].color = aliveColor;
        }

        // Gray out from right to left
        for (int lost = 0; lost < (hearts.Length - currentLives); lost++)
        {
            int indexFromRight = hearts.Length - 1 - lost;
            if (
                indexFromRight >= 0
                && indexFromRight < hearts.Length
                && hearts[indexFromRight] != null
            )
                hearts[indexFromRight].color = deadColor;
        }
    }

    public void ShowGameOver(bool show)
    {
        if (gameOverObject != null)
            gameOverObject.SetActive(show);

        if (newGameButton != null)
            newGameButton.SetActive(show);
    }
}
