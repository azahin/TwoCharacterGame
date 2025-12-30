using UnityEngine;
using System.Collections;

public class TopdownManager : MonoBehaviour
{
    private float gridSize = 0.5f;
    [SerializeField] private float moveDuration = 0.6f;
    public static TopdownManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void SnapToGrid(Transform obj)
    {
        if (obj == null) return;

        Vector2 targetPos = new Vector2(
            Mathf.Round(obj.position.x / gridSize) * gridSize,
            Mathf.Round(obj.position.y / gridSize) * gridSize
        );
        obj.position = Vector2.Lerp(obj.position, targetPos, 10 * Time.deltaTime);
    }

    public IEnumerator MoveCell(Transform obj, Vector2 direction)
    {
        Vector2 startPos = obj.position;
        Vector2 targetPos = startPos + direction * gridSize;

        float moveTime = 0.0f;
        while (moveTime < moveDuration)
        {
            obj.position = Vector2.Lerp(startPos, targetPos, Mathf.Pow(moveTime / moveDuration, 0.3f));
            moveTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        SnapToGrid(obj);
    }
}