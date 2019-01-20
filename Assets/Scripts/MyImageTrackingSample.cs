// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2018 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using System.Collections.Generic;

namespace MagicLeap
{
    /// <summary>
    /// This provides an example of interacting with the image tracker visualizers using the controller
    /// </summary>
    [RequireComponent(typeof(PrivilegeRequester))]
    /// 
    public class MyImageTrackingSample : MonoBehaviour
    {
        #region Public Enum
        public enum ViewMode : int
        {
            All = 0,
            AxisOnly,
            TrackingCubeOnly,
            DemoOnly,
        }

        public GameObject[] TrackerBehaviours;
        #endregion

        #region Private Variables
        private ViewMode _viewMode = ViewMode.All;

        [SerializeField, Tooltip("Image Tracking Visualizers to control")]
        private ImageTrackingVisualizer[] _visualizers;

        private PrivilegeRequester _privilegeRequester;

        private bool _hasStarted = false;
        #endregion

        #region Unity Methods

        // Using Awake so that Privileges is set before PrivilegeRequester Start
        void Awake()
        {


            // If not listed here, the PrivilegeRequester assumes the request for
            // the privileges needed, CameraCapture in this case, are in the editor.
            _privilegeRequester = GetComponent<PrivilegeRequester>();
            //_privilegeRequester = GameObject.FindGameObjectWithTag("ActivitySequenceManager").GetComponent<PrivilegeRequester>();

            // Before enabling the MLImageTrackerBehavior GameObjects, the scene must wait until the privilege has been granted.
            _privilegeRequester.OnPrivilegesDone += HandlePrivilegesDone;
        }

        /// <summary>
        /// Unregister callbacks and stop input API.
        /// </summary>
        void OnDestroy()
        {
            if (_privilegeRequester != null)
            {
                _privilegeRequester.OnPrivilegesDone -= HandlePrivilegesDone;
            }
        }

        /// <summary>
        /// Cannot make the assumption that a privilege is still granted after
        /// returning from pause. Return the application to the state where it
        /// requests privileges needed and clear out the list of already granted
        /// privileges. Also, unregister callbacks.
        /// </summary>
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {

                UpdateImageTrackerBehaviours(false);

                _hasStarted = false;
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Control when to enable to image trackers based on
        /// if the correct privileges are given.
        /// </summary>
        void UpdateImageTrackerBehaviours(bool enabled)
        {
            foreach (GameObject obj in TrackerBehaviours)
            {
                obj.SetActive(enabled);
            }
        }

        /// <summary>
        /// Once privileges have been granted, enable the camera and callbacks.
        /// </summary>
        void StartCapture()
        {
            if (!_hasStarted)
            {
                UpdateImageTrackerBehaviours(true);



                _hasStarted = true;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Responds to privilege requester result.
        /// </summary>
        /// <param name="result"/>
        void HandlePrivilegesDone(MLResult result)
        {
            if (!result.IsOk)
            {
                if (result.Code == MLResultCode.PrivilegeDenied)
                {
                    Instantiate(Resources.Load("PrivilegeDeniedError"));
                }

                Debug.LogErrorFormat("Error: ImageTrackingExample failed to get requested privileges, disabling script. Reason: {0}", result);
                enabled = false;
                return;
            }

            Debug.Log("Succeeded in requesting all privileges");
            StartCapture();
        }
        #endregion
    }
}
