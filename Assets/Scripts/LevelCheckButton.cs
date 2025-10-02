using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheckButton : MonoBehaviour
{
    public GameObject parentOfObject;
    private ILevelCheckable subScript;
    public bool won = false;
    public GameObject checkButton;
    public Score score;

    public GameObject winPanel;

    public void checkCaller()
    {
        won = false;

        subScript = parentOfObject.GetComponentInChildren<ILevelCheckable>();
        if (subScript != null)
        {
            won = subScript.checker();
        }
        else
        {
            Debug.Log("Error: No ILevelCheckable script found in children of parentOfObject.");
        }

        if (won)
        {
            checkButton.SetActive(false);
            Debug.Log("button deactivated");

            if (winPanel != null)
            {
                winPanel.SetActive(true);
                Debug.Log("WinPanel activated.");
            }
            else
            {
                Debug.LogWarning("WinPanel is not assigned in the inspector.");
            }
        }

        Debug.Log("CheckButtonCALLED_LevelCheckButton");

        score.countScore(won);
    }

    public void RetryLevelFromWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //LevelComplete.i = 0;
        Score.lives = 3;
        //LevelLoad.intSaver = 0;
    }
}
