using UnityEngine;

public class CoinBase : MonoBehaviour
{
    [SerializeField] private BarBase bar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            bar.AddValue();
           
        }
    }
}
