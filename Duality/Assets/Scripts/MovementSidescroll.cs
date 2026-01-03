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
        direction = new Vector2(
            input.x,
            input.y > 0.5 ? 1.0f : 0.0f
        );
    }

    protected override void Move() {
        rb.AddForceX(direction.x * moveForce, ForceMode2D.Force);
        rb.AddForceX(-rb.linearVelocity.x * dragHorizontal, ForceMode2D.Force);
        int mask = LayerMask.GetMask("Obstacle", "Pushable");

        // Checks
        bool isGrounded = Physics2D.OverlapCircle(
            (Vector2)transform.position + Vector2.down * body.radius,
            body.radius * 0.2f,
            mask
        );

        bool onLeftWall = Physics2D.OverlapCircle(
            (Vector2)transform.position + Vector2.left * body.radius,
            body.radius * 0.2f,
            mask
        );

        bool onRightWall = Physics2D.OverlapCircle(
            (Vector2)transform.position + Vector2.right * body.radius,
            body.radius * 0.2f,
            mask
        );

        // Functionality
        if (isGrounded && (direction.y > 0.9f)) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.0f);
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            direction = new Vector2(direction.x, 0.0f);
        }

        if (!isGrounded && (direction.y > 0.9f) && (onLeftWall || onRightWall)) {
            float wallDir = onLeftWall ? 0.5f : -0.5f;
            rb.linearVelocity = Vector2.zero;
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            rb.AddForceX(wallDir * jumpForce, ForceMode2D.Impulse);
            direction = new Vector2(direction.x, 0.0f);
        }
    }
}