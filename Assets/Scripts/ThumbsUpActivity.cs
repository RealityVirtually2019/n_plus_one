using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class ThumbsUpActivity : IActivity {
    public GameObject prefab;
    public ActivitySequenceManager activitySequenceManager;
    private GameObject thumbsUp;

    public ThumbsUpActivity(ActivitySequenceManager asm)
    {
        activitySequenceManager = asm;
    }

    public void play()
    {
        thumbsUp = GameObject.Instantiate(Resources.Load("ThumbsUpObj")) as GameObject;
        thumbsUp.GetComponent<ThumbsUpObjScr>().activity = this;
        throw new System.NotImplementedException();
    }

    public void taskCompleted()
    {
        GameObject.Destroy(thumbsUp);
        activitySequenceManager.goToNextActivity();
        throw new System.NotImplementedException();
    }
}
