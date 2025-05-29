using UnityEngine;
using UnityEngine.SceneManagement;

public class Portall : Collidable
{
    public string[] sceneNames; // Array of scene names to teleport to

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //teleport the player
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
