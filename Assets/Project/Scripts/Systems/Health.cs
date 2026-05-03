using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private HealthStatsSO stats;

    [Header("Events")]
    public UnityEvent<int, int> OnHealthChanged;
    public UnityEvent OnDamaged;
    public UnityEvent OnDied;

    private int currentHealth;
    private int maxHealth;
    private bool isDead;

    private void Awake()
    {
        maxHealth = stats.maxHealth;
        currentHealth = maxHealth;

        Debug.Log(gameObject.name + " health initialized: " + currentHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = Mathf.Max(1, newMaxHealth);
        currentHealth = maxHealth;

        Debug.Log(gameObject.name + " max health set: " + maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;
        if (amount <= 0) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " took damage: " + amount);

        OnDamaged?.Invoke();
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;
        if (amount <= 0) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " healed: " + amount);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void Die()
    {
        isDead = true;

        Debug.Log(gameObject.name + " died");
        OnDied?.Invoke();
    }
}

// ScriptRole: Manages health, damage, healing, max health, and death
// RelatedScripts: HealthStatsSO, HitFlashFeedback, WaveManager
// UsesSO: HealthStatsSO
// ReceivesFrom: WaveManager
// SendsTo: HitFlashFeedback, DestroyOnDeath, EnemyDeathHandler