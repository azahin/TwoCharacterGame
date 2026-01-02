using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LeverBase : MonoBehaviour
{
    //[SerializeField] private DoorBase door;
    [SerializeField] private bool canToggle;
    [SerializeField] private bool oneTime;
    [SerializeField] private bool inverse;

    public event Action OnLeverOn;
    public event Action OnLeverOff;

    private int isActive = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canToggle) 
        {
            
            ToggleLever(isActive);
            setToggleAbility();
        }
    }

    private void setToggleAbility()
    {
        if (oneTime)
        {
            canToggle = false;
        }
    }

    private void ToggleLever(int state)
    {
        if (state == 1 && !inverse)
        {
            OnLeverOff?.Invoke();
            isActive = 0;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        }
        if (state == 0 && !inverse)
        {
            OnLeverOn?.Invoke();
            isActive = 1;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        }
        if (state == 0 && inverse)
        {

            OnLeverOff?.Invoke();
            isActive = 0;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        }
        if (state == 1 && inverse)
        {
            OnLeverOn?.Invoke();
            isActive = 1;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        }

    }

    
}
