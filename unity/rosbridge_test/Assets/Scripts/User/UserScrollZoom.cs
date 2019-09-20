using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI
{
    [RequireComponent(typeof(UserFocus))]
    public class UserScrollZoom : MonoBehaviour
    {

        public float linearSpeed = 0.1f;
        public Camera targetCam;
        private Vector3 pivotPointScreen;
        private Vector3 pivotPointWorld;
        private Ray ray;
        private RaycastHit hit;

        // Use this for initialization
        void Start()
        {
            //Set the targetCam here if not assigned from inspector
            if (targetCam == null)
                targetCam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            //When the right mouse button is down,
            //set the pivot point around which the camera will rotate

                //Take the mouse position
                pivotPointScreen = Input.mousePosition;
                //Convert mouse position to ray
                // Then raycast using this ray to check if it hits something in the scene
                //**Converting the mousepositin to world position directly will
                //**return constant value of the camera position as the Z value is always 0
                ray = targetCam.ScreenPointToRay(pivotPointScreen);
                if (Physics.Raycast(ray, out hit))
                {
                    //If it hits something, then we will be using this as the pivot point
                    pivotPointWorld = hit.point;
                }

            Vector3 relativeVector = pivotPointWorld - transform.position;

            // Scale by the zoom
            targetCam.transform.localPosition += relativeVector.normalized * linearSpeed * Input.GetAxis("Mouse ScrollWheel");
        }
    }
}



