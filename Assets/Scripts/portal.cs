using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class portal : MonoBehaviour {

    private float timer = 0.4f, timerAtm = 0.4f, kiekPridet;
    private bool rodyti, once;
    public Transform location;
    public AudioSource audio;
    private GameObject player;
    private BloomAndFlares effect;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        effect = Camera.main.GetComponent<BloomAndFlares>();
	}
	
	// Update is called once per frame
	void Update () {
	if(rodyti)
        {
            effect.enabled = true;
            timerAtm -= Time.deltaTime;

            if (!once)
            {
                effect.bloomThreshold -= 0.2f;
                effect.bloomBlurIterations = 0;
            }
            else
            {
                effect.bloomThreshold += 0.2f;
                effect.bloomBlurIterations = 4;
            }
            if(timerAtm <= 0 && !once)
            {
                player.transform.position = location.position;
                once = true;
                timerAtm = timer;
            }
            else if (timerAtm <= 0 && once)
            {
                effect.bloomThreshold = 4;
                effect.enabled = false;
                once = false;
                timerAtm = timer;
                rodyti = false;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        audio.Play();
        rodyti = true;
        
    }


    void animacija()
    {
        player.transform.position = location.position;
    }
}
