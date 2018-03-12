using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCell : MonoBehaviour
    {
    public static bool colli = false;
    private bool hasPlayed = false;
    private bool hasPlayed2 = false;
    private bool hasPlayed3 = false;
    public GameObject audio2;
    public static bool turnOffLights = false;
    public static bool brokenPieces = false;
    public static bool brokenPieces2 = false;
    public static bool brokenPieces3 = false;
    public static bool isHitting = false;
    public static Vector3 position;
    public static Quaternion rotation;
    public GameObject pEffects;
    public GameObject halo;
    GameObject tempHalo;
    float t;
    float t2;
    float t3;
    float t4;
    Color myColor = new Color32(0x5d, 0xc7, 0xd5, 0xFF);
    Color myColor2 = new Color32(0x84, 0xfe, 0xc1, 0xFF);
    Color myColor3 = new Color32(0xac, 0xdd, 0xda, 0xFF);
    int timeCount = 0;
    float intensityLevel = 2;

    private void Start()
        {
        tempHalo = Instantiate(halo, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
        tempHalo.GetComponent<Light>().color = Color.black;
        }

    void Update()
        {
        timeCount++;
        position = this.transform.position;
        rotation = this.transform.rotation;
        if (isHitting && !brokenPieces && !brokenPieces2 && !brokenPieces3)
            {
            t3 += Time.deltaTime / 4;
            tempHalo.GetComponent<Light>().color = Color.Lerp(Color.black, myColor, t3);
            }
        if (brokenPieces)
            {
            t += Time.deltaTime / 4;
            tempHalo.GetComponent<Light>().color = Color.Lerp(myColor, myColor2, t);
            }
        if (brokenPieces2)
            {
            t2 += Time.deltaTime / 4;
            tempHalo.GetComponent<Light>().color = Color.Lerp(myColor2, myColor3, t2);
            }
        if (brokenPieces && !hasPlayed)
            {
            GameObject soundy = (GameObject)Instantiate(audio2, transform.position, transform.rotation);
            audio2.GetComponent<AudioSource>().PlayOneShot(audio2.GetComponent<AudioClip>());
            hasPlayed = true;
            }
        if (brokenPieces2 && !hasPlayed2)
            {
            GameObject soundy = (GameObject)Instantiate(audio2, transform.position, transform.rotation);
            audio2.GetComponent<AudioSource>().PlayOneShot(audio2.GetComponent<AudioClip>());
            hasPlayed2 = true;
            }
        if (brokenPieces3 && !hasPlayed3)
            {
            GameObject soundy = (GameObject)Instantiate(audio2, transform.position, transform.rotation);
            audio2.GetComponent<AudioSource>().PlayOneShot(audio2.GetComponent<AudioClip>());
            hasPlayed3 = true;
            }
        if (brokenPieces3 && brokenPieces2 && brokenPieces && hasPlayed3)
            {
            turnOffLights = true;
            if (BodySourceView.zoom == 1)
                {
                tempHalo.GetComponent<Light>().intensity -= intensityLevel * Time.deltaTime;
                print("Main Cell intensity " + tempHalo.GetComponent<Light>().intensity);
                Kvant.Spray.shooter = false;
                if (tempHalo.GetComponent<Light>().intensity <= 0)
                    {
                    tempHalo.GetComponent<Light>().intensity = 0;
                    }
                }
            else
                {
                if (timeCount % 120 == 0)
                    {
                    GameObject temp = Instantiate(pEffects, transform.position, transform.rotation);
                    }
                tempHalo.GetComponent<Light>().intensity += intensityLevel * Time.deltaTime;
                print("Main Cell intensity " + tempHalo.GetComponent<Light>().intensity);
                Kvant.Spray.shooter = true;
                if (tempHalo.GetComponent<Light>().intensity >= 4)
                    {
                    tempHalo.GetComponent<Light>().intensity = 4;
                    }
                }
            }
        tempHalo.GetComponent<Transform>().position = this.transform.position;
        tempHalo.GetComponent<Transform>().rotation = this.transform.rotation;
        this.transform.position = new Vector3(BodySourceView.spineX - 1, BodySourceView.spineY + 6, 0f);
        }
    }
