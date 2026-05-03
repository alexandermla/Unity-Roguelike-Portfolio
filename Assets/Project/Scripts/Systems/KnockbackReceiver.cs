using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnockbackReceiver : MonoBehaviour
{
    public bool IsKnockbackActive { get; private set; }

    private Rigidbody2D rb;
    private Coroutine knockbackRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 direction, float force, float duration)
    {
        if (knockbackRoutine != null)
        {
            StopCoroutine(knockbackRoutine);
        }

        knockbackRoutine = StartCoroutine(KnockbackRoutine(direction, force, duration));
    }

    private IEnumerator KnockbackRoutine(Vector2 direction, float force, float duration)
    {
        IsKnockbackActive = true;

        rb.linearVelocity = direction.normalized * force;

        Debug.Log(gameObject.name + " knockback started");

        yield return new WaitForSeconds(duration);

        rb.linearVelocity = Vector2.zero;
        IsKnockbackActive = false;

        Debug.Log(gameObject.name + " knockback ended");
    }
}

// ScriptRole: Applies temporary knockback to a Rigidbody2D
// RelatedScripts: MeleeHitbox, EnemyFollowTarget
// UsesSO: None
// ReceivesFrom: MeleeHitbox
// SendsTo: EnemyFollowTarget