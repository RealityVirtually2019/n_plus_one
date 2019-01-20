using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitySequenceManager : MonoBehaviour {
    public IActivity[] activities;
    public GameObject exitButton;
    private int currIndex = -1;

	// Use this for initialization
	void Start () {
        activities = new IActivity[]
        {
            new IntroActivity(this),
            new ThumbsUpActivity(this),
            new BookActivity(this)
        };

        //activities[0].play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToNextActivity()
    {
        currIndex++;

        if(currIndex < activities.Length)
        {
            activities[currIndex].play();
        } else
        {
            exitButton.SetActive(true);
        }
    }
}


