using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.sceneLoaded += LoadState;
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
        string s = "";
        s += "0" + "|";// Placeholder for future save data
        s += pesos.ToString() + "|"; // Save pesos
        s += experience.ToString() + "|"; // Save experience
        s += "0"; // Placeholder for future save data
        PlayerPrefs.SetString("SaveState", s); // Save the game state as a string

        //  Debug.Log("Saving game state...");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
            {
            return; // Check if save state exists
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');// split string
        // change player skin
        //Amount of pesos
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);

        Debug.Log("Loading game state...");

    }

}
