using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(250f * Time.deltaTime, 0f, 0f);
        if (transform.position.x > 1500f)
        {
            Destroy (gameObject);
        }
	}
}
