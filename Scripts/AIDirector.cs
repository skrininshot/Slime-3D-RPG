using System;
using UnityEngine;

public class AIDirector : MonoBehaviour
{
    public static AIDirector Instance { get; private set; }
    public static event Action<Enemy> OnEnemyCountChanged;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int spawnDistance;
    [SerializeField] private float difficultMultiply = 1f;
    private PoolMono<Enemy> enemyPool;
    public float DifficultMultiply => difficultMultiply;

    private void Awake()
    {
        Instance = this;
        enemyPool = new PoolMono<Enemy>(enemyPrefab, 2, transform);
    }

    private void SpawnEnemy()
    {
        difficultMultiply += 0.1f;
        Enemy newEnemy = enemyPool.GetFreeElement();
        newEnemy.transform.position = new Vector3(spawnDistance, 0.5f, 0);
        OnEnemyCountChanged(newEnemy);
    }

    private void EnemyDead()
    {
        OnEnemyCountChanged(null);
    }

    private void OnEnable()
    {
        MovingPanel.OnPanelPassed += SpawnEnemy;
        Enemy.OnDie += EnemyDead;
    }

    private void OnDisable()
    {
        MovingPanel.OnPanelPassed -= SpawnEnemy;
        Enemy.OnDie -= EnemyDead;
    }
}
