using UnityEngine;

public class cameraMotor : MonoBehaviour
{
    public Transform lookat;
    public float boundX = 0.30f; // how far the player can go on the x axis before the camera starts moving
    public float boundY = 0.15f;// how far the player can go on the Y axis before the camera starts moving

    private void LateUpdate() // get called later than update and fixedUpdate, so the player has already moved
    {
        Vector3 delta = Vector3.zero; // how much the camera will move

        // check if the player is outside the bounds on the x axis
        float deltaX = lookat.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookat.position.x) // if the player is to the right of the camera
            {
                delta.x = deltaX - boundX; // move the camera to the right
            }
            else // if the player is to the left of the camera
            {
                delta.x = deltaX + boundX; // move the camera to the left
            }   
        }

        // check if the player is outside the bounds on the y axis
        float deltaY = lookat.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookat.position.y) // if the player is above the camera
            {
                delta.y = deltaY - boundY; // move the camera up
            }
            else // if the player is below the camera
            {
                delta.y = deltaY + boundY; // move the camera down
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0); // move the camera
    }
   






}
