using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    private Vector2 lastDirection = Vector2.right;

    public void UpdateFacing(Vector2 input)
    {
        if (input != Vector2.zero)
        {
            lastDirection = input.normalized;
            Debug.Log("Facing: " + lastDirection);
        }
    }

    public Vector2 GetFacing()
    {
        return lastDirection;
    }
}

// ScriptRole: Stores last movement direction
// RelatedScripts: PlayerMovement, PlayerAttack
// ReceivesFrom: PlayerInputHandler
// SendsTo: PlayerAttack