using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LeverBase : MonoBehaviour
{

    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

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
            transform.GetComponent<SpriteRenderer>().sprite = off;

        }
        if (state == 0 && !inverse)
        {
            OnLeverOn?.Invoke();
            isActive = 1;
            transform.GetComponent<SpriteRenderer>().sprite = on;

        }
        if (state == 0 && inverse)
        {

            OnLeverOff?.Invoke();
            isActive = 0;
            transform.GetComponent<SpriteRenderer>().sprite = off;

        }
        if (state == 1 && inverse)
        {
            OnLeverOn?.Invoke();
            isActive = 1;
            transform.GetComponent<SpriteRenderer>().sprite = on;

        }

    }

    
}
