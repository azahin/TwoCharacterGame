using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LeverBase : MonoBehaviour
{
    [SerializeField] private DoorBase door;

    private int isActive = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Debug.Log(this.transform.rotation.z);
            ToggleLever(isActive);
        }
    }



    private void ToggleLever(int state)
    {
        if (state == 1)
        {
            door.Close();
            isActive = 0;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        }
        else
        {
            door.Open();
            isActive = 1;
            transform.rotation = transform.rotation * Quaternion.Euler(0f, 0f, 180f);
        }
        
    }

    
}
