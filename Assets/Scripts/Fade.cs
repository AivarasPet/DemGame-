using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;
    public int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1, timer=400;

    void Update ()
    {
        timer = timer - 1;
        if (timer == 0) Destroy(gameObject);
        if (alpha == 0) fadeDir = 1;
    }

   void OnGUI ()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
 
}
