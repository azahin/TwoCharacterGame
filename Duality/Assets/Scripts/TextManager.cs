using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject textboxPrefab;
    [SerializeField] private float textTime;
    private GameObject textboxInstance;
    private float textCountdown;

    public static TextManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Update() {
        textCountdown -= Time.deltaTime;
        if (textCountdown <= 0.0f) {
            textCountdown = 0.0f;
            Destroy(textboxInstance);
            textboxInstance = null;
        }
    }

    public void ShowText(string newText) {
        Destroy(textboxInstance);
        textboxInstance = null;
        textboxInstance = Instantiate(textboxPrefab, transform);
        textboxInstance.GetComponentInChildren<TextMeshProUGUI>().text = newText;
        textCountdown = textTime;
    }
}
