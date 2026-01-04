using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBase : MonoBehaviour
{
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite pressed;


    public event Action OnButtonPress;
    public event Action OnButtonRelease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            transform.GetComponent<SpriteRenderer>().sprite = pressed;
            OnButtonPress?.Invoke();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            transform.GetComponent<SpriteRenderer>().sprite = normal;
            OnButtonRelease?.Invoke();
        }
    }


}
