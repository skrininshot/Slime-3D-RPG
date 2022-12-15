using System;
using UnityEngine;

public class AIDirector : MonoBehaviour
{
    public static AIDirector Instance;
    public static event Action<int> OnEnemyCountChanged;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int spawnDistance;
    private PoolMono<Enemy> enemyPool;

    private void Awake()
    {
        Instance = this;
        enemyPool = new PoolMono<Enemy>(enemyPrefab, 2, transform);
    }

    public void SpawnEnemy()
    {
        Enemy newEnemy = enemyPool.GetFreeElement();
        newEnemy.transform.position = new Vector3(spawnDistance, 0.5f, 0);
        OnEnemyCountChanged(1);
    }

    private void OnEnable()
    {
        MovingPanel.OnPanelPassed += SpawnEnemy;
    }

    private void OnDisable()
    {
        MovingPanel.OnPanelPassed -= SpawnEnemy;
    }
}
