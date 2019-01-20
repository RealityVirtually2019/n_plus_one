using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ExitButtonControlScr : MonoBehaviour {
    public GameObject exitObj;
    private MLInputController _controller;
    private bool _enabled = false;
    private bool _bumper = false;


    void Awake()
    {
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }

    void Update()
    {
        if (_bumper && _enabled)
        {
            exitObj.transform.position = _controller.Position;
        }
        CheckControl();
    }

    void CheckControl()
    {
        if (_controller.TriggerValue > 0.2f && _enabled)
        {
            _bumper = false;
        }
        //else if (_controller.Touch1PosAndForce.z > 0.0f && _enabled)
        //{
        //    float X = _controller.Touch1PosAndForce.x;
        //    float Y = _controller.Touch1PosAndForce.y;
        //    Vector3 forward = Vector3.Normalize(Vector3.ProjectOnPlane(transform.forward, Vector3.up));
        //    Vector3 right = Vector3.Normalize(Vector3.ProjectOnPlane(transform.right, Vector3.up));
        //    Vector3 force = Vector3.Normalize((X * right) + (Y * forward));
        //    _cube.transform.position += force * Time.deltaTime * _moveSpeed;
        //}
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {
        if ((button == MLInputControllerButton.Bumper && _enabled))
        {
            //button.transform.position = _controller.Position;
            _bumper = true;
        }
    }

    void OnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.HomeTap)
        {
            _enabled = !_enabled;

            if (_enabled)
            {
                exitObj.SetActive(true);
            }
            else
            {
                exitObj.SetActive(false);
                GameObject.FindGameObjectWithTag("ActivitySequenceManager").GetComponent<ActivitySequenceManager>().goToNextActivity();
            }
        }

        if (button == MLInputControllerButton.Bumper)
        {
            _bumper = false;
        }
    }

}
