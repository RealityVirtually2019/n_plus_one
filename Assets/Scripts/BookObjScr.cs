using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObjScr : MonoBehaviour {
    public BookActivity activity;
    public bool isImageShowing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isImageShowing)
        {
            StartCoroutine(waitAndThenFinish());
            isImageShowing = false;
        }
	}

    IEnumerator waitAndThenFinish()
    {
        yield return new WaitForSeconds(2);
        activity.taskCompleted();
    }
}
