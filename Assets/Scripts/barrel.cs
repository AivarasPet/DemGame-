using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour {

    // Use this for initialization

    public int CoinDrop;
    public bool galimaKirst;
    public GameObject prefab;
    GameObject player;

	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	if(galimaKirst)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && check())
            {
                Destroy(gameObject, 1);
                gameObject.GetComponent<Animation>().Play();
                Destroy(gameObject.GetComponent<BoxCollider2D>());
                gameObject.GetComponent<AudioSource>().Play();
                for (int i = 0; i < CoinDrop; i++) Instantiate(prefab, new Vector3(transform.position.x-2f + i*2.0f, transform.position.y+5, 0), Quaternion.identity);
                } 
        }
       
        
	}

   void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Player") galimaKirst = true;
    }

    void OnTriggerExit2D()
    {
        galimaKirst = false;

    }
    private  bool check() {
        if (player.transform.position.x > transform.position.x && player.transform.localScale.x == -1 || player.transform.position.x < transform.position.x && player.transform.localScale.x == 1) return true;
       else return false;
   }

}
