using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {


    public Transform mHandMesh;
    public float aa = 0; 

	
	// Update is called once per frame
	void Update () {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
       // print(mHandMesh.position); 
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (!collision.gameObject.CompareTag("bubble"))
            return;
       
            Bubble bubble = collision.gameObject.GetComponent<Bubble>();

       // StartCoroutine(bubble.Pop()); 
        Destroy(bubble);
       
        

         collision.gameObject.SetActive(false); 
        
    }

}
