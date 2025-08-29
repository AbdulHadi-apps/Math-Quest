using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Animator anim;
    public bool nextScene;

    [Header("Audio")]
    public AudioSource dialogueAudioSource; // Assign in Inspector
    public AudioClip[] dialogueClips;       // Multiple clips

    void Start()
    {
        sentences = new Queue<string>();
        nextScene = false;
    }

    public void startDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);
        sentences.Clear();

        // ✅ Only play if sound is ON in SoundManager1
        if (SoundManager1.instance != null && SoundManager1.instance.isSoundOn)
        {
            if (dialogueAudioSource != null && dialogueClips.Length > 0)
            {
                int index = Random.Range(0, dialogueClips.Length); // pick random
                dialogueAudioSource.PlayOneShot(dialogueClips[index]);
            }
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        displayNext();
    }

    public void displayNext()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (char letter in sentence.ToCharArray())
        {
            yield return null;
        }
    }

    void endDialogue()
    {
        anim.SetBool("IsOpen", false);
        nextScene = true;
    }
}
