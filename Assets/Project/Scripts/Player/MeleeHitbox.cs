using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AttackStatsSO stats;
    [SerializeField] private LayerMask targetLayers;

    [Header("Owner")]
    [SerializeField] private GameObject owner;

    private readonly HashSet<Health> hitTargets = new HashSet<Health>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == owner) return;
        if (((1 << other.gameObject.layer) & targetLayers) == 0) return;

        Health health = other.GetComponent<Health>();

        if (health == null) return;
        if (hitTargets.Contains(health)) return;

        hitTargets.Add(health);

        Vector2 knockbackDirection = other.transform.position - owner.transform.position;

        health.TakeDamage(stats.damage);
        ApplyKnockback(other.gameObject, knockbackDirection);

        Debug.Log("Melee hit: " + other.name);
    }

    private void ApplyKnockback(GameObject target, Vector2 direction)
    {
        KnockbackReceiver knockback = target.GetComponent<KnockbackReceiver>();

        if (knockback == null) return;

        knockback.ApplyKnockback(
            direction,
            stats.knockbackForce,
            stats.knockbackDuration
        );
    }

    public void ResetHitTargets()
    {
        hitTargets.Clear();
    }
}

// ScriptRole: Deals melee damage and knockback to valid targets
// RelatedScripts: PlayerMeleeAttack, Health, KnockbackReceiver
// UsesSO: AttackStatsSO
// SendsTo: Health, KnockbackReceiver