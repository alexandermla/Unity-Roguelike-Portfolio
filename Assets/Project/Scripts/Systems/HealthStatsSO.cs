using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stats/Health Stats")]
public class HealthStatsSO : ScriptableObject
{
    [Min(1)] public int maxHealth = 5;
}

// ScriptRole: Stores configurable health values
// RelatedScripts: Health
// UsesSO: None