using UnityEngine;

[CreateAssetMenu(menuName = "SO/Combat/Attack Stats")]
public class AttackStatsSO : ScriptableObject
{
    [Header("Damage")]
    public int damage = 1;

    [Header("Timing")]
    public float attackDuration = 0.18f;
    public float attackCooldown = 0.35f;

    [Header("Shape")]
    public float attackDistance = 0.45f;
    public float sweepAngle = 100f;

    [Header("Knockback")]
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.12f;
}

// ScriptRole: Stores melee attack configuration
// RelatedScripts: PlayerMeleeAttack, MeleeHitbox
// UsesSO: None