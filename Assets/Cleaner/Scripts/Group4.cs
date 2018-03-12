using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group4 : MonoBehaviour {

    public GameObject spotty; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Cells.trig)
        Instantiate(spotty, transform.position, transform.rotation); 
		
	}
}
