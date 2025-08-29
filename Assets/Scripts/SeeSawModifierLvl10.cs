using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawModifierLvl10 : MonoBehaviour
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
    public WeightCalLeft weightScript;
    private LevelComplete levelCompleteScript;
    private bool won;

    [Header("UI")]
    public GameObject winPanel; // <-- Drag your WinPanel here in the inspector

    void Start()
    {
        massMultiplier = weightScript.massMultiplier;
        levelCompleteScript = FindObjectOfType<LevelComplete>();
        won = false;

        if (winPanel != null)
        {
            winPanel.SetActive(false); // Hide WinPanel at the start
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
                    winPanel.SetActive(true); // Show WinPanel
                    Debug.Log("WinPanel activated in Level 10.");
                }
                else
                {
                    Debug.LogWarning("WinPanel is not assigned in SeeSawModifierLvl10.");
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
