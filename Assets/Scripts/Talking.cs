using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talking : MonoBehaviour {
    public bool canTalk;
    private Canvas label;
    private Text tekstas;
    private Image panelis;
	// Use this for initialization
	void Start () {
        label = gameObject.GetComponentInChildren<Canvas>();
        tekstas = GameObject.Find("DialogueText").GetComponent<Text>();
        panelis = GameObject.Find("DialoguePanel").GetComponent<Image>();

        label.enabled = false; tekstas.enabled = false; panelis.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(canTalk)
        {
            if (Input.GetKey(KeyCode.E)) ShowDialogue();
            if (Input.GetKey(KeyCode.Space)) QuitDialogue();
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") { canTalk = true; label.enabled = true; }
    }
    void OnTriggerExit2D()
    {
        canTalk = false; label.enabled = false;
        QuitDialogue();
    }

    void ShowDialogue()
    {
        panelis.enabled = true;  tekstas.enabled = true;
    }
    void QuitDialogue()
    {
        panelis.enabled = false; tekstas.enabled = false;
    }
    
    
}
