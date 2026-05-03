using System.Collections;
using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private EnemyStatsSO stats;

    [Header("Target")]
    [SerializeField] private LayerMask targetLayers;

    [Header("Damage")]
    [SerializeField] private float damageCooldown = 1f;

    private bool canDamage = true;

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDamage(collision.gameObject);
    }

    private void TryDamage(GameObject target)
    {
        if (!canDamage) return;
        if (((1 << target.layer) & targetLayers) == 0) return;

        Health health = target.GetComponent<Health>();

        if (health == null) return;

        health.TakeDamage(stats.contactDamage);
        Debug.Log(gameObject.name + " damaged " + target.name);

        StartCoroutine(DamageCooldownRoutine());
    }

    private IEnumerator DamageCooldownRoutine()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}

// ScriptRole: Deals contact damage only to valid target layers
// RelatedScripts: Health, EnemyStatsSO
// UsesSO: EnemyStatsSO
// SendsTo: Health