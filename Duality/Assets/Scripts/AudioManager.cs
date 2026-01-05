using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip step;
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip button;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip portal;
    [SerializeField] private AudioClip lever;
    [SerializeField] private AudioClip music;

    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        else { Destroy(gameObject); }
    }

    private void Start() {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.volume = 0.2f;
        musicSource.Play();
    }

    public void PlaySound(string sound) {
        sfxSource.pitch = Random.Range(0.95f, 1.05f);
        switch (sound) {
            case "step":
                sfxSource.PlayOneShot(step, 0.2f);
                break;
            case "coin":
                sfxSource.PlayOneShot(coin, 0.2f);
                break;
            case "button":
                sfxSource.PlayOneShot(button, 0.2f);
                break;
            case "jump":
                sfxSource.PlayOneShot(jump, 0.2f);
                break;
            case "portal":
                sfxSource.PlayOneShot(portal, 0.2f);
                break;
            case "lever":
                sfxSource.PlayOneShot(lever, 0.2f);
                break;
            default:
                Debug.LogWarning($"Unknown sound: {sound}");
                break;
        }
        sfxSource.pitch = 1.0f;
    }
}
