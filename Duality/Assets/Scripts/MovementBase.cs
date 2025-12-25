using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        Vector3 direction = GetInput();
        Move(direction);
    }

    protected abstract Vector3 GetInput();
    protected abstract void Move(Vector3 direction);
}
