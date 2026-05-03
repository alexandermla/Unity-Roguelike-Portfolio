using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    public float moveSpeed = 2f;
    public int contactDamage = 1;
}

// ScriptRole: Stores enemy configurable values
// RelatedScripts: EnemyFollowTarget, EnemyContactDamage
// UsesSO: None