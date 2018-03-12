using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
  
    public float minX, maxX, minY, maxY; public bool autoPlay = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
     
            MoveWithMouse();
    
    }

   







    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        float mousePosYInBlocks = Input.mousePosition.y / Screen.height * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        paddlePos.y = Mathf.Clamp(mousePosYInBlocks, minY, maxY);
        this.transform.position = paddlePos;
    }
  

}
