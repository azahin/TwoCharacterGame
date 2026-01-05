using Unity.VisualScripting;
using UnityEngine;

public class PortalBase : MonoBehaviour
{
    [SerializeField] private Transform portalTarget;
    [SerializeField] private string dialogue = "";

    private void OnTriggerEnter2D(Collider2D collision) {
        PushableItem item = collision.gameObject.GetComponent<PushableItem>();
        if (item && item.teleportable) {
            item.teleportable = false;
            item.transform.position = portalTarget.position;
            SwitchPerspective(item);
            TextManager.Instance.QueueText(dialogue);
            dialogue = "";
            AudioManager.Instance.PlaySound("portal");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PushableItem item = collision.gameObject.GetComponent<PushableItem>();
        if (item && item.teleportable) {
            item.teleportable = true;
        }
    }

    private void SwitchPerspective(PushableItem item) {
        if (item.transform.position.x > 0) {
            item.ToSidescroll();
        } else {
            item.ToTopdown();
        }
    }
}
