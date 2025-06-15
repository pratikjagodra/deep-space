using UnityEngine;
using UnityEngine.InputSystem;

public class ShipInputHandler : MonoBehaviour, ShiptInputActions.IShipInputActions
{
    public Vector2 MoveInput { get; private set; }
    private ShiptInputActions inputActions;

    private void Awake()
    {
        inputActions = new ShiptInputActions();
        inputActions.ShipInput.AddCallbacks(this);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext moveContext)
    {
        MoveInput = moveContext.ReadValue<Vector2>();
        MoveInput.Normalize();
    }
}
