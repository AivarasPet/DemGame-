using UnityEngine;
using System.Collections;

public partial class  GrappHook  {

    bool KaTikPaleido;

    void SwingMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) // judejimas ant zemes ir swinginimasis
        {
            springOff = true; springTimerAtm = springTimer;
            if (gScript.ground) { hook.enabled = false; playerPhysics.gravityScale = 50; } //
            else
            {
                HandleSwing(); playerPhysics.gravityScale = 150;
                arNebejuda();
            }
        }
        else { SwingTimer -= Time.deltaTime; }
        if (SwingTimer <= 0f)
        {
            minusminusMomentine = 5;
            loopCounter = loopCounterMin;
            loopCounterAdd = loopCounterMin;
            SwingTimer = 1.5f;
            momentine = swingPower;
        }
    }

    private int supimosiPuse = 0,  oldSupimosiPuse, loopCounterMin = 13, minusMomentine = 100, minusminusMomentine = 10, kasKiekLoopuTikrint=5;
    private float SwingTimer = 1.5f, loopCounter = 13, swingPower = 3500f, sulaikimoTimer, atvirkstine = 3500f, loopCounterMax = 42, maxJega = 4200f, kiekAddintLoop = 4, kiekPridetJegos = 100, loopCounterAdd = 10;
    public float momentine = 3500f, AuksciausiasTaskasKairejPusej, AuksciausiasTaskasDesinejPusej, KasKelintasAukstis, KasKelintasTolis;
    public bool stabdytOre;
    void HandleSwing() //supimasis
    { 
        loopCounter--;
        //Debug.Log(loopCounter);
        if(!stabdytOre) kasKiekLoopuTikrint--;
        if(kasKiekLoopuTikrint==0 && !stabdytOre)
        {
            if (Mathf.Abs(KasKelintasAukstis - player.transform.position.y) < 1.5f && Mathf.Abs(KasKelintasTolis - player.transform.position.x) < 1.5f) stabdytOre = true;
            KasKelintasAukstis = player.transform.position.y;
            KasKelintasTolis = player.transform.position.x;
            //Debug.Log(KasKelintasAukstis);
            kasKiekLoopuTikrint = 5;
        }

        if (Input.GetKey(KeyCode.A))
        {          
            supimosiPuse = -1;
            getHighestPoint(-1); 
            if (loopCounter >= 1 && player.transform.position.y + 10 < transform.position.y && !stabdytOre) { atvirkstine = momentine; //jei yra loopu ir playeris zemiau negu limitas
                playerPhysics.AddForce(transform.right * (-momentine)); player.transform.localScale = new Vector3(-1, 1, 1); } //jega ir puse
          // else { if (atvirkstine > 2500) { atvirkstine -= minusminusMomentine; if (minusminusMomentine <= minusMomentine) minusminusMomentine += 5; 
               //   playerPhysics.AddForce(transform.right * (-atvirkstine)); player.transform.localScale = new Vector3(-1, 1, 1); } }       
        }
        else if (Input.GetKey(KeyCode.D))
        {
            supimosiPuse = 1;
            getHighestPoint(1);
            if (loopCounter >= 1 && player.transform.position.y + 10 < transform.position.y && !stabdytOre) { atvirkstine = momentine; //jei yra loopu ir playeris zemiau negu limitas
                playerPhysics.AddForce(transform.right * momentine); player.transform.localScale = new Vector3(1, 1, 1); } //jega ir puse
            //else { if (atvirkstine > 2500) { atvirkstine -= minusminusMomentine; if (minusminusMomentine <= minusMomentine) minusminusMomentine += 5;
                //    playerPhysics.AddForce(transform.right *atvirkstine); player.transform.localScale = new Vector3(1, 1, 1); } } 
        }

        if (supimosiPuse != oldSupimosiPuse)
        {
            if (loopCounter <= loopCounterMax)
            {
                if (loopCounterAdd < loopCounterMax) loopCounterAdd += kiekAddintLoop; if (momentine <= maxJega) { momentine += kiekPridetJegos; }
                stabdytOre = false;
            }
            loopCounter = loopCounterAdd;
        }
        oldSupimosiPuse = supimosiPuse;

        
    }

    void pasikeiteDistance()
    {
        //23 distance idealus; 42 loopCounterMax 
        // 23 distance; 4000f maxjega;
        // 23 - 4000 
        // distance - x
        loopCounterMax = (hook.distance*50) / 23;
        maxJega = Mathf.Clamp((hook.distance * 4000) / 23, 0, 20000f);
        kiekAddintLoop = Mathf.Clamp((hook.distance * 4) / 23, 4f, 50f);
        //kiekAddintLoop = (100 * 5) / hook.distance; //+=4 ant 23 distance
        //if (hook.distance > 30f) kiekAddintLoop = 1.5f * kiekAddintLoop; 
        kiekPridetJegos = Mathf.Clamp((hook.distance * 100) / 23, 0, 50);
       
    }

    private int loopuSk = 8, loopuSkAtm=10;
    private float oldPosX=0, oldPosY=0;
    private bool arGalimaJudetOre=true;

    void arNebejuda()
    {
        loopuSkAtm--;
        if(loopuSkAtm<0)
       {
            if (Mathf.Abs(oldPosX - player.transform.position.x) < 4f && Mathf.Abs(oldPosY-player.transform.position.y) < 4f) //jei nebejuda
            {
                arGalimaJudetOre = false;
             //   Debug.Log("galima");
                loopuSkAtm = loopuSk;
            }
            //else Debug.Log("negalima");
            oldPosX = player.transform.position.x;
            oldPosY = player.transform.position.y;
        }
    }

    void RastKampa()
    {
        float kampas = 90-(Mathf.Asin( (location.transform.position.y-player.transform.position.y)/hook.distance) * 100) ;
        Debug.Log(kampas);
    }

}
