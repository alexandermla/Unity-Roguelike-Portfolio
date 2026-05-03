using TMPro;
using UnityEngine;

public class HealthTextUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text healthText;

    [Header("Format")]
    [SerializeField] private string prefixText = "HP: ";

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        healthText.text = prefixText + currentHealth + " / " + maxHealth;
        Debug.Log("Health UI updated");
    }
}

// ScriptRole: Updates health text using TextMeshPro
// RelatedScripts: Health
// UsesSO: None
// ReceivesFrom: Health