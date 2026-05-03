using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouseAim : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera mainCamera;

    private Vector2 aimDirection = Vector2.right;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        UpdateAimDirection();
    }

    private void UpdateAimDirection()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector2 direction = mouseWorldPosition - transform.position;

        if (direction.sqrMagnitude <= 0.01f) return;

        aimDirection = direction.normalized;
    }

    public Vector2 GetAimDirection()
    {
        return aimDirection;
    }
}

// ScriptRole: Calculates aim direction from player to mouse
// RelatedScripts: PlayerMeleeAttack
// UsesSO: None
// SendsTo: PlayerMeleeAttack