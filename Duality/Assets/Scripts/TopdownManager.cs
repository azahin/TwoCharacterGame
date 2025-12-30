using UnityEngine;

public class TopdownManager : MonoBehaviour {
    public float gridSize = 0.5f;
    public static TopdownManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void SnapToGrid(Rigidbody2D rb) {
        if (rb == null) return;

        Vector2 targetPos = new Vector2(
            Mathf.Round(rb.position.x / gridSize) * gridSize,
            Mathf.Round(rb.position.y / gridSize) * gridSize
        );
        rb.position = targetPos;
        rb.linearVelocity = Vector2.zero;
    }
}