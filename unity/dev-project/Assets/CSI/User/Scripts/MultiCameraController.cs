using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.camera
{
    public class MultiCameraController : MonoBehaviour
    {
        [Header("Current Camera")]
        // Display current camera
        [Tooltip("Current Camera.")]
        public Camera currentCamera;        
        
        [Header("Available Cameras")]
        [Tooltip("Available view-points.")]
        public List<Camera> viewPoints;

        // Index container
        private int index = 0;
        
        void Start()
        {
            // Get current camera ID
            if (null != currentCamera)
            {
                if (!CameraIsAViewPoint(currentCamera))
                {
                    // Append the current camera to top of list
                    List<Camera> temp = new List<Camera>();
                    temp.Add(currentCamera);
                    foreach (Camera camera in viewPoints)
                    {
                        temp.Add(camera);
                    }
                    // Reassign
                    viewPoints = temp;  
                }
            }
            else
            {
                // Assign first in list by default
                if (null != viewPoints[0])
                {            
                    Debug.Log("No camera assigned, defaulting to first list item.");
                    currentCamera = viewPoints[0];
                }
                else 
                {
                    Debug.LogError("No default camera assigned.");
                }
            }
            // Ensure the current camera is the only active camera
            GetUniqueViewPoint(currentCamera);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextCamera();
            }
        }
        
        // Ensure only one active camera
        private void GetUniqueViewPoint(Camera uniqueCamera)
        {
            // Get the numer of active cameras
            if (Camera.allCamerasCount > 1)
            {
                //Debug.Log("More than one camera active, getting unique view point.");
                // Disable all cameras
                Camera[] cameraVector = Camera.allCameras;
                foreach (Camera unusedCamera in cameraVector)
                {
                    // Disable all other cameras
                    DisableCamera(unusedCamera);
                }
            }
            // Set the current camera to be the unique camera
            EnableCamera(uniqueCamera);
        }
        // Confirm given camera is the view-point list
        private bool CameraIsAViewPoint(Camera camera)
        {
            // Sanity check
            if (null == camera)
                return false;

            int currentID = camera.GetInstanceID();
            
            // Scan for current camera
            foreach (Camera view in viewPoints)
            {
                // Skip empty array elements
                if (null == view)
                    continue;
                // Get Camera ID and compare
                int viewID = view.GetInstanceID();
                if (viewID == currentID)
                {
                    return true;
                }
            }
            return false;
        }

        // Cycle to next camera in the list
        public  void NextCamera()
        {
            // Iterate  
            index++;
            // Check for vector end
            if (index > (viewPoints.Count-1) || null == viewPoints[index])
            {
                index = 0;
            }
            // Display
            Debug.Log("Switching to camera: " + index);
            // Cycle cameras
            DisableCamera(currentCamera);
            EnableCamera(viewPoints[index]);
        }        
        // Enable camera
        private bool EnableCamera(Camera viewPoint)
        {
            viewPoint.enabled = true;
            //viewPoint.gameObject.SetActive(false);
            viewPoint.GetComponent<AudioListener>().enabled = true;
            // Record as the current camera
            currentCamera = viewPoint;
            return true;
        }
        // Disable camera
        private bool DisableCamera(Camera viewPoint)
        {
            viewPoint.enabled = false;
            viewPoint.GetComponent<AudioListener>().enabled = false;
            return true;
        }
    } 
}