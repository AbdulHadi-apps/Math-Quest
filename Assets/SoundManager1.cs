using UnityEngine;

public class SoundManager1 : MonoBehaviour
{
    public static SoundManager1 instance;

    public bool isSoundOn = true;

    [Tooltip("Assign AudioClips that you want to play (e.g. button click, explosion, etc.)")]
    public AudioClip[] soundClips;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
            audioSource = gameObject.AddComponent<AudioSource>();

            // ✅ Load saved sound state
            isSoundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
            ToggleSound(isSoundOn);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleSound(bool enabled)
    {
        isSoundOn = enabled;
        audioSource.mute = !enabled;

        // Optional: adjust global volume too
        //AudioListener.volume = enabled ? 1 : 0;
    }

    /// <summary>
    /// Plays a sound clip from the array by index.
    /// </summary>
    public void PlaySound(int index)
    {
        if (isSoundOn && index >= 0 && index < soundClips.Length && soundClips[index] != null)
        {
            audioSource.PlayOneShot(soundClips[index]);
        }
    }
}
