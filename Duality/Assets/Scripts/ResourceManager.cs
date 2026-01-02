using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int movementValue = 0;
    public static ResourceManager Instance { get; private set; }

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

    public bool UseValue()
    {
        bool endState = false;
        if (movementValue >= 1)
        {
            movementValue -= 1;
            endState = true;
        }
        return endState;
    }

    public int GetValue()
    {
        return movementValue;
    }
}
