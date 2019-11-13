using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.user
{
    public class MultiCameraController : MonoBehaviour
    {
        // List camera options
        public List<Camera> viewPoints;
        private int index = 0;
        // Display current camera
        public Camera currentCamera;

        // Start 
        void Start()
        {
            // Initial camera selection
            GetUniqueViewPoint(viewPoints[index]);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Iterate
                index += 1;
                // Catch the vector end
                if (index > (viewPoints.Count - 1))
                {
                    index = 0;
                }

                Debug.Log("Switching to camera: " + index);

                // Cut to camera 
                CutToIndex(index);
            }
        }
        
        // This function cycles through the List of view points
        public void CutToIndex(int ind)
        {
            // Disable previous camera (only one can be active at once)
            DisableCamera(currentCamera);
            // Set new camera
            EnableCamera(viewPoints[ind]);
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
        // Enable camera
        private void EnableCamera(Camera viewPoint)
        {
            viewPoint.enabled = true;
            //viewPoint.gameObject.SetActive(false);
            viewPoint.GetComponent<AudioListener>().enabled = true;
            // Record as the current camera
            currentCamera = viewPoint;
        }
        // Disable camera
        private void DisableCamera(Camera viewPoint)
        {
            viewPoint.enabled = false;
            viewPoint.GetComponent<AudioListener>().enabled = false;
        }
    } 
}