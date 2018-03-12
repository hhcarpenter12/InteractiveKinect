using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ligjt : MonoBehaviour {
    public float duration = 1.0F;
    public Light It;
	// Use this for initialization
	void Start () {
        It = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            It.intensity += 1;
        }

        if (Input.GetKeyDown("down"))
        {
            It.intensity -= 1;
        }


    }


}






