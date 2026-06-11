using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            var gameOver = FindObjectOfType<GameOver>();
            if (gameOver != null)
                gameOver.ShowGameOver();

            Destroy(player != null ? player.gameObject : collision.gameObject);
        }
    }
}
