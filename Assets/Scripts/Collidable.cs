using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private List<Collider2D> hits = new List<Collider2D>(); // Use a List instead of a fixed array

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        hits.Clear(); // Clear the list before each update
        boxCollider.Overlap(filter, hits); // Look for collisions and store the results in the hits list

        foreach (var hit in hits) // Iterate over the detected hits
        {
            if (hit == null)
            {
                continue;
            }

            OnCollide(hit); // Call the OnCollide method with the detected collider
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollide was not implemented in " + this.name);
    }
}
