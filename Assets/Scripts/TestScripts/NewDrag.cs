using UnityEngine;

public class NewDrag : MonoBehaviour
{
    public bool drag;
    private float movementTime = 15f;
    private Vector3? movementDestination;
    private Vector3 initialPosition;
    public char NumberDef;
    private AudioSource buttonSound;

    private bool placedInSlot = false;
    private Holder lastHolder; // ✅ keep track of last hovered holder

    private void Start()
    {
        initialPosition = transform.position;
        NumberDef = this.GetComponent<SymbolDefinition>().Number;
        buttonSound = this.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        drag = true;
        placedInSlot = false;
        lastHolder = null; // reset
        ButtonClickAudio();
    }

    private void OnMouseUp()
    {
        drag = false;

        if (lastHolder != null && lastHolder.CanAccept(this)) // ✅ Only if type matches
        {
            lastHolder.AcceptDrop(gameObject, this);
            placedInSlot = true;
        }
        else
        {
            // ❌ Wrong holder or no holder → return home
            movementDestination = initialPosition;
            placedInSlot = false;
        }
    }

    private void Update()
    {
        if (drag)
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseWorldPos;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Holder holder = other.GetComponent<Holder>();
        if (holder != null)
        {
            lastHolder = holder; // ✅ mark last hovered holder
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Holder holder = other.GetComponent<Holder>();
        if (holder != null && holder == lastHolder)
        {
            lastHolder = null; // ✅ left the holder
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
