using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoints = 10; // Amount of hit points the fighter has
    public int maxHitPoints = 10; // Maximum hit points the fighter can have  
    public float pushRecoverySpeed = 0.2f; // Speed at which the fighter recovers from being pushed

   //imunity
   protected float immuneTime = 1.0f; // Time the fighter is immune to damage after being hit
    protected float lastImmune; // Time of the last hit

    //psuh
    protected Vector3 pushDirection; // Direction the fighter is being pushed

    //death/receive damage

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;// Reset time to the last immune time
            hitPoints -= dmg.damageAmount; // Reduce hit points by the damage amount
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce; // Calculate the push direction

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f); // Show damage text

            if (hitPoints <= 0)
            {
                hitPoints = 0; // Ensure hit points do not go below zero
                Death();
            }

        }
    }
    protected virtual void Death()
    {

    }
}
