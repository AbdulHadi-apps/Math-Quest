using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldHag : MonoBehaviour
{
    public GameObject uiObject;
    public DialogueTrigger dialogueTrigger;
    public GameObject boardText; // 👈 Add reference to the board text

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        uiObject.SetActive(false);

        if (boardText != null)
            boardText.SetActive(false); // 👈 Make sure board text is off at start

        if (LevelLoad.intSaver == 1)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.CompareTag("Player"))
        {
            uiObject.SetActive(true);
            if (boardText != null)
                boardText.SetActive(true); // 👈 Show board text when dialogue is triggered

            dialogueTrigger.TriggerDialogue();
        }
    }

    void Update()
    {
        if (LevelLoad.intSaver == 2)
        {
            Destroy(gameObject);
        }
    }
}
