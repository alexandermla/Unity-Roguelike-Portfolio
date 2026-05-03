using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/PlayerStats")]
public class PlayerStatsSO : ScriptableObject
{
    public float moveSpeed = 5f;
}

// ScriptRole: Stores player configurable stats
// RelatedScripts: PlayerMovement
// UsesSO: None