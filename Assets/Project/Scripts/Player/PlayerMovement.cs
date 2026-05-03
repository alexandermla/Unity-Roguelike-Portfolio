using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatsSO stats;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetMovement(Vector2 input)
    {
        moveInput = input;
        Debug.Log("Move set: " + moveInput);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 velocity = moveInput * stats.moveSpeed;
        rb.linearVelocity = velocity;
    }
}

// ScriptRole: Moves player using Rigidbody2D
// RelatedScripts: PlayerInputHandler, PlayerStatsSO
// UsesSO: PlayerStatsSO
// ReceivesFrom: PlayerInputHandler