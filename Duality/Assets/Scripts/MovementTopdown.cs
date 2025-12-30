using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTopdown : MovementBase {
    [SerializeField] private float moveSpeed;
    private Transform movePoint;

    private void Start() {
        movePoint = transform.GetChild(0);
        movePoint.parent = null;
    }

    protected override void GetInput(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            direction.x = Mathf.Sign(input.x);
        else if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
            direction.y = Mathf.Sign(input.y);
    }

    protected override void Move(Vector2 direction) {
        rb.linearVelocity = moveSpeed * (movePoint.position - transform.position);
        Vector3 dir = new Vector3(direction.x, direction.y, 0.0f);
        if (Vector3.Distance(transform.position, movePoint.position) > 0.05f) return;
        if (Physics2D.Raycast(movePoint.position, dir, TopdownManager.Instance.gridSize, LayerMask.GetMask("Obstacle"))) return;
        
        movePoint.position += dir * TopdownManager.Instance.gridSize;
    }
}