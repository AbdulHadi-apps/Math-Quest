using UnityEngine;

namespace GameVanilla.Core
{
    /// <summary>
    /// This class manages the background music of the game.
    /// </summary>
    public class BackgroundMusic : MonoBehaviour
    {
        private static BackgroundMusic instance;

        private AudioSource audioSource;

        // Array of background music clips
        public AudioClip[] backgroundClips;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            var music = PlayerPrefs.GetInt("music_enabled");
            audioSource.mute = music == 0;

            if (backgroundClips.Length > 0)
            {
                // Pick a random clip
                var randomClip = backgroundClips[Random.Range(0, backgroundClips.Length)];
                audioSource.clip = randomClip;
                audioSource.loop = true; // Optional: loop background music
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("No background music clips assigned.");
            }
        }
    }
}
