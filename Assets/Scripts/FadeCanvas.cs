using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;
    public int drawDepth = -1000;
    private float alpha = 0f;
    private int fadeDir = -1, timer = 300;
    private bool gui=false, a;

    void Update()
    {
        timer = timer - 1;
        Debug.Log(alpha);
        if (timer == 0) gui = true; a = true;
        if (a == true) alpha = 1.0f;
        if (alpha < 1.0f) a = false;

    }
    
    void OnGUI()
    {
        if (gui == true)
        {
            

            alpha += fadeDir * fadeSpeed * Time.deltaTime;

            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }
        
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

}
