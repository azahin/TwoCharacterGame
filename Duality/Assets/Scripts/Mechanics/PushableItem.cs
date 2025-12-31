using UnityEngine;

public class PushableItem : MonoBehaviour {
    private Rigidbody2D rb;
    public bool gridLocked = false;
    public bool teleportable = true;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (gridLocked && rb.linearVelocity.magnitude <= 0.05) {
            TopdownManager.Instance.SnapToGrid(rb);
        }

        rb.linearVelocity = new Vector2(
            0,
            gridLocked ? 0:rb.linearVelocity.y
        );
    }

    public void ToTopdown() {
        gridLocked = true;
        rb.gravityScale = 0.0f;
        rb.mass = 0.01f;
    }

    public void ToSidescroll() {
        gridLocked = false;
        rb.gravityScale = 1.0f;
        rb.mass = 0.2f;
    }
}