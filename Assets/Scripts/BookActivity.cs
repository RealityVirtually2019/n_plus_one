using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class BookActivity : IActivity
{
    public GameObject prefab;
    public ActivitySequenceManager activitySequenceManager;
    private GameObject bookObj;

    public BookActivity(ActivitySequenceManager asm)
    {
        activitySequenceManager = asm;
    }

    public void play()
    {
        bookObj = GameObject.Instantiate(Resources.Load("BookObj")) as GameObject;
        bookObj.GetComponent<BookObjScr>().activity = this;
        throw new System.NotImplementedException();
    }

    public void taskCompleted()
    {
        GameObject.Destroy(bookObj);
        activitySequenceManager.goToNextActivity();
        throw new System.NotImplementedException();
    }
}
