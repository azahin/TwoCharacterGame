using Unity.VisualScripting;
using UnityEngine;

public class PortalBase : MonoBehaviour
{
    [SerializeField] private GameObject newBox;

    [SerializeField] private GameObject portalExit;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Box"))
        {
            Destroy(collision.gameObject);

            Instantiate(newBox, portalExit.transform.position, portalExit.transform.rotation);
        }
}
}
