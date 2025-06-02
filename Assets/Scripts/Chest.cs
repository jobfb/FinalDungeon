using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest; // Sprite to show when the chest is empty
    public int pesosAmount = 5; // Amount of pesos to give when collected


    protected override void onCollect()
    {
        if(!collected)
        {
            collected = true; // mark as collected
            GetComponent<SpriteRenderer>().sprite = emptyChest; // Change the sprite to the empty chest
            GameManager.instance.ShowText("+" + pesosAmount + " Pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f); // Show floating text
        }
    }
}