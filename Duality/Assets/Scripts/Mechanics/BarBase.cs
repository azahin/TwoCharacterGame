using UnityEngine;

public class BarBase : MonoBehaviour
{
    public int movementRange = 0;

    public int valueIncrease = 1;

    [SerializeField] private ResourceManager manager;

    public void AddValue()
    {
        movementRange += valueIncrease;
        manager.AddValue(valueIncrease);
        Debug.Log(manager.GetValue());
    }
}
