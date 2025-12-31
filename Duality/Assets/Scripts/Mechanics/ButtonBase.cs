using System;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBase : MonoBehaviour
{
    [SerializeField] private float pressDis = 0.1f;

    [SerializeField] private DoorBase door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y - (GetComponent<Renderer>().bounds.size.y * pressDis), transform.position.z);
            door.Open();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (GetComponent<Renderer>().bounds.size.y * pressDis), transform.position.z);
            door.Close();
        }
    }


}
