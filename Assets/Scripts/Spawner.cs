using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    public float levelTime;

    int level;
    float timer;

    private void Awake()
    {
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;
    }

    private void Update()
    {
        if (!GameManager.instance.isPlay)
            return;

        timer += Time.deltaTime;

        int rand = Random.Range(0, Mathf.CeilToInt(GameManager.instance.gameTime / levelTime));
        level = Mathf.Min(rand, spawnData.Length - 1);

        if (timer > spawnData[level].spawneTime)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawneTime;
    public int spriteType;
    public int health;
    public float speed;
}
