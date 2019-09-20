using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using RosSharp.Urdf;
using CSI;


namespace CSI
{
    [Serializable]
    public class RobotDescription : MonoBehaviour
    {
        // Basic robot parameters
        public string robotName = "Unassigned";
        public int robotID;

        private UrdfRobot robotURDF;
        private GameObject hologramObject;
        public Material hologramMaterial;

        // A parameterised list of the joint labels
        public List<string> jointNames;

        // Initialisation loop
        public void Start()
        {
            // If not provided with an ID, assign unique ID
            robotID = GetInstanceID();

            // Get the robots spherical
            if (hologramObject == null)
            {
                hologramObject = RobotVisuals.GetSphericaHologram(this.gameObject);
                hologramObject.GetComponent<Renderer>().material = hologramMaterial;
                hologramObject.name = "FieldOfReach";
            }
            hologramObject.SetActive(false);

            // If the robot has a URDF description, extract its joint names
            robotURDF = this.gameObject.GetComponent<UrdfRobot>();
            if (robotURDF != null)
            {
                // Retain the list of joint names from the URDF description
                List<string> jointNames = RobotUtilities.GetJointList(this.gameObject);
            }
        }

        // Update loop
        public void Update()
        {

        }

        // Return the hologram object variable
        public GameObject GetHologram()
        {
            return hologramObject;
        }


    }
}