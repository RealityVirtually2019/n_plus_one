﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ThumbsUpObjScr : MonoBehaviour {
    public GameObject cube;
    public GameObject sphere;

    private Vector3 initpos;

    // Use this for initialization
    void Start()
    {
        MLHands.Start();
        MLHandKeyPose[] _gestures = new MLHandKeyPose[]
        {
            MLHandKeyPose.Thumb
        };

        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        initpos = sphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThumbsUpGesture(MLHands.Left) || isThumbsUpGesture(MLHands.Right))
        {
            cube.SetActive(true);
            sphere.transform.position = MLHands.Left.Thumb.KeyPoints[0].Position;
        }
        else
        {
            cube.SetActive(false);
            sphere.transform.position = initpos;
        }
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    private bool isThumbsUpGesture(MLHand hand)
    {
        return (hand != null && (hand.KeyPose == MLHandKeyPose.Thumb) && hand.KeyPoseConfidence > 0.9f);
    }

}
