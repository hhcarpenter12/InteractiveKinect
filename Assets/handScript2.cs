using UnityEngine;
using System.Collections;

public class handScript2 : MonoBehaviour
{

    public bool autoPlay = false;
    public float minX, maxX, minY, maxY;

	private cocoonScript brick;

    void Start()
    {
		brick = GameObject.FindObjectOfType<cocoonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = brick.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
        this.transform.position = paddlePos;
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
