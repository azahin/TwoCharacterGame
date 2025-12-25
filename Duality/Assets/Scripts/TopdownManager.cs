using UnityEngine;

public class TopdownManager : MonoBehaviour
{
    [SerializeField] private float gridSize = 0.5f;
    public static TopdownManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void SnapToGrid(Transform obj)
    {
        if (obj == null) return;

        Vector3 targetPos = new Vector3(
            Mathf.Round(obj.position.x / gridSize) * gridSize,
            obj.position.y,
            Mathf.Round(obj.position.z / gridSize) * gridSize
        );
        obj.position = Vector3.Lerp(obj.position, targetPos, 10 * Time.fixedDeltaTime);
    }
}