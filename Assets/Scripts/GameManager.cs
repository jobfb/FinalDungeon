using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    //resources
    public List<Sprite> playerSprites; // List of player sprites
    public List<Sprite> weapon; // List of weapons
    public List<int> weaponPrices;
    public List<int> xpTable; // List of XP values for leveling up

    //references
    public Player player; // Reference to the player script

    //logic
    public int pesos; // Player's currency
    public int experience; // Player's experience points


    //save and load state
    public void SaveState()
    {       
        Debug.Log("Saving game state...");
    }

    public void LoadState()
    {
        Debug.Log("Loading game state...");

    }

}
