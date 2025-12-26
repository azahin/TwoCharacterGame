using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTopdown : MovementBase
{
    [SerializeField] private float moveDuration;

    private bool isMoving = false;

    protected override void GetInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        direction = Vector3.zero;
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            direction.x = Mathf.Sign(input.x);
        else if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
            direction.z = Mathf.Sign(input.y);
    }

    protected override void Move(Vector3 direction)
    {
        if (isMoving)
        {
            return;
        }
        StartCoroutine(MoveCell(direction));
    }

    private IEnumerator MoveCell(Vector3 direction)
    {
        isMoving = true;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + direction * TopdownManager.instance.gridSize;

        float moveTime = 0.0f;
        while (moveTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, moveTime / moveDuration);
            moveTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        TopdownManager.instance.SnapToGrid(transform);
        isMoving = false;
    }
}