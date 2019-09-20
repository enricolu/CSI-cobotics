﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI
{
    [RequireComponent(typeof(UserFocus))]
    public class UserClickRotate : MonoBehaviour
    {

        public float angularSpeed = 1.0f;
        public Camera targetCam;
        private Vector3 pivotPointScreen;
        private Vector3 pivotPointWorld;
        private Ray ray;
        private RaycastHit hit;
        private float zAngle = 0;
        private int mouseButton = 0;

        // Use this for initialization
        void Start()
        {
            //Set the targetCam here if not assigned from inspector
            if (targetCam == null)
                targetCam = Camera.main;
            // Get and fix the z-axis angle
            zAngle = targetCam.transform.localRotation.z;
        }

        // Update is called once per frame
        void Update()
        {
            //When the right mouse button is down,
            //set the pivot point around which the camera will rotate
            //Also hide the cursor
            if (Input.GetMouseButtonDown(mouseButton))
            {
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
                //targetCam.transform.LookAt (pivotPointWorld);
                Cursor.visible = false;
            }
            else if (Input.GetMouseButtonUp(mouseButton))
            {
                Cursor.visible = true;
            }
            if (Input.GetMouseButton(mouseButton))
            {
                //Rotate the camera X wise
                targetCam.transform.RotateAround(pivotPointWorld, Vector3.up, angularSpeed * Input.GetAxis("Mouse X"));
                //Rotate the camera Y wise
                targetCam.transform.RotateAround(pivotPointWorld, Vector3.right, angularSpeed * Input.GetAxis("Mouse Y"));
                targetCam.transform.localEulerAngles = new Vector3(targetCam.transform.localEulerAngles.x, targetCam.transform.localEulerAngles.y, zAngle);
            }
        }
    }
}
