using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public int soundIndex = 0; // index in SoundManager.soundClips

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (SoundManager1.instance != null)
            SoundManager1.instance.PlaySound(soundIndex);
    }
}
