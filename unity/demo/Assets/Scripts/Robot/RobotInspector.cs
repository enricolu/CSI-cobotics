using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI
{
    [RequireComponent(typeof(UserFocus))]   // Require the camera to have the "UserFocus"
    public class RobotInspector : MonoBehaviour
    {
        // UI Properties
        private Vector3 UIoffset = new Vector3(0.5f, 0.2f, 0);

        public GameObject robotUI;
        private 

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            // Update on behaviour
            UpdateOnHoverBehaviour();
            // Update on select behaviour
            UpdateOnSelectBehaviour();
        }

        // Update hover interactions
        private void UpdateOnHoverBehaviour()
        {
            // Get the object hovered over
            GameObject hoverObject = transform.GetComponent<UserFocus>().GetHoverOverObject();

            Debug.Log("Hovering on: " + hoverObject.name);

            if (hoverObject == null || !RobotUtilities.IsRobot(hoverObject))
                return;

            hoverObject.GetComponent<RobotBehaviour>().DisplayHologram();
        }
        // Update selection interactions
        private void UpdateOnSelectBehaviour()
        {
            GameObject selectedObject = transform.GetComponent<UserFocus>().GetSelectedObject();
            if (selectedObject == null || !RobotUtilities.IsRobot(selectedObject))
                return;

            selectedObject.GetComponent<RobotBehaviour>().HideHologram();
        }

        // Create an annotative UI adjacent to the robot
        //public GameObject GetRobotUI(Vector3 UIposition, Quaternion UIrotation)
        public GameObject GetRobotUI()
        {
            // If the object already exists
            if (robotUI != null)
                return robotUI;
            /*
            Debug.LogWarning("Generating Robot Description");

            Vector3 UIposition = this.transform.position + UIoffset;
            Quaternion UIrotation = Quaternion.identity;

            // Get the component describing its behaviour
            RobotBehaviour robotBehaviour = this.GetComponent<RobotBehaviour>();

            // Needs to be constructed
            robotUI = Instantiate(UIprefab, UIposition, UIrotation);
            Transform UiCanvas = robotUI.transform.Find("Canvas");

            // Find the Title box
            GameObject titleBox = UiCanvas.Find("Title").gameObject;
            titleBox.GetComponent<Text>().text = "[ID: " + this.GetInstanceID().ToString() + "] " + this.name;

            // Find the Subtitle box
            GameObject subtitleBox = UiCanvas.Find("Subtitle").gameObject;
            subtitleBox.GetComponent<Text>().text = "Manufacturer: " + robotBehaviour.manufacturer;

            // Find the First text box
            Transform panelA = UiCanvas.Find("Panel A");
            GameObject TextBoxA = panelA.Find("Text A").gameObject;
            TextBoxA.GetComponent<Text>().text = "This is some general overview information about the " + this.name + " robotic system.";

            // Alive time
            string lowerTextBox = "Alive time: " + robotBehaviour.GetRobotUpTime().ToString() + "\n";

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
            */
            // Return the new UI
            return null;
        }
        // Destroy a robots annotative UI
        public void DestroyRobotUI()
        {
            // Simply destroy the UI clone
            //Destroy(RobotUI);
        }

        /*
        // Highlight the object with a colour
        void OnPostRender()
        {
            if (highlightObject == null)
                return;

            GameObject go = highlightObject;
            highlightMaterial.SetPass(0);
            Component[] meshes = go.GetComponentsInChildren(typeof(MeshFilter));
            foreach (MeshFilter m in meshes)
            {
                Graphics.DrawMeshNow(m.sharedMesh, m.transform.position, m.transform.rotation);
            }
        }
        */
    }
}


