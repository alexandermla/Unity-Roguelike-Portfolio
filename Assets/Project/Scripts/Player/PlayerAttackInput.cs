using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttackInput : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnAttack;

    private InputAction attackAction;

    private void Awake()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    private void OnEnable()
    {
        attackAction.Enable();
        attackAction.performed += HandleAttack;
    }

    private void OnDisable()
    {
        attackAction.performed -= HandleAttack;
        attackAction.Disable();
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack input");
        OnAttack?.Invoke();
    }
}

// ScriptRole: Emits attack input event
// RelatedScripts: PlayerAttack
// SendsTo: PlayerAttack