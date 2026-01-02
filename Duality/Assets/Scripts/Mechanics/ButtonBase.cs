using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBase : MonoBehaviour
{
    [SerializeField] private float pressDis = 0.1f;


    public event Action OnButtonPress;
    public event Action OnButtonRelease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y - (GetComponent<Renderer>().bounds.size.y * pressDis), transform.position.z);
            OnButtonPress?.Invoke();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (GetComponent<Renderer>().bounds.size.y * pressDis), transform.position.z);
            OnButtonRelease?.Invoke();
        }
    }


}
