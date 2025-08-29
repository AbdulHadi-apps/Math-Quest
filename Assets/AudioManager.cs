using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSource;

    [Header("Background Music Clips")]
    public AudioClip[] bgMusicClips;

    public bool isMusicOn = true; // This will track state

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true;

            // ✅ Load saved music state
            isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

            if (isMusicOn)
                PlayRandomMusic();
            else
                audioSource.Stop();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void PlayRandomMusic()
    {
        if (bgMusicClips.Length == 0) return;

        AudioClip randomClip = bgMusicClips[Random.Range(0, bgMusicClips.Length)];
        audioSource.clip = randomClip;
        audioSource.Play();
    }

    public void SetMusic(bool isOn)
    {
        isMusicOn = isOn;

        if (isOn && !audioSource.isPlaying)
            PlayRandomMusic();
        else if (!isOn && audioSource.isPlaying)
            audioSource.Pause(); // Or Stop()

        // ✅ Save new music state
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool IsMusicPlaying()
    {
        return audioSource.isPlaying;
    }
}
