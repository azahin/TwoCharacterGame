using Unity.VisualScripting;
using UnityEngine;

public class KeyBase : MonoBehaviour
{
    [SerializeField] private DoorBase door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            door.Open();
            this.gameObject.SetActive(false);
            Debug.Log("Here");
        }

    }
}
