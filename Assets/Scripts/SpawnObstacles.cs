using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float timeBetweenSpawns;
    private float spawnTime;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    void Update()
    {
        if (GameOver.isGameOver)
            return;

        if (Time.time >= spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawns;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(obstaclePrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
