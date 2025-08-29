using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    [HideInInspector] public Animator anim;
    public Joystick joystick;
    private float movX;
    private StandaloneInputModule inputModule;
    public GameObject joy;

    public Transform Witch1Trns, Witch2Trns, Witch3Trns, Witch4Trns, Witch5Trns,
                     Witch6Trns, Witch7Trns, Witch8Trns, Witch9Trns, Witch10Trns;

    public GameObject end;

    [HideInInspector] public bool isMoving = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        inputModule = GetComponent<StandaloneInputModule>();
        anim.enabled = true;

        // ✅ Set spawn position
        switch (LevelLoad.intSaver)
        {
            case 1: transform.position = Witch1Trns.position; break;
            case 2: transform.position = Witch2Trns.position; break;
            case 3: transform.position = Witch3Trns.position; break;
            case 4: transform.position = Witch4Trns.position; break;
            case 5: transform.position = Witch5Trns.position; break;
            case 6: transform.position = Witch6Trns.position; break;
            case 7: transform.position = Witch7Trns.position; break;
            case 8: transform.position = Witch8Trns.position; break;
            case 9: transform.position = Witch9Trns.position; break;
            case 10: transform.position = Witch10Trns.position; break;
        }
    }

    void Update()
    {
        movX = joystick.Horizontal * speed; // ✅ Same as original

        if (isMoving)
        {
            // ✅ Only move forward (right side)
            if (joystick.Horizontal > 0.1f)
            {
                rb.linearVelocity = new Vector2(movX, rb.linearVelocity.y); // ✅ same speed handling
                transform.eulerAngles = new Vector3(0, 180, 0); // face right
                anim.SetBool("walk", true);
            }
            else
            {
                // stay idle
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                anim.SetBool("walk", false);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            anim.SetBool("walk", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("NPC"))
        {
            anim.SetBool("Wave", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            joystick.enabled = false;
            joy.SetActive(false);
            anim.enabled = false;
        }
        if (Collider.CompareTag("Book"))
        {
            isMoving = false;
            joystick.enabled = false;
            Debug.Log("Entered");
            joystick.HandleRange = 0;
            joystick.DeadZone = 100;

            StartCoroutine(FinalScene());
        }
    }

    IEnumerator FinalScene()
    {
        yield return new WaitForSeconds(3f);
        end.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.CompareTag("NPC"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            joy.SetActive(true);

            anim.enabled = true;
            joystick.enabled = true;
        }
    }
}
