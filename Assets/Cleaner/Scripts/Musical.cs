using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musical : MonoBehaviour
    {
    public GameObject musicy;
    private GameObject temp;

    void Start()
        {
        temp = Instantiate(musicy, transform.position, transform.rotation);
        }

    void Update()
        {
        if (BodySourceView.spineX < 0)
            {
            temp.GetComponent<AudioSource>().volume = 0.1f * (BodySourceView.spineX) + 0.9f;
            }
        else
            {
            temp.GetComponent<AudioSource>().volume = -0.1f * (BodySourceView.spineX) + 0.9f;
            }
        }
    }
