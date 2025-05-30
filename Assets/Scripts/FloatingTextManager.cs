using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textPrefab;
    public GameObject textContainer;



    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts) // iterate through all FloatingText instances
        {
            txt.UpdateFloatingText(); // update each FloatingText instance
        }
    }

    public void Show(string msg,int fontSize,Color color,Vector3 position,Vector3 motion,float duration)
    {
        FloatingText floatingText = GetFloatingText(); // get a FloatingText instance from the pool or create a new one if needed

        floatingText.txt.text = msg; // set the text message
        floatingText.txt.fontSize = fontSize; // set the font size
        floatingText.txt.color = color; // set the text color
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); // transform world position to screen position and set it as the position of the GameObject
        floatingText.motion = motion; // set the motion vector
        floatingText.duration = duration; // set the duration for how long the text should be shown
        floatingText.shown(); // mark the text as shown, activating it and setting the last shown time

    }

    private FloatingText GetFloatingText() // funtions that returns a FloatingText instance
    {
        FloatingText txt = floatingTexts.Find(t => !t.active); // gets the floating text array and try to find one thats not active

        if (txt == null)
        {
            txt = new FloatingText(); // create a new FloatingText instance
            txt.go = Instantiate(textPrefab, textContainer.transform); // instantiate the prefab and set it as a child of the container
            txt.txt = txt.go.GetComponent<Text>();// get the Text component from the instantiated GameObject

            floatingTexts.Add(txt); // add the new FloatingText instance to the list
        }

        return txt;
    }
}
