using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class ThumbsUpActivity : MonoBehaviour, IActivity {
    public GameObject prefab;

    public void play()
    {
        GameObject thumbsUp = Instantiate(Resources.Load("ThumbsUpObj")) as GameObject;
        throw new System.NotImplementedException();
    }

    public void taskCompleted()
    {
        throw new System.NotImplementedException();
    }
}
