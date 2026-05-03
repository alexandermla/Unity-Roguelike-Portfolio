using UnityEngine;

public class EnemySpawnedTracker : MonoBehaviour
{
    private EnemySpawner spawner;

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        spawner = enemySpawner;
    }

    public void NotifySpawner()
    {
        if (spawner == null) return;

        spawner.NotifyEnemyDied();
        Debug.Log(gameObject.name + " notified spawner");
    }
}

// ScriptRole: Notifies spawner when this enemy dies
// RelatedScripts: EnemySpawner, Health
// UsesSO: None
// ReceivesFrom: Health
// SendsTo: EnemySpawner