using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FloatingText
{

    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void shown()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active); // activate the GameObject
    }

    public void hide()
    {
        active = false;
        go.SetActive(active); // deactivate the GameObject
    }

    public void UpdateFloatingText()
    {
        if (!active)
        {
            return;
        }
        //     10       -  7      >      2   hide
        if (Time.time - lastShown > duration)
        {
            hide();
        }

        go.transform.position += motion * Time.deltaTime;
    }   
}
