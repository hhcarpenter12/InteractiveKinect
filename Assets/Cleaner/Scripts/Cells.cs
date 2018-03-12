using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
    {
    public Rigidbody rb;
    public MeshCollider mb;
    public GameObject lighty;
    public GameObject leaves;
    public static bool trig = false;
    private int countSound = 0;
    private int hitter = 0;
    private int limitI = 0;
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    private GameObject temp;
    private GameObject tempP;
    float intensityLevel = 5;
    int timer = 0;

    void Start()
        {
        rb = GetComponent<Rigidbody>();
        mb = GetComponent<MeshCollider>();
        rb.angularDrag = 100;
        rb.drag = 100;
        }

    void Update()
        {
        if (BodySourceView.spineX > -2.5 && BodySourceView.spineX < 2.5 && BodySourceView.HandRightX > 6 && BodySourceView.HandRightX < 8 && BodySourceView.HandRightY > -1 && BodySourceView.HandRightY < 6)
            {
            hitter++;
            MainCell.isHitting = true;
            trig = true;
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
                    Color myColor = new Color32(0x5d, 0xc7, 0xd5, 0xFF);
                    lighty.GetComponent<Light>().color = myColor;
                    lighty.GetComponent<Light>().intensity = 5;
                    temp = Instantiate(lighty, transform.position, transform.rotation);
                    rb.useGravity = true;
                    MainCell.brokenPieces2 = true;
                    tempP = Instantiate(leaves, transform.position, transform.rotation);
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
