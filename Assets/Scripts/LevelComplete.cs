using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public bool won;
    public GameObject[] levels;
    public static int i = 0;
    public ParticleSystem Celebration;
    public ParticleSystem Celebration2;
    public AudioSource VictoryAudio;
    public AudioSource LevelCompletion;
    public AudioSource NextLevelButtonSound;
    public GameObject Fade;
    private LevelsFade levelsFade;
    public GameObject nextButton;
    public GameObject WindowChanger;
    public GameObject checkButton;
    public GameObject winPanel;

    void Start()
    {
        levelsFade = Fade.GetComponent<LevelsFade>();
        won = false;
        StartFirstLevel();
        if (LevelLoad.intSaver == 1)
        {
            i = 0;
        }
        Debug.Log("LevelVariable_levelcomplete: " + i);
    }

    public void levelWon()
    {
        won = true;
        if(SoundManager1.instance.isSoundOn)
        {
            LevelCompletion.Play();
            Celebration.Play();
            Celebration2.Play();
            VictoryAudio.Play();
        }    
        nextButton.SetActive(true);
        winPanel.SetActive(true);
        Debug.Log("Hello");
    }

    private void levelChanger()
    {
        levels[i].SetActive(false);

        if (i != 2 && i != 5 && i != 9)
        {
            levels[i + 1].SetActive(true);
        }

        i += 1;
        if (i > 9)
        {
            Destroy(this);
        }
    }

    private void StartFirstLevel()
    {
        levels[i].SetActive(true);
        StartCoroutine(CheckButtonOnDelay(0.1f));
    }

    IEnumerator LevelChangeDelay()
    {
        yield return new WaitForSeconds(1f);
        levelChanger();
    }

    public void Newbutton()
    {
        levelsFade.LoadNext();
        NextLevelButtonSound.Play();

        if (i != 2 && i != 5 && i != 9)
        {
            StartCoroutine(LevelChangeDelay());
        }
        else
        {
            levelChanger();
        }

        Debug.Log("level" + i);

        if (i != 1 && i != 6 && i != 8)
        {
            StartCoroutine(CheckButtonOnDelay(1f));
        }
    }

    IEnumerator CheckButtonOnDelay(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        checkButton.SetActive(true);
    }

    public void RetryCurrentLevel()
    {
        SceneManager.LoadScene(4);  // Reload Levels scene
        LevelLoad.intSaver = 0;
        Score.lives = 3;
    }
}
