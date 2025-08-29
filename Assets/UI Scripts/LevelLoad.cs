using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public GameObject dial;
    private DialogueManager dialogueManager;
    public Animator transition;
    [SerializeField] private float waitTime = 2f;

    public static int intSaver = 0;
    private bool intchanger = true;

    void Start()
    {
        dialogueManager = dial.GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (dialogueManager != null && dialogueManager.nextScene && intchanger)
        {
            LoadNext();
        }
    }

    public void LoadNext()
    {
        if (intchanger)
        {
            intSaver += 1;
            intchanger = false;
        }

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelIndex);
    }

    // Call this on Retry to reset static values
    public static void ResetLevelLoadState()
    {
        intSaver = 0;
        // Add other static resets if needed
    }
}
