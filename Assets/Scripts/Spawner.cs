using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 5));
        enemy.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length)].position;
    }
}
