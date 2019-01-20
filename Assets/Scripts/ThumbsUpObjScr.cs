using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ThumbsUpObjScr : MonoBehaviour {
    public GameObject cube;
    public GameObject sphere;
    public ThumbsUpActivity activity;
    public AudioSource audio;
    public AudioClip best;
    public AudioClip ohhow;
    public AudioClip shareSomething1;

    private Vector3 initpos;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        MLHands.Start();
        MLHandKeyPose[] _gestures = new MLHandKeyPose[]
        {
            MLHandKeyPose.Thumb
        };

        MLHands.KeyPoseManager.EnableKeyPoses(_gestures, true, false);
        initpos = sphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThumbsUpGesture(MLHands.Left) || isThumbsUpGesture(MLHands.Right))
        {
            //cube.SetActive(true);
            sphere.transform.position = MLHands.Left.Thumb.KeyPoints[0].Position;
            StartCoroutine(waitAndThenFinish());
        }
        else
        {
            //cube.SetActive(false);
            sphere.transform.position = initpos;
        }
    }

    IEnumerator waitAndThenFinish()
    {
        audio.clip = best;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = ohhow;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        //yield return new WaitUntil(() => (audio.isPlaying == false));
        audio.clip = shareSomething1;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);

        activity.taskCompleted();
    }

    private void OnDestroy()
    {
        MLHands.Stop();
    }

    private bool isThumbsUpGesture(MLHand hand)
    {
        return (hand != null && (hand.KeyPose == MLHandKeyPose.Thumb) && hand.KeyPoseConfidence > 0.9f);
    }

}
