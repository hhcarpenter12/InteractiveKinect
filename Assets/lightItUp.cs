using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightItUp : MonoBehaviour {
    private GameObject lightGameObject;
    private Light lightComp;
    public Color lerpedColor = Color.white;
    // Use this for initialization
    void Start () {
        lightGameObject = new GameObject("The Light");
        lightComp = lightGameObject.AddComponent<Light>();
        lightComp.type = LightType.Directional;
        lightComp.color = Color.white;
        lightGameObject.transform.position = new Vector3(0, 1, 0);
        lightComp.intensity = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {

            //lightComp.range += 1;
         
           
        }

   

    }


    void OnMouseOver()
    {

        lightComp.intensity += 0.001f;

        lightComp.color = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 3));


    }
  
    
    


}
