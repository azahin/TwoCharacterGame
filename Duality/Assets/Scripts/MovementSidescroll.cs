using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSidescroll : MovementBase {
    [SerializeField] private float moveForce;
    [SerializeField] private float dragHorizontal;
    [SerializeField] private float jumpForce;

    private CircleCollider2D body;

    private void Start() {
        body = GetComponent<CircleCollider2D>();
    }

    protected override void GetInput(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();
        direction = new Vector3(
            input.x,
            input.y > 0.5 ? 1.0f : 0.0f,
            0.0f
        );
    }

    protected override void Move(Vector2 direction) {
        rb.AddForceX(direction.x * moveForce, ForceMode2D.Force);
        rb.AddForceX(-rb.linearVelocity.x * dragHorizontal, ForceMode2D.Force);

        bool isGrounded = Physics2D.CircleCast(
            transform.position,
            body.radius,
            Vector2.down,
            0.1f,
            LayerMask.GetMask("Obstacle", "Pushable")
        );
        if (isGrounded && (direction.y > 0.9f)) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.0f);
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}