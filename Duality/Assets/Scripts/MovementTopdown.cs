using UnityEngine;

public class MovementTopdown : MovementBase
{

    protected override Vector3 GetInput()
    {
        Debug.Log("test");
        return Vector3.zero;
    }
    protected override void Move(Vector3 direction)
    {
        Debug.Log("test");
    }
}