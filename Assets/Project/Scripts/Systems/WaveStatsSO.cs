using UnityEngine;

[CreateAssetMenu(menuName = "SO/Waves/Wave Stats")]
public class WaveStatsSO : ScriptableObject
{
    [Header("Enemies")]
    [Min(1)] public int startEnemies = 3;
    [Min(1)] public int enemiesIncreasePerWave = 2;

    [Header("Timing")]
    [Min(0.1f)] public float timeBetweenSpawns = 1f;
    [Min(0.5f)] public float timeBetweenWaves = 3f;

    [Header("Speed Scaling")]
    [Min(0f)] public float speedIncreasePerWave = 0.1f;

    [Header("Health Scaling")]
    [Min(1)] public int baseEnemyHealth = 2;
    [Min(1)] public int healthIncreaseEveryWaves = 3;
    [Min(1)] public int healthIncreaseAmount = 1;
}

// ScriptRole: Stores wave and enemy scaling configuration
// RelatedScripts: WaveManager
// UsesSO: None