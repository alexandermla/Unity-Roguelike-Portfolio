using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private WaveStatsSO stats;

    [Header("References")]
    [SerializeField] private EnemySpawner enemySpawner;

    [Header("Events")]
    public UnityEvent<int> OnWaveChanged;

    private int currentWave;
    private int enemiesToSpawn;
    private int enemiesAlive;

    private void Start()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentWave++;

        enemiesToSpawn = stats.startEnemies +
            ((currentWave - 1) * stats.enemiesIncreasePerWave);

        enemiesAlive = enemiesToSpawn;

        Debug.Log("Wave started: " + currentWave);
        OnWaveChanged?.Invoke(currentWave);

        StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator SpawnWaveRoutine()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = enemySpawner.SpawnEnemy();

            if (enemy != null)
            {
                SetupEnemyForWave(enemy);
            }

            yield return new WaitForSeconds(stats.timeBetweenSpawns);
        }
    }

    private void SetupEnemyForWave(GameObject enemy)
    {
        EnemyWaveTracker tracker = enemy.GetComponent<EnemyWaveTracker>();
        EnemyFollowTarget follow = enemy.GetComponent<EnemyFollowTarget>();
        Health health = enemy.GetComponent<Health>();

        if (tracker != null)
        {
            tracker.SetWaveManager(this);
        }

        if (follow != null)
        {
            follow.SetSpeedMultiplier(GetSpeedMultiplier());
        }

        if (health != null)
        {
            health.SetMaxHealth(GetEnemyHealth());
        }

        Debug.Log(enemy.name + " configured for wave " + currentWave);
    }

    private float GetSpeedMultiplier()
    {
        return 1f + ((currentWave - 1) * stats.speedIncreasePerWave);
    }

    private int GetEnemyHealth()
    {
        int increases = (currentWave - 1) / stats.healthIncreaseEveryWaves;
        return stats.baseEnemyHealth + (increases * stats.healthIncreaseAmount);
    }

    public void NotifyEnemyDied()
    {
        enemiesAlive--;
        enemiesAlive = Mathf.Max(0, enemiesAlive);

        Debug.Log("Wave enemy died. Alive: " + enemiesAlive);

        if (enemiesAlive <= 0)
        {
            StartCoroutine(NextWaveRoutine());
        }
    }

    private IEnumerator NextWaveRoutine()
    {
        Debug.Log("Waiting next wave");

        yield return new WaitForSeconds(stats.timeBetweenWaves);

        StartNextWave();
    }
}

// ScriptRole: Controls waves and applies enemy scaling
// RelatedScripts: WaveStatsSO, EnemySpawner, EnemyWaveTracker, EnemyFollowTarget, Health
// UsesSO: WaveStatsSO
// ReceivesFrom: EnemyWaveTracker
// SendsTo: EnemySpawner, WaveTextUI, EnemyFollowTarget, Health