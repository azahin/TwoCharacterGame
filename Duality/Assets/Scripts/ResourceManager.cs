using Unity.VisualScripting;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int movementValue = 0;
    public static ResourceManager Instance { get; private set; }

    [SerializeField] private int increase = 1;

    public event Action movementValueChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        else { Destroy(gameObject); }
    }

    public void AddValue()
    {
        movementValue += increase;
        if (movementValue > 50) { movementValue = 50; }
        movementValueChanged?.Invoke();
    }

    public bool UseValue()
    {
        bool endState = false;
        if (movementValue >= 1)
        {
            movementValue -= 1;
            endState = true;
            movementValueChanged?.Invoke();
        }
        return endState;
    }

    public int GetValue()
    {
        return movementValue;
    }
}
