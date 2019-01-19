using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitySequenceManager : MonoBehaviour {
    public IActivity[] activities;
    private int currIndex = 0;

	// Use this for initialization
	void Start () {
        activities = new IActivity[]
        {
            new ThumbsUpActivity(this)
        };

        activities[0].play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToNextActivity()
    {
        if(++currIndex < activities.Length)
        {
            activities[currIndex].play();
        }
    }
}


