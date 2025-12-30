using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTopdown : MovementBase {
    [SerializeField] private float moveForce;
    [SerializeField] private float moveTime;
    private float currentTime = 0.0f;

    protected override void GetInput(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            direction.x = Mathf.Sign(input.x);
        else if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
            direction.y = Mathf.Sign(input.y);
    }

    protected override void CancelInput(InputAction.CallbackContext context) {
        base.CancelInput(context);
    }

    protected override void Move(Vector2 direction) {
        currentTime -= Time.deltaTime;
        if (currentTime < 0.0f) {
            currentTime = 0.0f;
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.linearVelocity == Vector2.zero) {
            rb.AddForce(direction * moveForce, ForceMode2D.Impulse);
            currentTime = moveTime;
        }
    }
}