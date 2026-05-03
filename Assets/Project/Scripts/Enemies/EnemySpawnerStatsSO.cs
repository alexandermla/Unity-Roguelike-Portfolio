using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/Enemy Spawner Stats")]
public class EnemySpawnerStatsSO : ScriptableObject
{
    [Min(0.1f)] public float spawnInterval = 2f;
    [Min(1)] public int maxEnemiesAlive = 5;
}

// ScriptRole: Stores enemy spawner configuration
// RelatedScripts: EnemySpawner
// UsesSO: None