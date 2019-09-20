using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.Urdf;

namespace CSI
{
    [RequireComponent(typeof(UserFocus))]   // Require the camera to have the "UserFocus"
    public class RobotInspector : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Get the object hovered over
            GameObject hoverOverObject = transform.GetComponent<UserFocus>().GetHoverOverObject();

            // Update on behaviour
            UpdateOnHoverBehaviour(hoverOverObject);

            GameObject selectedObject = transform.GetComponent<UserFocus>().GetSelectedObject();

            // Update on select behaviour
            UpdateOnSelectBehaviour(selectedObject);
        }

        // Update hover interactions
        private void UpdateOnHoverBehaviour(GameObject hoverObject)
        {
            // Get the object hovered over
            if (hoverObject == null)
                return;

            // For clarity
            Debug.Log("Hovering on: " + hoverObject.name);

            if (!RobotUtilities.IsRobot(hoverObject))
                return;

            GameObject hoverRobot = RobotUtilities.FindMaximalParentByTag(hoverObject.transform, RobotUtilities.GetRobotTag());

            
            
            hoverRobot.GetComponent<RobotDescription>().ShowReachHologram(); 
        }
        // Update selection interactions
        private void UpdateOnSelectBehaviour(GameObject selectedObject)
        {
            // If the current selected object is not a robot or is empty, skip
            if (selectedObject == null || !RobotUtilities.IsRobot(selectedObject))
                return;

            GameObject selectedRobot = RobotUtilities.FindMaximalParentByTag(selectedObject.transform, RobotUtilities.GetRobotTag());

            Debug.Log("Selected robot: " + selectedRobot.name);

            // Select the robot
            selectedRobot.GetComponent<RobotDescription>().ShowRobotGUI();
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


