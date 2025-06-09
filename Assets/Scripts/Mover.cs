using UnityEngine;
using UnityEngine.Rendering;

public abstract class Mover : Fighter
{

    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.8f;
    protected float xSpeed = 1.0f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D component missing on this GameObject.");
        }
    }

 

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset MoveDelta
        moveDelta = new Vector3 (input.x * xSpeed, input.y *ySpeed,0);

        // Swap sprite direction
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //add push vector if any
        moveDelta += pushDirection;

        //reduce push vector  every frame base off the recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //checks if the player hits something in the y direction, by casting a box in the y direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null) //if the player is not hitting anything in the y direction
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        //checks if the player hits something in the X direction, by casting a box in the x direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null) //if the player is not hitting anything in the y direction
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
