using UnityEngine;
using System.Collections;

public partial class GrappHook : MonoBehaviour
{
    float highestPoint = 1000, angle;
    void getHighestPoint(int puse)
    {
        if (puse == 1)
        {
            if (player.transform.position.x > location.transform.position.x)
            { //hooko kablio ir playerio santykis
                if(AuksciausiasTaskasDesinejPusej < player.transform.position.y)
                {
                    AuksciausiasTaskasDesinejPusej = player.transform.position.y; AuksciausiasTaskasKairejPusej = 0;
                }
            }
        }
        else if (puse == -1)
        {
            if (player.transform.position.x > location.transform.position.x)
            { //hooko kablio ir playerio santykis
                if (AuksciausiasTaskasKairejPusej < player.transform.position.y)
                {
                    AuksciausiasTaskasKairejPusej = player.transform.position.y; AuksciausiasTaskasDesinejPusej = 0;
                }
            }
        }





















        //jei nespaus A\D tai suveik jega, suveiks kai krenta
         // nustato kai zmogus auksciausiai pakiles hooko atzvildgiu
        
           // highestPoint = location.transform.position.y - player.transform.position.y; //note: kuo mazesne tuo auksciau pakyla
         //float angle =highestPoint / hook.distance;
        
        //Debug.Log("kampas: " + highestPoint);

            //beta/90*distance*x     ---jegos formulė
        

    }
}
