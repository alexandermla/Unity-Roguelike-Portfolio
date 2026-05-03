using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollowTarget : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private EnemyStatsSO stats;

    [Header("Target")]
    [SerializeField] private Transform target;

    private Rigidbody2D rb;
    private KnockbackReceiver knockbackReceiver;
    private float speedMultiplier = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockbackReceiver = GetComponent<KnockbackReceiver>();
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        if (knockbackReceiver != null && knockbackReceiver.IsKnockbackActive)
        {
            return;
        }

        Vector2 direction = target.position - transform.position;
        float finalSpeed = stats.moveSpeed * speedMultiplier;

        rb.linearVelocity = direction.normalized * finalSpeed;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log(gameObject.name + " target set");
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = Mathf.Max(0.1f, multiplier);
        Debug.Log(gameObject.name + " speed multiplier set: " + speedMultiplier);
    }
}

// ScriptRole: Moves enemy towards a target with wave speed scaling
// RelatedScripts: EnemyStatsSO, KnockbackReceiver, WaveManager
// UsesSO: EnemyStatsSO
// ReceivesFrom: KnockbackReceiver, WaveManager