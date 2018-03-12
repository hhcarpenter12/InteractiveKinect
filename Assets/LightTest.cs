using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTest : MonoBehaviour {

    public float duration = 1.0F;
    public Light lt;
     


    void Start()
    {
        lt = GetComponent<Light>();
        lt.color = Color.white; 
    }
    void Update()
    {

        /*

        float aa = Hand.spineX;

       // print(aa);
       
        if(aa < 0)
        {
            aa = aa * -1; 
        }



        double intense = (double)3 / 5;
        intense = intense * aa;
        intense = 6 - intense;

        //  print(intense); 

        //  lt.intensity = (float)intense; 
        lt.intensity = 3; 


       // print(Input.mousePosition.x); 


    */ 

    }
}
