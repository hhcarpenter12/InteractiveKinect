using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells3 : MonoBehaviour
{
    public Rigidbody rb;
    public MeshCollider mb;
    public GameObject leaves;
    public GameObject lighty;
    private GameObject temp;
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    private int limitI = 0;
    private int hitter = 0;
    int timer = 0;
    private GameObject tempP;
    float intensityLevel = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mb = GetComponent<MeshCollider>();
        rb.angularDrag = 100;
        rb.drag = 100;
    }
    void Update()
    {
        if (BodySourceView.spineX > -3 && BodySourceView.spineX < 3 && BodySourceView.HandLeftX > -6 && BodySourceView.HandLeftX < 1 && BodySourceView.HandLeftY < 8 && BodySourceView.HandLeftY > 1)
        {
            hitter++;
            MainCell.isHitting = true;
            if (hitter <= 100)
            {
                mb.enabled = true;
                rb.drag = (-1 * hitter) + 100;
                rb.angularDrag = (-1 * hitter) + 100;
                Vector3 dd = new Vector3(this.transform.position.x + (hitter / 1000), this.transform.position.y + (hitter / 1000), this.transform.position.z + (hitter / 1000));
                transform.position = dd;
                float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
                float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            }
            else
            {
                if (limitI < 1)
                {
                    Color myColor = new Color32(0xac, 0xdd, 0xda, 0xFF);
                    lighty.GetComponent<Light>().color = myColor;
                    temp = Instantiate(lighty, transform.position, transform.rotation);
                    rb.useGravity = true;
                    MainCell.brokenPieces3 = true;
                    tempP =   Instantiate(leaves, transform.position, transform.rotation);
                    limitI += 1;
                }
            }
        }
        if (MainCell.turnOffLights == true)
        {
            Destroy(temp);
        }
        temp.GetComponent<Transform>().position = MainCell.position;
        temp.GetComponent<Transform>().rotation = MainCell.rotation;
        tempP.GetComponent<Transform>().position = MainCell.position;
        tempP.GetComponent<Transform>().rotation = MainCell.rotation;
    }
}
