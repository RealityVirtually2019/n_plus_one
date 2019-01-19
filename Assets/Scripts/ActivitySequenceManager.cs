using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitySequenceManager : MonoBehaviour {
    public IActivity[] activities;

	// Use this for initialization
	void Start () {
        activities = new IActivity[]
        {
            new ThumbsUpActivity()
        };

        foreach(IActivity activity in activities)
        {
            activity.play();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


