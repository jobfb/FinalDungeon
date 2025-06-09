using UnityEngine;

public class EnemyHitbox : Collidable
{
    //damage
    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name  == "Player" && coll.tag=="Fighter")
        {
            // create a new damage object before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damage, // Set the damage amount
                origin = transform.position, // Set the origin to the weapon's position
                pushForce = pushForce // Set the push force
            };

            // Apply damage to the target
            coll.SendMessage("ReceiveDamage", dmg); // Send the damage message to the target
        }
    }
}
