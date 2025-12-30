using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTopdown : MovementBase
{
    private bool isMoving = false;

    protected override void GetInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        direction = Vector3.zero;
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            direction.x = Mathf.Sign(input.x);
        else if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
            direction.y = Mathf.Sign(input.y);
    }

    protected override void Move(Vector2 direction)
    {
        if (isMoving)
        {
            return;
        }
        StartCoroutine(TopdownManager.Instance.MoveCell(transform, direction));
    }
}