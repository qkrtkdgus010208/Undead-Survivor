using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# Game Control")]
    public bool isPlay;
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };
    public int health;
    public int maxHealth = 100;

    [Header("# Gameobject")]
    public PoolManager pool;
    public Player player;
    public LevelUp uiLevelUp;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;

        // 임시 스크립트 (첫 번째 캐릭터 선택)
        uiLevelUp.Select(0);
    }

    private void Update()
    {
        if (!isPlay)
            return;

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;

        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            uiLevelUp.Show();
            exp = 0;
        }
    }

    public void Stop()
    {
        isPlay = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPlay = true;
        Time.timeScale = 1;
    }
}
