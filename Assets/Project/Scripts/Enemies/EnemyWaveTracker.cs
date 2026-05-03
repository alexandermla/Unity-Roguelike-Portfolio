using UnityEngine;

public class EnemyWaveTracker : MonoBehaviour
{
    private WaveManager waveManager;

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
    }

    public void NotifyWaveManager()
    {
        if (waveManager == null) return;

        waveManager.NotifyEnemyDied();
        Debug.Log(gameObject.name + " notified wave manager");
    }
}

// ScriptRole: Notifies WaveManager when enemy dies
// RelatedScripts: WaveManager, Health
// UsesSO: None
// ReceivesFrom: Health
// SendsTo: WaveManager