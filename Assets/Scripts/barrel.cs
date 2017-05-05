using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour {

    // Use this for initialization

    public int CoinDrop;
    private float fadeColor = 1;
    private Animator anim;
    private bool galimaKirst, Broken, fade;
    public GameObject prefab;
    GameObject player;

    void Start() {
        player = GameObject.Find("Player");
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (galimaKirst)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && check()) StartCoroutine(Break());
            else if (fade && gameObject.GetComponent<AudioSource>().isPlaying == false)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, fadeColor);
                fadeColor -= 0.015f;
                if (fadeColor <= 0) Destroy(gameObject);
            }


        }
    }

        void OnTriggerEnter2D(Collider2D col)
      {
            if (col.gameObject.tag == "Player") galimaKirst = true;
        }

        void OnTriggerExit2D()
    {
            galimaKirst = false;

        }
    private bool check() {
        if (player.transform.position.x > transform.position.x && player.transform.localScale.x == -1 || player.transform.position.x < transform.position.x && player.transform.localScale.x == 1) return true;
        else return false;
    }



    IEnumerator Break() {
        yield return new WaitForSeconds(0.3f);
        Broken = true;
        galimaKirst = false;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject.GetComponent<Collider2D>());
        fade = true;
        anim.SetBool("Broken", Broken);

        for (int i = 0; i < CoinDrop; i++) Instantiate(prefab, new Vector3(transform.position.x - 2f + i * 2.0f, transform.position.y + 5, 0), Quaternion.identity);
     }
}