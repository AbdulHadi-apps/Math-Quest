using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawModifier : MonoBehaviour
{
    public Rigidbody2D leftside;
    public Rigidbody2D rightside;
    private float weightLeft;
    private float weightRight;
    private Transform currTrans;
    public float comeBackSpeed;
    private bool posiFiexer = true;
    private float timeCount = 0.0f;
    private float massMultiplier;
    public WeightSum weightScript;
    private LevelComplete levelCompleteScript;
    private bool won;

    [Header("UI")]
    public GameObject winPanel; // <-- Assign this in the Inspector

    void Start()
    {
        massMultiplier = weightScript.massMultiplier;
        levelCompleteScript = FindObjectOfType<LevelComplete>();
        won = false;

        if (winPanel != null)
        {
            winPanel.SetActive(false); // make sure it's hidden initially
        }
    }

    private void Update()
    {
        weightLeft = leftside.mass;
        weightRight = rightside.mass;
        currTrans = this.transform;

        if (weightLeft == weightRight && weightLeft > massMultiplier)
        {
            transform.rotation = Quaternion.Lerp(currTrans.rotation, Quaternion.identity, timeCount * comeBackSpeed);
            timeCount += Time.deltaTime;

            if (posiFiexer && !won)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                posiFiexer = false;
                won = true;

                levelCompleteScript.levelWon();

                if (winPanel != null)
                {
                    winPanel.SetActive(true); // <-- Show Win UI
                    Debug.Log("WinPanel activated from seesaw.");
                }
                else
                {
                    Debug.LogWarning("WinPanel not assigned in SeeSawModifier.");
                }
            }
        }
    }

    void setRotation()
    {
        transform.rotation = Quaternion.Lerp(currTrans.rotation, Quaternion.identity, timeCount * comeBackSpeed);
        timeCount += Time.deltaTime;

        if (posiFiexer)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            posiFiexer = false;
        }
    }
}
