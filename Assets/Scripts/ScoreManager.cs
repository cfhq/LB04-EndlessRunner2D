using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score;
    private bool isRunning = true;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = 0f;

        if (scoreText != null)
            scoreText.text = "0";
        else
            Debug.LogWarning("ScoreManager: scoreText is not assigned (TextMeshProUGUI).");
    }

    void Update()
    {
        if (!isRunning)
            return;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            score += Time.deltaTime;
            if (scoreText != null)
                scoreText.text = ((int)score).ToString();
        }
        else
        {
            Debug.Log("ScoreManager: Player not found; score paused.");
        }
    }

    public void StopScore()
    {
        isRunning = false;
    }

    public void ResetScore()
    {
        score = 0f;
        isRunning = true;
        if (scoreText != null)
            scoreText.text = "0";
    }

    public int GetScore()
    {
        return (int)score;
    }
}
