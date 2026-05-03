using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    public void HandleDeath()
    {
        Debug.Log(gameObject.name + " enemy died");
        Destroy(gameObject);
    }
}

// ScriptRole: Handles enemy death
// RelatedScripts: Health
// UsesSO: None
// ReceivesFrom: Health