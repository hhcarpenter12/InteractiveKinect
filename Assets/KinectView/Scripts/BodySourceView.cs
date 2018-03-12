using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using Joint = Windows.Kinect.Joint;
using UnityEngine.SceneManagement;


public class BodySourceView : MonoBehaviour
    {
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;
    public static int zoom = 0;
    public static float spineX = 0;
    public static float spineY = 0;
    public static float HandRightX = 0;
    public static float HandRightY = 0;
    public static float HandLeftX = 0;
    public static float HandLeftY = 0;
    SceneManager manager;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },

        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },

        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };


    private List<Kinect.JointType> _joints = new List<Kinect.JointType>
    {
        Kinect.JointType.HandLeft,
        Kinect.JointType.HandRight,
        Kinect.JointType.SpineMid

    };


    void Update()
        {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "activitySelecte")
            {
            _joints.Remove(Kinect.JointType.HandLeft);
            _joints.Remove(Kinect.JointType.SpineMid);
            }
        if (sceneName == "LightTest")
            {
            _joints.Remove(Kinect.JointType.HandLeft);
            _joints.Remove(Kinect.JointType.HandRight);
            }
        Kinect.Body[] data = mBodySourceManager.GetData();
        if (data == null)
            {
            return;
            }
        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in data)
            {
            if (body == null)
                {
                continue;
                }

            if (body.IsTracked)
                {
                trackedIds.Add(body.TrackingId);
                }
            }
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        foreach (ulong trackingId in knownIds)
            {
            if (!trackedIds.Contains(trackingId))
                {
                Destroy(mBodies[trackingId]);
                mBodies.Remove(trackingId);
                }
            }
        foreach (var body in data)
            {
            if (body == null)
                {
                continue;
                }
            if (body.IsTracked)
                {
                if (!mBodies.ContainsKey(body.TrackingId))
                    {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                    }
                RefreshBodyObject(body, mBodies[body.TrackingId]);
                }
            }
        }

    private GameObject CreateBodyObject(ulong id)
        {
        GameObject body = new GameObject("Body:" + id);
        foreach (Kinect.JointType joint in _joints)
            {
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();
            newJoint.transform.parent = body.transform;
            }
        return body;
        }

    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
        {
        if ((body.HandRightConfidence == Kinect.TrackingConfidence.High && body.HandRightState == Kinect.HandState.Closed) || (body.HandLeftConfidence == Kinect.TrackingConfidence.High && body.HandLeftState == Kinect.HandState.Closed))
            {
            zoom = 1;
            }
        else if ((body.HandRightConfidence == Kinect.TrackingConfidence.High && body.HandRightState == Kinect.HandState.Open) || body.HandLeftConfidence == Kinect.TrackingConfidence.High && body.HandLeftState == Kinect.HandState.Open)
            {
            zoom = 2;
            }
        foreach (Kinect.JointType _joint in _joints)
            {
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;
            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
            if (_joint.ToString().Equals("HandRight"))
                {
                HandRightX = jointObject.position.x;
                HandRightY = jointObject.position.y;

                }
            if (_joint.ToString().Equals("HandLeft"))
                {
                HandLeftX = jointObject.position.x;
                HandLeftY = jointObject.position.y;

                }
            if (_joint.ToString().Equals("SpineMid"))
                {
                spineX = jointObject.position.x;
                spineY = jointObject.position.y;

                }
            }
        }

    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
        {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
        }
    }
