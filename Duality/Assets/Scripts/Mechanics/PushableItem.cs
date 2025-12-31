using UnityEngine;

public class PushableItem : MonoBehaviour {
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (rb.linearVelocity.magnitude <= 0.05) {
            TopdownManager.Instance.SnapToGrid(rb);
        }
    }
}