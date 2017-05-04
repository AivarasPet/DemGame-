using UnityEngine;
using System.Collections;

public partial class GrappHook : MonoBehaviour
{
    Rigidbody2D rb2d, playerPhysics;
    public float speed = 300f, pulling = 100f, jumpHeight;
    private float delay = 0.3f, timer = 0.3f;
    GameObject location, player, groundDet;
    DistanceJoint2D hook;
    SpringJoint2D spring;
    HingeJoint2D hinge;
    GroundDetection gScript;
    LineRenderer line;
    Movement mScript;      
    Vector2 target;
    public Transform linijosPradzia;
    public bool isHooked, isShot, pasiHookino, graplinghook, linijaOn;

    // Use this for initialization
    void Start()
    {

        GameObject.Find("hookLook").GetComponent<SpriteRenderer>().enabled = false;
        rb2d = gameObject.GetComponentInChildren<Rigidbody2D>();
        location = GameObject.Find("grappHook");
        player = GameObject.Find("Player");
        groundDet = GameObject.Find("GroundDetector");
        gScript = groundDet.GetComponent<GroundDetection>();
        hook = player.GetComponent<DistanceJoint2D>();
        hinge = player.GetComponent<HingeJoint2D>();
        spring = player.GetComponent<SpringJoint2D>();
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        mScript = player.GetComponent<Movement>();
        playerPhysics = player.GetComponent<Rigidbody2D>();
    }



    void Update()
    {

        if (timer <= 0) { if (Input.GetKeyDown(KeyCode.Mouse1)) mouseClick(); }      
        else timer -= Time.deltaTime;



        if (isShot) checkIfTouches(); //cool

        if (pasiHookino) HookoPerjunginejimas(0); //cool


        if (linijaOn) { 
            //linijos grafikai
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector2(linijosPradzia.position.x, linijosPradzia.position.y));
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q)) unHook();
        }

  
    }

    void FixedUpdate()
    {
        if (linijaOn) //kai ijungta textura
        {
            if (Input.GetKey(KeyCode.W) && isHooked) aukstyn(true);          
            else if (Input.GetKey(KeyCode.S) && !gScript.ground) aukstyn(false);
           

            SwingMovement();

            if (location.transform.position.y - transform.position.y > 0) hook.enabled = false; //jei zmogus auksciu uz hooka
            else if (!gScript.ground && isHooked) hook.enabled = true;         
        } // pabaiga judejimo
    }

  
    void OnTriggerEnter2D(Collider2D col) //paliecia pavirsiu
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "softGround")
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());    
            hook.connectedAnchor = gameObject.transform.position;
            mScript.graplinghook = true; //animacijai
            spring.connectedAnchor = gameObject.transform.position; spring.enabled = true; springOff = false; pasiHookino = true ;  //0.1 tamping 2.5 frequency       
           // hook.enabled = true; isHooked = true; cia kai spring idejau uzdejau comentara
            playerPhysics.gravityScale = 150; 
            float distance = Vector2.Distance(gameObject.transform.position, location.transform.position); 
            spring.distance = distance;       
            isShot = false; //pataike, tai isjungia ifa update
            Quaternion goodOne = transform.rotation; //kad galetu normaliai suptis ant hooko
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GameObject.Find("hookLook").transform.rotation = goodOne; // end                 
            loopCounter = loopCounterMax*2f; if (gScript.ground) momentine = swingPower; else if(momentine < maxJega)momentine += kiekPridetJegos; 
            stabdytOre = false;
            
        }
    }


    public float springTimer = 1.2f, springTimerAtm = 1.2f;
    bool springOff = true; 
    private float perjungimoTimer = 0.1f, perjungimoTimerAtm = 0.1f;
    private int oldMode=9;

    void HookoPerjunginejimas(int mode)
    {
        // ar sptinginas ar normaliai
        if (springTimerAtm >= 0 && springOff == false) springTimerAtm -= Time.deltaTime;
        else if (mode != oldMode)
        {
                if (mode == 0)
                {
                    hook.distance = Vector2.Distance(gameObject.transform.position, location.transform.position);
                    spring.enabled = false;
                    hook.enabled = true;
                    isHooked = true;
                    pasiHookino = false;
                    pasikeiteDistance();
                }
                else if (mode == 1)
            {
                hinge.enabled = false;
                hook.enabled = true;
                playerPhysics.gravityScale = 150; playerPhysics.mass = 1;
                playerPhysics.constraints = RigidbodyConstraints2D.FreezeRotation;
                player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, 0);
                mScript.enabled = true;
                perjungimoTimerAtm = perjungimoTimer;
                playerPhysics.drag = 0f;
            }
                if (mode == 2)
            {
                mScript.enabled = false;
                playerPhysics.constraints = RigidbodyConstraints2D.None;
                hook.enabled = false;
                hinge.connectedAnchor = new Vector2(transform.position.x, transform.position.y);
                hinge.anchor = new Vector2(transform.transform.position.x, transform.transform.position.y);
                hinge.enabled = true;
                playerPhysics.gravityScale = 15; playerPhysics.mass = 0.1f;
                playerPhysics.drag = 0.15f;
            }
        }
        oldMode = mode;
    }


    
    }


 

