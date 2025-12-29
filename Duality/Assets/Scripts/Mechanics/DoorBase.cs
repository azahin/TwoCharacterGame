using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorBase : MonoBehaviour
{
    [SerializeField] GameObject player;

    private Vector3 openPos;
    private Vector3 closePos;

    private float yOffset = 1.5f;

    private void Awake()
    {
        closePos = transform.position;
        openPos = transform.position;
        openPos.y += player.GetComponent<Renderer>().bounds.size.y * yOffset;
    }
    public void Open()
    {
        transform.position = openPos;
    }

    public void Close()
    {
        transform.position = closePos;
    }
}
