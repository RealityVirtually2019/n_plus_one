using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class ThumbsUpActivity : MonoBehaviour, IActivity {
    public GameObject cube;
    public GameObject sphere;

    private Vector3 initpos;

    // Use this for initialization
    void Start () {
        MLHands.Start();
        MLHandKeyPose[] _gestures = new MLHandKeyPose[5];
        //{
        //    MLHandKeyPose.Thumb
        //};
        _gestures[0] = MLHandKeyPose.Ok;
        _gestures[1] = MLHandKeyPose.Finger;
        _gestures[2] = MLHandKeyPose.OpenHandBack;
        _gestures[3] = MLHandKeyPose.Fist;
        _gestures[4] = MLHandKeyPose.Thumb;
        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        initpos = sphere.transform.position;
    }

    // Update is called once per frame
    void Update () {
        //if(isThumbsUpGesture(MLHands.Left) || isThumbsUpGesture(MLHands.Right))
        //{
        //    cube.SetActive(true);
        //    sphere.transform.position = MLHands.Left.Thumb.KeyPoints[0].Position;
        //} else
        //{
        //    cube.SetActive(false);
        //    sphere.transform.position = initpos;
        //}

        if(GetGesture(MLHands.Left, MLHandKeyPose.Thumb))
        {
            cube.SetActive(true);
            sphere.transform.position = MLHands.Left.Thumb.KeyPoints[0].Position;
        }
        else if(MLHands.Left != null)
        {
            sphere.transform.position = MLHands.Left.Thumb.KeyPoints[0].Position;
        } else
        {
            cube.SetActive(false);
            sphere.transform.position = initpos;
            //sphere.transform.position = initpos;
        }
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    private bool isThumbsUpGesture(MLHand hand)
    {
        return (hand != null && (hand.KeyPose == MLHandKeyPose.Thumb) && hand.KeyPoseConfidence > 0.9f) ;
    }

    public void taskCompleted()
    {
        throw new System.NotImplementedException();
    }

    private bool GetGesture(MLHand hand, MLHandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.KeyPoseConfidence > 0.9f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
