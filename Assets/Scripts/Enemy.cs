using UnityEngine;
using UnityEngine.UI;

public class Enemy : Mover
{
    //Experience
    public int xpValue = 1;

    //logic
    public float triggerLenght = 1;

    public float chaseLenght = 5;
    public bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //hitbox
    public ContactFilter2D filter; // This is the filter that will be used to determine what colliders are considered for collision detection.

    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // check if the player is in range
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            if(Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
                chasing = true; // if the player is close enough, start chasing

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }
        // check if the enemy is colliding with the player
        collidingWithPlayer = false;
        boxCollider.Overlap(filter, hits);  // look if there is some collision and put the results in the hits array
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            if (hits[i].tag == "Fighter" && hits[i].name == "Player" )
            {
                collidingWithPlayer = true;
            }
            hits[i] = null; // Set the hit collider to null to clean up the array
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience+=xpValue;
        GameManager.instance.ShowText("+ " + xpValue + " XP", 30, Color.magenta, transform.position, Vector3.up * 25, 1.0f);
    }
    
}