using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroObjScr : MonoBehaviour {
    public IntroActivity activity;
    public AudioSource audio;
    public AudioClip logoSound;
    public AudioClip psstSound;
    public AudioClip firstINeedSound;
    public AudioClip okayListen;
    public GameObject cube;

    private bool isDone = false;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startTheScene();
    }

    // Update is called once per frame
    void Update()
    {
        //if (audio.isPlaying)
        //    cube.SetActive(true);
        //if(!audio.isPlaying && isDone)
        //{
        //    waitAndThenFinish();
        //}
    }

    private void startTheScene()
    {
        //audio.PlayOneShot(logoSound);
        audio.clip = logoSound;
        audio.Play();
        StartCoroutine(waitAndPlayPsst(25));
    }

    IEnumerator waitAndPlayPsst(int sec)
    {
        yield return new WaitForSeconds(sec);
        //audio.PlayOneShot(psstSound);
        audio.clip = psstSound;
        audio.Play();
        //waitAndThenFinish((int)psstSound.length);
        yield return new WaitForSeconds(audio.clip.length + 1);
        audio.clip = okayListen;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length + 1);
        //yield return new WaitUntil(() => (audio.isPlaying == false));
        audio.clip = firstINeedSound;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length + 1);
        activity.taskCompleted();
    }

    IEnumerator waitAndThenFinish(int duration)
    {
        yield return new WaitForSeconds(duration);
        //yield return new WaitUntil(() => (audio.isPlaying == false));
        activity.taskCompleted();
    }
}
