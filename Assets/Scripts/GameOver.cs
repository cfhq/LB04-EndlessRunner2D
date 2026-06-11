using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver = false;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public GameObject hud;

    void Start()
    {
        GameOver.isGameOver = false;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (hud != null)
            hud.SetActive(true);
    }

    public void ShowGameOver()
    {
        GameOver.isGameOver = true;

        if (hud != null)
            hud.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        var scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.StopScore();
            if (finalScoreText != null)
                finalScoreText.text = scoreManager.GetScore().ToString();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameOver.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
