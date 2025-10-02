using UnityEngine;

public class CharacterSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (SoundManager1.instance.isSoundOn)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
