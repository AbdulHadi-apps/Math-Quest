using UnityEngine;

public class MainSound : MonoBehaviour
{
    [SerializeField] private AudioSource sourceSong;
    public static MainSound instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Make the GameObject persistent
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    private void Start()
    {
        if (sourceSong != null && !sourceSong.isPlaying)
        {
            sourceSong.Play();
        }
    }

    private void Update()
    {
        if (sourceSong != null)
        {
            sourceSong.volume = PlayerPrefs.GetFloat("musicVolume", 1f); // Default to 1f if not set
        }
    }
}
