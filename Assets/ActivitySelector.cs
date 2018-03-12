using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivitySelector : MonoBehaviour {
    SceneManager manager;
    int firstActivityCount = 0;
    int secondActivityCount = 0;
    public GameObject particle;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //print(Screen.width + "X" + Screen.height);
        print(Input.mousePosition);

       // print(Input.mousePosition);
        if (Input.mousePosition.x <= 350 && Input.mousePosition.x >= 250 && Input.mousePosition.y > 144 && Input.mousePosition.y < 169)
        {
            print("Hello!");
            firstActivityCount += 1;
        }

        if (Input.mousePosition.x <= 450 && Input.mousePosition.x >= 350 && Input.mousePosition.y > 144 && Input.mousePosition.y < 169)
        {
            print("Hello!");
            secondActivityCount += 1;
        }



        if (firstActivityCount >= 200)
        {
            SceneManager.LoadScene("Zoomed");   
        }

        if (secondActivityCount >= 200)
        {
            SceneManager.LoadScene("MainScene");
        }



    }
}
