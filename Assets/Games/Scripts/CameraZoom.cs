using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public Canvas canvas; // The canvas
    public float zoomSpeed = 0.5f;        // The rate of change of the canvas scale factor

    void Update()
    {
      if (Input.GetMouseButton(0)) {
            canvas.scaleFactor -= zoomSpeed;
            //print(canvas.scaleFactor);
        }
        
       else if (Input.GetMouseButton(1))
        {
            canvas.scaleFactor += zoomSpeed;
            //print(canvas.scaleFactor);
        }


        canvas.scaleFactor = Mathf.Max(canvas.scaleFactor, 0.5f);

    }
}

