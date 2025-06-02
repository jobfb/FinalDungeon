using UnityEngine;

public class Player : Fighter
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D component missing on this GameObject.");
        }
    }

    private void FixedUpdate() // update every frame
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        moveDelta = new Vector2(x, y);

        // Swap sprite direction
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //checks if the player hits something in the y direction, by casting a box in the y direction
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));
        if (hit.collider == null) //if the player is not hitting anything in the y direction
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        //checks if the player hits something in the X direction, by casting a box in the x direction
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null) //if the player is not hitting anything in the y direction
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0,0);
        }

    }
}