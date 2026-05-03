using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] private AttackStatsSO stats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();

        if (health == null) return;

        Debug.Log("Hit enemy: " + other.name);
        health.TakeDamage(stats.damage);
    }
}

// ScriptRole: Applies damage on contact
// RelatedScripts: PlayerAttack, Health
// UsesSO: AttackStatsSO
// SendsTo: Health