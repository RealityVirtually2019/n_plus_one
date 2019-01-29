using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObjScr : MonoBehaviour {
    public BookActivity activity;
    public bool isImageShowing = false;
    public AudioSource audio;
    public AudioClip best;
    public AudioClip genius;
    public AudioClip dramatrack;
    public bool imageAlreadySeen = false;
    public bool playDramaTrack = true;

    void Update () {
		if(isImageShowing)
        {
            if(!imageAlreadySeen)
                StartCoroutine(playNarrSound());
            else if(playDramaTrack)
            {
                playDramaTrack = false;
                audio.clip = dramatrack;
                audio.Play();
            }
        } else if(imageAlreadySeen)
        {
            activity.taskCompleted();
        }

    }

    IEnumerator playNarrSound()
    {
        audio.clip = best;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length + 1);
        audio.clip = genius;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length + 1);
    }
}
