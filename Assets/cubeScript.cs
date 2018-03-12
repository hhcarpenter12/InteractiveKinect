using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("left"))
            transform.Translate(-1.0f, 0.0f, 0.0f);
        if (Input.GetKeyDown("right"))
            transform.Translate(1.0f, 0.0f, 0.0f);


    }


}

