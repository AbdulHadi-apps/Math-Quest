using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 20f;
    public float moveDistance = 200f; // How far cloud moves from its original position

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.localPosition;
        targetPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        // Move cloud toward target position
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, speed * Time.deltaTime);

        // When target is reached, reverse direction
        if (Vector3.Distance(transform.localPosition, targetPos) < 0.1f)
        {
            movingRight = !movingRight;
            targetPos = startPos + (movingRight ? Vector3.right : Vector3.left) * moveDistance;
        }
    }
}
