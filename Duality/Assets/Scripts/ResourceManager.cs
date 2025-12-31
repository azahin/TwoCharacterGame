using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int movementValue = 0;
    public static ResourceManager Instance { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void AddValue(int value)
    {
        movementValue += value;
    }

    public void RemoveValue(int value)
    {
        if (movementValue >= 0)
        {
            movementValue -= value;
        }
    }

    public int GetValue()
    {
        return movementValue;
    }
}
