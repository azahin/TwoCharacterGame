using UnityEngine;

public class BarBase : MonoBehaviour
{
    public int movementRange = 0;

    public int valueIncrease = 1;

    public void AddValue()
    {
        movementRange += valueIncrease;
        Debug.Log(movementRange);
    }
}
