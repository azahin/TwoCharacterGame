using UnityEngine;
using UnityEngine.InputSystem;

public abstract class MovementBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector2 direction;
    [SerializeField] protected InputActionReference moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move(direction);
    }

    private void OnEnable()
    {
        moveInput.action.Enable();
        moveInput.action.performed += GetInput;
        moveInput.action.canceled += CancelInput;
    }

    private void OnDisable()
    {
        moveInput.action.performed -= GetInput;
        moveInput.action.canceled -= CancelInput;
        moveInput.action.Disable();
    }

    private void CancelInput(InputAction.CallbackContext context)
    {
        direction = Vector2.zero;
    }

    protected abstract void GetInput(InputAction.CallbackContext context);
    protected abstract void Move(Vector2 direction);
}
