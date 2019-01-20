using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroObjScr : MonoBehaviour {
    public IntroActivity activity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waitAndThenFinish()
    {
        yield return new WaitForSeconds(2);
        activity.taskCompleted();
    }
}
