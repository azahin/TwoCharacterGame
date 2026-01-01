using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int movementValue = 0;
    public static ResourceManager Instance { get; set; }

    [SerializeField] private int increase = 1;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void AddValue()
    {
        movementValue += increase;
    }

    public bool UseValue(int value)
    {
        bool endState = false;
        if (movementValue >= 0)
        {
            movementValue -= value;
            endState = true;
        }
        return endState;
    }

    public int GetValue()
    {
        return movementValue;
    }
}
