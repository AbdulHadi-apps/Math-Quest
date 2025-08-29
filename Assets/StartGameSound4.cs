using UnityEngine;
using System.Collections;

public class StartGameSound4 : MonoBehaviour
{
    public AudioClip[] startGameSFX;
    public AudioSource startgame;

    void Start()
    {
        if (SoundManager1.instance.isSoundOn && startGameSFX.Length > 0)
        {
            PlayStartGameSoundOnce();
        }
    }

    void PlayStartGameSoundOnce()
    {
        int randomIndex = Random.Range(0, startGameSFX.Length);
        startgame.clip = startGameSFX[randomIndex];
        startgame.Play();
    }
}
