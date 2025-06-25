using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct

    public int[] damagePoint= { 1, 2, 3, 4, 5, 6, 7, 8 }; // Amount of damage the weapon does
    public float[] pushForce = { 2.0f, 2.2f, 2.5f, 3.0f, 3.2f, 3.6f, 3.8f,4.0f }; // Amount of force applied to the target when hit

    // Upgrade struct
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;


    //swing
    private Animator anim;
    private float cooldown = 0.2f; // Time between swings
    private float lastSwing; // Time of the last swing 

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        // Check if the weapon can swing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time; // Update the last swing time
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return; // Ignore self hits
            }
            // Create a Damage object to apply damage
            Damage dmg = new Damage
            {
                origin = transform.position, // Set the origin to the weapon's position
                damageAmount = damagePoint[weaponLevel], // Set the damage amount
                pushForce = pushForce[weaponLevel] // Set the push force
            };

            // Apply damage to the target
            coll.SendMessage("ReceiveDamage", dmg); // Send the damage message to the target



        }
    }


    private void Swing()
    {
        anim.SetTrigger("Swing"); // Trigger the swing animation
    }

    public void UpgradeWeapon()
    {
        weaponLevel++; // Increment the weapon level
        spriteRenderer.sprite = GameManager.instance.weapon[weaponLevel]; // Update the weapon sprite
        GameManager.instance.ShowText("Weapon upgraded to level " + weaponLevel, 20, Color.green, transform.position, Vector3.zero, 2f);
    }
}