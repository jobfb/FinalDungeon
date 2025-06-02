using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter; // This is the filter that will be used to determine what colliders are considered for collision detection.
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10]; // Array to hold colliders detected by the filter.

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //collision work/detection
        boxCollider.Overlap(filter, hits);  // look if there is some collision and put the results in the hits array
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            OnCollide(hits[i]); // Call the OnCollide method with the detected collider

            hits[i] = null; // Set the hit collider to null to clean up the array
        }
    }



    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollide was not implemented in " + this.name); 
    }
}