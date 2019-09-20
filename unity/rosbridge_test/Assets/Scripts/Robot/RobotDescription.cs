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
        public int robotID;
        public string robotName = "Unassigned";
        public string manufacturer = "Unassigned";

        private UrdfRobot robotURDF;

        public Material hologramMaterial;
        private GameObject hologramObject;
        // UI Properties
        private Vector3 UIoffset = new Vector3(0.5f, 0.2f, 0);
        public GameObject UIprefab;

        // A parameterised list of the joint labels
        public List<string> JointNames;

        // Generate the reach hologram
        private void GenerateReachHologram()
        {
            // Get the robots spherical hologram
            if (hologramObject == null)
            {
                hologramObject = RobotUtilities.GetSphericaHologram(this.gameObject);
                hologramObject.GetComponent<Renderer>().material = hologramMaterial;
                hologramObject.name = "FieldOfReach";
            }
            hologramObject.SetActive(false);
        }
        // Show the robot hologram 
        public void ShowReachHologram()
        {
            hologramObject.SetActive(true);
        }
        // Hide the robot hologram
        public void HideReachHologram()
        {
            hologramObject.SetActive(false);
        }

        // Generate the robot GUI
        private void GenerateRobotGUI()
        {
            // If the object already exists
            if (UIprefab != null)
                return;

            Debug.LogWarning("Generating Robot Description");

            Vector3 UIposition = this.transform.position + UIoffset;
            Quaternion UIrotation = Quaternion.identity;

            // Needs to be constructed
            GameObject robotUI = Instantiate(UIprefab, UIposition, UIrotation);
            Transform UiCanvas = UIprefab.transform.Find("Canvas");

            // Find the Title box
            GameObject titleBox = UiCanvas.Find("Title").gameObject;
            titleBox.GetComponent<Text>().text = "[ID: " + this.GetInstanceID().ToString() + "] " + this.name;

            // Find the Subtitle box
            GameObject subtitleBox = UiCanvas.Find("Subtitle").gameObject;
            subtitleBox.GetComponent<Text>().text = "Manufacturer: " + GetComponent<RobotDescription>().manufacturer;

            // Find the First text box
            Transform panelA = UiCanvas.Find("Panel A");
            GameObject TextBoxA = panelA.Find("Text A").gameObject;
            TextBoxA.GetComponent<Text>().text = "This is some general overview information about the " + this.name + " robotic system.";

            // Alive time
            string lowerTextBox = "Alive time: " + GetComponent<RobotBehaviour>().GetRobotUpTime().ToString() + "\n";

            // Get a summary of the joint positions
            List<UrdfJoint> urdfJointList = RobotUtilities.GetURDFJointList(this.gameObject);

            for (int i = 1; i < urdfJointList.Count; i++)
            {
                string jointName = urdfJointList[i].JointName;
                float jointPosition = urdfJointList[i].GetPosition();

                // Append the string
                lowerTextBox += "Joint Name: " + jointName + "\n Position: " + jointPosition + "\n";
            }

            // Find the Second text box
            Transform panelB = UiCanvas.Find("Panel B");
            GameObject TextBoxB = panelB.Find("Text B").gameObject;

            TextBoxB.GetComponent<Text>().text = lowerTextBox;

            // Return the new UI
            return;
        }
        // Show the robot GUI
        public void ShowRobotGUI()
        {
            UIprefab.SetActive(true);
            Debug.Log("Showing robot GUI");
        }
        // Hide the robot GUI
        public void HideRobotGUI()
        {
            UIprefab.SetActive(false);
            Debug.Log("Hiding robot GUI");
        }

        // Initialisation loop
        public void Start()
        {
            // If not provided with an ID, assign unique ID
            robotID = GetInstanceID();
            // If the robot has a URDF description, extract its joint names
            robotURDF = gameObject.GetComponent<UrdfRobot>();
            if (robotURDF != null)
            {
                // Retain the list of joint names from the URDF description
                List<string> JointNames = RobotUtilities.GetJointNames(gameObject);
            }

            // Populate the reach hologram
            GenerateReachHologram();
            // Populate the GUI
            GenerateRobotGUI();
        }
        // Update loop
        public void Update()
        {

        }
    }
}