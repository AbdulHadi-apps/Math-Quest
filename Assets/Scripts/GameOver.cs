using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;

    public void gameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void ButtonGameOver()
    {
        GameOverPanel.SetActive(false);
    }

    public void ButtonRestart()
    {
        //SceneManager.LoadScene(4);  // Reload Levels scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // LevelLoad.intSaver = 0;
        // LevelComplete.i = 0;
        Score.lives = 3;
    }

    public void ButtonHome()
    {
        Score.lives = 3;
        SceneManager.LoadScene(2);
    }
}
