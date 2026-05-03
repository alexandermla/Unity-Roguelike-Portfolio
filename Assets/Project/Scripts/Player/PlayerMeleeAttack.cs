using System.Collections;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private AttackStatsSO stats;

    [Header("References")]
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private MeleeHitbox meleeHitbox;

    private PlayerMouseAim mouseAim;
    private bool canAttack = true;

    private void Awake()
    {
        mouseAim = GetComponent<PlayerMouseAim>();
        meleeHitbox.gameObject.SetActive(false);
    }

    public void TryAttack()
    {
        if (!canAttack) return;

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        canAttack = false;

        Vector2 aimDirection = mouseAim.GetAimDirection();
        float baseAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        float startAngle = baseAngle - stats.sweepAngle * 0.5f;
        float endAngle = baseAngle + stats.sweepAngle * 0.5f;

        meleeHitbox.ResetHitTargets();
        meleeHitbox.gameObject.SetActive(true);

        Debug.Log("Melee attack started");

        float timer = 0f;

        while (timer < stats.attackDuration)
        {
            timer += Time.deltaTime;

            float t = timer / stats.attackDuration;
            float currentAngle = Mathf.Lerp(startAngle, endAngle, t);

            Vector2 currentDirection = AngleToDirection(currentAngle);

            weaponPivot.localPosition = currentDirection * stats.attackDistance;
            weaponPivot.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            yield return null;
        }

        meleeHitbox.gameObject.SetActive(false);

        Debug.Log("Melee attack ended");

        yield return new WaitForSeconds(stats.attackCooldown);

        canAttack = true;
    }

    private Vector2 AngleToDirection(float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
    }
}

// ScriptRole: Performs melee sweep from a pivot around the player
// RelatedScripts: PlayerAttackInput, PlayerMouseAim, MeleeHitbox, AttackStatsSO
// UsesSO: AttackStatsSO
// ReceivesFrom: PlayerAttackInput
// SendsTo: MeleeHitbox