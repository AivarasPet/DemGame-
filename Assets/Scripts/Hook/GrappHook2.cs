using UnityEngine;
using System.Collections;

public partial class  GrappHook  {


    void SwingMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) // judejimas ant zemes ir swinginimasis
        {
            if (!springOff) { springOff = true; springTimerAtm = springTimer; } //spiruoklei
            if (gScript.ground) { hook.enabled = false; playerPhysics.gravityScale = 50; } //
            else
            {
                HandleSwing(); if(isHooked) playerPhysics.gravityScale = 150;
            }
        }
        else { SwingTimer -= Time.deltaTime; }
        if (SwingTimer <= 0f)
        {
            minusminusMomentine = 5;
            loopCounter = loopCounterMin;
            loopCounterAdd = loopCounterMin;
            momentine = swingPower;
            stabdytOre = false;
            SwingTimer = 1.5f;
        }
    }

    private int supimosiPuse = 0,  oldSupimosiPuse, loopCounterMin = 13, minusMomentine = 100, minusminusMomentine = 10, kasKiekLoopuTikrint=4;
    private float SwingTimer = 1.5f, swingPower = 3500f, sulaikimoTimer, atvirkstine = 3500f, loopCounterMax = 42, maxJega = 4200f, kiekAddintLoop = 4, kiekPridetJegos = 140, loopCounterAdd = 10;
    public float momentine = 3500f, loopCounter = 13, KasKelintasAukstis, KasKelintasTolis;
    public bool stabdytOre;

    void HandleSwing() //supimasis
    { 
        loopCounter--;

        if(!stabdytOre) kasKiekLoopuTikrint--;
        if (kasKiekLoopuTikrint == 0 && !stabdytOre)
        {     
                if (Mathf.Abs(KasKelintasAukstis - player.transform.position.y) < 1.5f && Mathf.Abs(KasKelintasTolis - player.transform.position.x) < 2.2f && rastKampa(0.75f))    stabdytOre = true; 
                KasKelintasAukstis = player.transform.position.y;
                KasKelintasTolis = player.transform.position.x;
                kasKiekLoopuTikrint = 4;           
        }

        if (Input.GetKey(KeyCode.A))
        {          
            supimosiPuse = -1;
            if (loopCounter >= 1 && player.transform.position.y + 10 < transform.position.y && !stabdytOre) { atvirkstine = momentine; //jei yra loopu ir playeris zemiau negu limitas
                playerPhysics.AddForce(transform.right * (-momentine)); player.transform.localScale = new Vector3(-1, 1, 1); } //jega ir puse
          
        }
        else if (Input.GetKey(KeyCode.D))
        {
            supimosiPuse = 1;
            if (loopCounter >= 1 && player.transform.position.y + 10 < transform.position.y && !stabdytOre) { atvirkstine = momentine; //jei yra loopu ir playeris zemiau negu limitas
                playerPhysics.AddForce(transform.right * momentine); player.transform.localScale = new Vector3(1, 1, 1); } //jega ir puse
           
        }


        if (supimosiPuse != oldSupimosiPuse)
        {
            if (loopCounter <= loopCounterMax)
            {
                if (loopCounterAdd < loopCounterMax) loopCounterAdd += kiekAddintLoop; if (momentine <= maxJega) { momentine += kiekPridetJegos; }
            }
            loopCounter = loopCounterAdd;
            stabdytOre = false;
            kasKiekLoopuTikrint = 10;
        }
        oldSupimosiPuse = supimosiPuse;
        
    }

    void pasikeiteDistance()
    {
        //23 distance idealus; 4500f maxjega
        //100 6000f
        // 60 distance 6000f visai px  
        

        loopCounterMax = (hook.distance*50) / 23;
        maxJega = Mathf.Clamp((hook.distance * 6000) / 55, swingPower, 6000f);
        kiekAddintLoop = Mathf.Clamp((hook.distance * 4) / 23, 4f, 50f);
        kiekPridetJegos = Mathf.Clamp((hook.distance * 100) / 23, 0, 100f);
        if (momentine > maxJega) momentine = maxJega;
    }
    private bool rastKampa(float limitas)
    { //padariau kad santykis o ne kampas...
        float kampas = Mathf.Abs(player.transform.position.x - transform.position.x) / Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(transform.position.x, transform.position.y));
        if (kampas >= limitas) return true;
        else return false;
    }




}
