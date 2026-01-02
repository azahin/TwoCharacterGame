using UnityEngine;

public class DoorBase : MonoBehaviour
{
    [SerializeField] private bool startingState = true; //True for closed, false for open 
    [SerializeField] private ButtonBase button;
    [SerializeField] private LeverBase lever;
    private void OnEnable()
    {
        button.OnButtonPress += Open;
        button.OnButtonRelease += Close;
        lever.OnLeverOn += Open;
        lever.OnLeverOff += Close;
        if (!startingState)
        {
            Open();
        }
    }

    private void OnDisable()
    {
        button.OnButtonPress -= Open;
        button.OnButtonRelease -= Close;
        lever.OnLeverOn -= Open;
        lever.OnLeverOff -= Close;
    }

    public void Open()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void Close()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
