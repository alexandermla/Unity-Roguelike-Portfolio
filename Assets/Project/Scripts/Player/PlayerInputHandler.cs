using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent<Vector2> OnMove;

    private InputAction moveAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void OnEnable()
    {
        moveAction.Enable();
        moveAction.performed += HandleMove;
        moveAction.canceled += HandleMove;
    }

    private void OnDisable()
    {
        moveAction.performed -= HandleMove;
        moveAction.canceled -= HandleMove;
        moveAction.Disable();
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Debug.Log("Input: " + input);
        OnMove?.Invoke(input);
    }
}

// ScriptRole: Reads player input and emits movement vector
// RelatedScripts: PlayerMovement
// UsesSO: None
// SendsTo: PlayerMovement