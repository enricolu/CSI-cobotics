using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using RosSharp.Urdf;

namespace CSI
{
    [Serializable]
    [RequireComponent(typeof(RobotDescription))]
    public class RobotBehaviour : MonoBehaviour
    {
        // Host robot information
        private GameObject robot;                           // Reference to robot GameObject
        private float runtime = 0f; 

        // Connection properties
        public GameObject ROSConnectorPrefab;
        public GameObject ROSbridgeObject;                  // Reference to ROS-Bridge object
        //private List<string> JointNames;
        public string ROSAddress = "192.168.0.1";
        public string ROSPort = "9090";

        // The ROS message/topic containers
        public string PublisherTopic_JointState     = "publish_joint_states";
        public string SubscriberTopic_JointState    = "joint_states"; // Default joint state topics
        public string PublisherTopic_GoalState      = "arm_controller/follow_joint_trajectory/goal";
        public string SubscriberTopic_GoalState     = "subscribe_goal_states";  // Default goal state topics

        // Simple get functions
        public float GetRobotUpTime()
        {
            return runtime;
        }

        /// <summary>
        /// CONNECTION METHODS
        /// </summary>
        /// <returns></returns>
        // Create a ROS bridge for this robot
        public bool DefineROSConnection()
        {
            // CONSTANTS
            robot = this.gameObject;                                            // Get the robot (ur5)
            
            string connectionLabel = "ROSBridge(" + robot.name + ")";
            // Attempt to find the connection object is tagged 'ROSBridge'
            ROSbridgeObject = RobotUtilities.FindChildWithTag(robot.transform, "ROSBridge");
            // Check if a connection container exist
            if (ROSbridgeObject == null)
            {
                try
                {
                    // Instantiate the ROS bridge for this object
                    ROSbridgeObject = (GameObject)Instantiate(ROSConnectorPrefab, robot.transform); // Instantiate where the robot is                                                                     // Organise the bridges into substructure
                    ROSbridgeObject.name = connectionLabel;
                    Debug.Log("ROS-bridge created: '" + connectionLabel + "'");                     // Display for transparency
                }
                catch
                {
                    Debug.Log("Unable to instantiate Ros-Bridge");
                    return false;
                }
            }
            else
            {
                Debug.Log("ROS-bridge exists named '" + connectionLabel + "'"); // Display for transparency
            }

            //////////// DEFINE THE ROS-BRIDGE PARAMETERS ////////////////
            // Ensure the component is positioned where the robot is 
            ROSbridgeObject.transform.SetParent(this.transform);
            // Get ROS network address from the inspector
            string hostAddress = "ws://" + ROSAddress.ToString() + ":" + ROSPort.ToString();
            // Override ROS bridge URL:PORT
            ROSbridgeObject.GetComponent<RosConnector>().RosBridgeServerUrl = hostAddress;

            //////////////// ENABLE/DISABLE COMPONENTS ///////////////////
            // Ensure the basic components are active
            ROSbridgeObject.GetComponent<PoseStampedPublisher>().enabled = true;
            // Other instruments off (for now)
            ROSbridgeObject.GetComponent<JoySubscriber>().enabled = false;
            ROSbridgeObject.GetComponent<ImagePublisher>().enabled = false;

            //////////// JOINT STATE PATCHER CONFIGURATION ///////////////
            JointStatePatcher robotJointStatePatcher = ROSbridgeObject.GetComponent<JointStatePatcher>();
            // Get the robots URDF description & assign it to the jointStatePatcher
            UrdfRobot robotURDF = robot.GetComponent<UrdfRobot>();
            // Assign the robot URDF parameters
            robotJointStatePatcher.UrdfRobot = robotURDF;
            // Ensure the joint_state subscriber is initialised
            robotJointStatePatcher.SetSubscribeJointStates(true); // Enable the component
            ROSbridgeObject.GetComponent<JointStateSubscriber>().Topic = SubscriberTopic_JointState;
            // Ensure the joint_state publisher is initialised
            robotJointStatePatcher.SetPublishJointStates(true);   // Enable the component  
            ROSbridgeObject.GetComponent<JointStatePublisher>().Topic = PublisherTopic_JointState;
            
            //////////// POSE STAMPED PUBLISHER ///////////
            /* Get the transform for the game-object at the end of the robot's kinematic 
             * chain. */
            // - It is assumed that the final URDF kinematic link is the tool
            // - This is only valid for serial-link style robots.
            // - [TO-DO] Intelligent tool transform finding
            UrdfJoint[] jointURDF = robotURDF.GetComponentsInChildren<UrdfJoint>();
            if (jointURDF != null)
            {
                // Get the final URDF joint 
                GameObject Tool = jointURDF[jointURDF.Length - 1].gameObject;
                // Assign the tool transform to the pose stamped publisher
                ROSbridgeObject.GetComponent<PoseStampedPublisher>().PublishedTransform = Tool.transform;
            }
            else
            {
                Debug.LogError("Unable to determine tool transform for robot: " + robot.name);
            }

            // Return configured ROS-Bridge
            return true;
        }
        // Remove the ROS bridge for this robot
        public bool RemoveROSConnection()
        {
            // Define Game-object associated with the connection
            string connectionLabel = "ROSBridge(" + this.gameObject.name + ")";
            // Find the robots ROS-bridge
            ROSbridgeObject = RobotUtilities.FindChildWithTag(this.gameObject.transform, "ROSBridge");

            // Check if a connection container exist
            bool isSuccessful;
            if (ROSbridgeObject == null)
            {
                // Display for transparency
                Debug.Log("ROS-bridge does not exist named '" + connectionLabel + "'");
                isSuccessful = false;
            }
            else
            {
                // Destroy the ROS bridge
                DestroyImmediate(ROSbridgeObject);
                // Display for transparency
                Debug.Log("ROS-bridge '" + connectionLabel + "' Destroyed");
                isSuccessful = true; // Mark operation successful
            }
            return isSuccessful;
        }

        // Make the robot hologram visible
        public void DisplayHologram()
        {
            GameObject ROMhologram = GetComponent<RobotDescription>().GetHologram();
            ROMhologram.SetActive(true);
        }
        // Hide the robot hologram
        public void HideHologram()
        {
            GameObject ROMhologram = GetComponent<RobotDescription>().GetHologram();
            ROMhologram.SetActive(false);
        }

        /*
        // Behaviour on mouse over
        public void OnMouseEnter()
        {
            // On mouse over, show the hologram
            DisplayHologram();
        }
        // Behaviour on mouse exit
        public void OnMouseExit()
        {
            HideHologram();
        }
        */

        // The update function
        public void FixedUpdate()
        {
            runtime += Time.deltaTime;
        }
    }
}