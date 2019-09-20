using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using RosSharp.RosBridgeClient;
using RosSharpMessages = RosSharp.RosBridgeClient.Messages;

/*
using RosSharp.RosBridgeClient.Messages.Geometry;
using RosSharp.RosBridgeClient.Messages.Navigation;
using RosSharp.RosBridgeClient.Messages.Sensor;
using RosSharp.RosBridgeClient.Messages.Standard;
using RosSharp.RosBridgeClient.Messages.Actionlib;
*/

namespace CSI.ROS
{
    public class ROSMessageGenerator : MonoBehaviour
    {
        // Constants
        public GameObject targetObject;

        void Update()
        {
            /*
            // If there is a target
            if (targetObject != null)
            {
                // Transmit target update
                bool success = RequestPosition(targetObject.transform.position);

                if (success){ Debug.Log("Message sent successfully."); }
                else { Debug.LogError("Message failed to send."); }
            }
            */
        }

        // Generate dummy message
        public bool DummyMessage()
        {
            // Dummy position request
            //Vector3 position = new Vector3(2.0f, 2.0f, 2.0f);

            return true;
        }
        // Generate position request message
        public bool RequestPosition(Vector3 position)
        {
            // Get the robot 
            GameObject robot = this.gameObject;
            // Get the robots ROSbridge
            GameObject rosBridgeObject = RobotUtilities.GetRobotROSBridge(robot);
            if (rosBridgeObject == null)
                return false;
            // Get the connection component
            RosConnector rosConnector = rosBridgeObject.GetComponent<RosConnector>();
            // Generate position set message
            RosSharpMessages.Geometry.Point geometryMessage = new RosSharpMessages.Geometry.Point();
            geometryMessage.x = position.x;
            geometryMessage.y = position.y;
            geometryMessage.z = position.z;
            // Get the associated publisher
            string PublisherTopic_GoalState = robot.GetComponent<RobotBehaviour>().PublisherTopic_GoalState;
            // Advertise geometry message
            string pub_id = rosConnector.RosSocket.Advertise<RosSharpMessages.Geometry.Point>(PublisherTopic_GoalState);
            Debug.Log("Requesting Position X(" + 
                position.x.ToString() + ") Y(" + 
                position.y.ToString() + ") Z(" + 
                position.z.ToString() + ")");

            // Publish the defined message
            try{ rosConnector.RosSocket.Publish(pub_id, geometryMessage);}
            catch{Debug.Log("Bad response from robot'" + robot.name + "'");}

            // Return 
            return true;
        }
        // Generate pose request message
        public bool RequestRotation(Quaternion rotation)
        {
            // Get the robot 
            GameObject robot = this.gameObject;
            // Get the robots ROSbridge
            GameObject rosBridgeObject = RobotUtilities.GetRobotROSBridge(robot);
            if (rosBridgeObject == null)
                return false;
            // Get the connection component
            RosConnector rosConnector = rosBridgeObject.GetComponent<RosConnector>();
            // Generate position set message
            RosSharpMessages.Geometry.Quaternion geometryMessage = new RosSharpMessages.Geometry.Quaternion();
            // Parameterise the message
            geometryMessage.w = rotation.w;
            geometryMessage.x = rotation.x;
            geometryMessage.y = rotation.y;
            geometryMessage.z = rotation.z;    
            
            // Get the associated publisher
            string PublisherTopic_GoalState = robot.GetComponent<RobotBehaviour>().PublisherTopic_GoalState;
            // Advertise geometry message
            string pub_id = rosConnector.RosSocket.Advertise<RosSharpMessages.Geometry.Quaternion>(PublisherTopic_GoalState);

            // Publish the defined message
            try { rosConnector.RosSocket.Publish(pub_id, geometryMessage); }
            catch { Debug.Log("Rotations request- bad ROS response '" + robot.name + "'"); }

            // Return 
            return true;
        }
        // Generate position and rotation request message
        public bool RequestPose(Vector3 position, Quaternion rotation)
        {
            // Get the robot 
            GameObject robot = this.gameObject;
            // Get the robots ROSbridge
            GameObject rosBridgeObject = RobotUtilities.GetRobotROSBridge(robot);
            if (rosBridgeObject == null)
                return false;
            // Get the connection component
            RosConnector rosConnector = rosBridgeObject.GetComponent<RosConnector>();
            // Get the associated publisher
            string PublisherTopic_GoalState = robot.GetComponent<RobotBehaviour>().PublisherTopic_GoalState;
            // Generate position set message
            RosSharpMessages.Geometry.Pose geometryMessage = new RosSharpMessages.Geometry.Pose();
            // Parameterise the message
            geometryMessage.orientation.w = rotation.w;
            geometryMessage.orientation.x = rotation.x;
            geometryMessage.orientation.y = rotation.y;
            geometryMessage.orientation.z = rotation.z;
            geometryMessage.position.x = position.x;
            geometryMessage.position.y = position.y;
            geometryMessage.position.z = position.z;
            // Advertise geometry message
            string pub_id = rosConnector.RosSocket.Advertise<RosSharpMessages.Geometry.Pose>(PublisherTopic_GoalState);

            // Publish the defined message
            try { rosConnector.RosSocket.Publish(pub_id, geometryMessage); }
            catch { Debug.Log("Pose request- bad ROS response '" + robot.name + "'"); }
            // Return 
            return true;
        }
    }
}