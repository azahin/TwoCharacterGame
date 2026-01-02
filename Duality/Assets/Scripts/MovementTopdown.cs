using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.ComponentModel.Design;

public class MovementTopdown : MovementBase {
    [SerializeField] private float moveSpeed;
    private Transform movePoint;
    private float resetTimer = 0.0f;
    private bool moved = false;

    private void Start() {
        movePoint = transform.GetChild(0);
        movePoint.parent = null;
    }

    protected override void GetInput(InputAction.CallbackContext context) {
        if (moved || !ResourceManager.Instance.UseValue())
        {
            direction = Vector2.zero;
            return;
        }
        moved = true;
        Vector2 input = context.ReadValue<Vector2>();
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            direction.x = Mathf.Sign(input.x);
        else if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
            direction.y = Mathf.Sign(input.y);
    }

    protected override void CancelInput(InputAction.CallbackContext context)
    {
        base.CancelInput(context);
        moved = false;
    }

    protected override void Move() {
        rb.linearVelocity = moveSpeed * (movePoint.position - transform.position);
        Vector3 dir = new Vector3(direction.x, direction.y, 0.0f);

        if (resetTimer < 0.0f) {
            resetTimer = 0.0f;
            movePoint.position = transform.position;
        }
        if (Vector3.Distance(transform.position, movePoint.position) > 0.05f) {
            resetTimer -= Time.deltaTime;
            return;
        } else {
            resetTimer = 0.3f;direction = Vector2.zero;
            TopdownManager.Instance.SnapToGrid(rb);
            rb.linearVelocity = Vector3.zero;
        }
        if (Physics2D.Raycast(movePoint.position, dir, TopdownManager.Instance.gridSize, LayerMask.GetMask("Obstacle"))) return;


        movePoint.position += dir * TopdownManager.Instance.gridSize;
    }
}