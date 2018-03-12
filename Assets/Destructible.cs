using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject desver;

    public GameObject lighty, pEffect;
    public int minX, minY, maxX, maxY;
    public static Hand hand; 

    private void Start()
    {
        Instantiate(lighty, transform.position, transform.rotation);
    }


    // Update is called once per frame
    void Update () {

      //  print(BodySourceView.spineX);  
        MoveWithMouse();
        this.transform.position = new Vector3(BodySourceView.spineX - 1, BodySourceView.spineY + 6, 0f); 
        

	}

    private void MoveWithMouse()
    {
        /*
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocksX = Input.mousePosition.x / Screen.width * 16;
        float mousePosInBlocksY = Input.mousePosition.y / Screen.height * 8;
        paddlePos.x = Mathf.Clamp(mousePosInBlocksX, minX, maxX);
        paddlePos.y = Mathf.Clamp(mousePosInBlocksY, minY, maxY);
        this.transform.position = paddlePos;
        */ 
        
    }




    private void OnCollisionEnter(Collision collision)
    {
        print("Lol, you hit me");
        Instantiate(desver, transform.position, transform.rotation);
        
        DestroyObject(this.gameObject);

        Instantiate(pEffect, transform.position, transform.rotation);
        Instantiate(lighty, transform.position, transform.rotation); 



    }






}
