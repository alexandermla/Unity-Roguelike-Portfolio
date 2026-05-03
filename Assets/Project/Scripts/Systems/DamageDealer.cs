using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();

        if (health == null) return;

        Debug.Log(gameObject.name + " dealt damage to " + other.name);
        health.TakeDamage(damage);
    }
}

// ScriptRole: Applies damage to objects with Health
// RelatedScripts: Health
// UsesSO: None
// SendsTo: Health