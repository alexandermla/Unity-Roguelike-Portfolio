using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Transform[] spawnPoints;

    private int enemiesAlive;

    public GameObject SpawnEnemy()
    {
        if (enemyPrefab == null) return null;
        if (spawnPoints.Length == 0) return null;

        Transform spawnPoint = GetRandomSpawnPoint();

        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        EnemyFollowTarget follow = enemy.GetComponent<EnemyFollowTarget>();

        if (follow != null)
        {
            follow.SetTarget(playerTarget);
        }

        Debug.Log("Enemy spawned");

        return enemy;
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }

    public void NotifyEnemyDied()
    {
        enemiesAlive--;
        enemiesAlive = Mathf.Max(0, enemiesAlive);

        Debug.Log("Enemy removed from spawner count");
    }
}

// ScriptRole: Spawns enemies and limits alive enemies
// RelatedScripts: EnemySpawnerStatsSO, EnemyFollowTarget, EnemySpawnedTracker
// UsesSO: EnemySpawnerStatsSO
// SendsTo: EnemyFollowTarget, EnemySpawnedTracker