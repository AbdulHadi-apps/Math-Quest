using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDrag : MonoBehaviour
{
    public bool drag;
    private float movementTime = 15f;
    private Vector3? movementDestination;
    private Vector3 initialPosition;
    private char NumberDef;
    private AudioSource buttonSound;

    private bool placedInSlot = false; // ✅ Track if correctly placed

    private void Start()
    {
        initialPosition = transform.position;
        NumberDef = this.GetComponent<SymbolDefinition>().Number;
        buttonSound = this.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        drag = true;
        placedInSlot = false; // picking it up again → not in slot
        ButtonClickAudio();
    }

    private void OnMouseUp()
    {
        drag = false;

        // ✅ If no valid slot, return to start
        if (!placedInSlot)
        {
            movementDestination = initialPosition;
        }
    }

    private void Update()
    {
        if (drag)
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(MousePos);
        }
    }

    private void FixedUpdate()
    {
        if (movementDestination.HasValue)
        {
            if (drag)
            {
                movementDestination = null;
                return;
            }

            if (Vector3.Distance(transform.position, movementDestination.Value) < 0.01f)
            {
                transform.position = movementDestination.Value;
                movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (NumberDef == '+' || NumberDef == '-' || NumberDef == 'x')
        {
            if (other.CompareTag("DropSlotSigns"))
            {
                movementDestination = other.transform.position;
                placedInSlot = true; // ✅ Mark as placed
            }
        }
        else
        {
            if (other.CompareTag("DropSlot"))
            {
                movementDestination = other.transform.position;
                placedInSlot = true; // ✅ Mark as placed
            }
        }
    }

    public void returnToOriginalPlace()
    {
        movementDestination = initialPosition;
        placedInSlot = false;
    }

    private void ButtonClickAudio()
    {
        if (buttonSound != null)
            buttonSound.Play();
    }
}
