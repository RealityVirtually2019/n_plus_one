using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class IntroActivity : IActivity
{
    public GameObject prefab;
    public ActivitySequenceManager activitySequenceManager;
    private GameObject introObj;

    public IntroActivity(ActivitySequenceManager asm)
    {
        activitySequenceManager = asm;
    }

    public void play()
    {
        introObj = GameObject.Instantiate(Resources.Load("IntroObj")) as GameObject;
        introObj.GetComponent<IntroObjScr>().activity = this;
        throw new System.NotImplementedException();
    }

    public void taskCompleted()
    {
        GameObject.Destroy(introObj);
        activitySequenceManager.goToNextActivity();
        throw new System.NotImplementedException();
    }
}
