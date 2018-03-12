using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.tag); 

        if (collision.collider.tag.Equals("glass")){
           // print("HERE WE GOOOA!!!!");
            Vector3 temp = new Vector3(transform.position.x, transform.position.y, -1);
            transform.position = temp;
        }
    }

}
