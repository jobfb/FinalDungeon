using UnityEngine;

public class Collectable : Collidable
{
    //logic
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            onCollect();
        }
    }

    protected virtual void onCollect()
    {
        collected = true;
    }
}
