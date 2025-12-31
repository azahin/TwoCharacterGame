using UnityEngine;

public class DoorBase : MonoBehaviour
{
    
    public void Open()
    {
        this.gameObject.SetActive(false);
    }

    public void Close()
    {
        this.gameObject?.SetActive(true);  
    }
}
