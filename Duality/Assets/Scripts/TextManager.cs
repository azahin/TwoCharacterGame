using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject textboxPrefab;
    private float textTime = 5.0f;
    private GameObject textboxInstance;
    private float textCountdown;
    private readonly Queue<string> textQueue = new Queue<string>();

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

        if (!textboxInstance && textQueue.Count > 0) {
            ShowText();
            textCountdown = textTime;
        }
    }

    private void ShowText() {
        textboxInstance = Instantiate(textboxPrefab, transform);
        textboxInstance
            .GetComponentInChildren<TextMeshProUGUI>()
            .text = textQueue.Dequeue();
    }

    public void QueueText(string newText)  {
        if (string.IsNullOrEmpty(newText))
            return;
        textQueue.Enqueue(newText);
    }
}
