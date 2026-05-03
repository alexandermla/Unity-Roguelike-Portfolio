using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AttackStatsSO stats;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject attackHitboxPrefab;

    private PlayerFacing facing;
    private bool canAttack = true;

    private void Awake()
    {
        facing = GetComponent<PlayerFacing>();
    }

    public void TryAttack()
    {
        if (!canAttack) return;

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        canAttack = false;

        Vector2 dir = facing.GetFacing();
        Vector3 spawnPos = attackPoint.position + (Vector3)(dir * stats.attackDistance);

        GameObject hitbox = Instantiate(attackHitboxPrefab, spawnPos, Quaternion.identity);
        hitbox.transform.right = dir;

        Debug.Log("Attack performed");

        yield return new WaitForSeconds(stats.attackDuration);

        Destroy(hitbox);

        yield return new WaitForSeconds(stats.attackCooldown);

        canAttack = true;
    }
}

// ScriptRole: Controls attack timing and spawning hitbox
// RelatedScripts: PlayerAttackInput, PlayerFacing, AttackHitbox
// UsesSO: AttackStatsSO
// ReceivesFrom: PlayerAttackInput
// SendsTo: AttackHitbox