using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel; // Assign your Pause Menu UI panel here

    private bool isPaused = false;

    // Optional: allow ESC to toggle pause (for testing in editor)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void RetryScene()
    {
        Time.timeScale = 1f; // Always reset time scale before scene reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); // Your Home scene index (e.g., UI)
    }
}
