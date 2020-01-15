using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RosSharp.RosBridgeClient;
using RosSharp.Urdf;

namespace CSI.ROS
{
    public class ROSInterface : MonoBehaviour
    {
        /*
         * This connector object is designed to be a wrapper for the RosSharp library. 
         * It provides quick access for generic robot configurations.
         */

        // Get connection parameters from inputs
        public string networkAddress;
        public int timeOut { get; set; }
        public string uniqueID;
        // internal reference
        private UrdfRobot urdfRobot;

        /*
         * Component behaviours
         */
        // On awake 
        void Awake()
        {
            // Get entity handle
            GameObject robot = GetConnectedEntity();
            // Get a reference to the entities urdf
            urdfRobot = robot.GetComponent<UrdfRobot>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsConnected())
            {
                Debug.Log("[" + this.name + "] Ros connector connected.");
            }
            else
            {
                Debug.Log("[" + this.name + "] Ros connector NOT connected.");
            }
        }

        /*
        * Connection operations
        */
        // Check we are connected to a ROS network
        public bool IsConnected()
        {
            // In ros-sharp
            RosConnector rosConnector = this.gameObject.GetComponent<RosConnector>();
            return rosConnector.IsConnected();
        }
        // Create a connection to a ROS network
        public bool Connect()
        {
            // Get the RSC connector
            RosConnector rosConnector = this.gameObject.GetComponent<RosConnector>();

            // If present, enable
            if (null != rosConnector)
            {
                rosConnector.enabled = true;
            }
            else
            {
                // Create a ROS connector
                rosConnector = this.gameObject.AddComponent<RosConnector>();
                rosConnector.RosBridgeServerUrl = networkAddress;
                rosConnector.Timeout = timeOut;
            }
            return IsConnected();
        }
        // Remove the ROSbridge
        public void Disconnect()
        {
            //Debug.Log("[" + this.name+"] Destroying connection to" + this.gameObject.name + "@" + address + ":" + port);
            // Destroy the component
            this.enabled = false;
        }
        // Get parent object
        private GameObject GetConnectedEntity()
        {
            return this.transform.parent.gameObject;
        }

        /*
         * Create different data transfer patches
         */
        // Generic joint angle publisher creation
        public void CreateJointStatePublisher(string topic, UrdfRobot urdfObject)
        {
            // Create the joint angle publisher component
            //RSC.JointStatePublisher publisher = this.gameObject.AddComponent<RSC.JointStatePublisher>();
            // Parameterise the publisher
            //publisher.Topic = topic;
            //publisher.FrameId = uniqueID.ToString();
            
            // Sanity check
            if (null == urdfObject)
            {
                Debug.LogError("[" + this.name + "] Urdf is not valid or is null.");
                return;
            }
            /*
            // Check for other components
            if (null != GetComponent<JointStatePublisher>())
            {
                // Clear 
                GetComponent<JointStatePublisher>()?.JointStateReaders.Clear();
                // Destroy existing joint readers
                foreach (JointStateReader reader in urdfObject.GetComponentsInChildren<JointStateReader>())
                    reader.transform.DestroyImmediateIfExists<JointStateReader>();
            }

            JointStatePublisher jointStatePublisher = transform.AddComponentIfNotExists<JointStatePublisher>();
            jointStatePublisher.JointStateReaders = new List<JointStateReader>();

            foreach (UrdfJoint urdfJoint in urdfObject.GetComponentsInChildren<UrdfJoint>())
            {
                if (urdfJoint.JointType != urdfObject.JointTypes.Fixed)
                    jointStatePublisher.JointStateReaders.Add(urdfJoint.transform.AddComponentIfNotExists<JointStateReader>());
            }
            */
        }
        // Generic image subscriber creation
        public void CreateJointStateSubscriber(string topic, UrdfRobot urdfObject)
        {
            // Create the joint angle subscriber component
            //JointStateSubscriber subscriber = this.gameObject.AddComponent<JointStateSubscriber>();
            // Parameterise the subscriber
            //subscriber.Topic = topic;

            // Sanity check
            if (null == urdfObject)
            {
                Debug.LogError("[" + this.name + "] Urdf is not valid or is null.");
                return;
            }
            /*
            // Robot joint states
            JointStatePatcher jointStatePatcher = this.gameObject.GetComponent<JointStatePatcher>();
            // Handle creation
            if (null == jointStatePatcher)
            {
                // Create if necessary
                jointStatePatcher = this.gameObject.AddComponent<JointStatePatcher>();
                // Define to be a publisher
                jointStatePatcher.SetPublishJointStates(false);
            }
            // Pass the URDF robot
            jointStatePatcher.UrdfRobot = urdfEntity;
            // Define to be a subscriber
            jointStatePatcher.SetSubscribeJointStates(true);
            */

        }

        // Create image publisher
        public void CreateImagePublisher(string topic, Camera targetCamera,  int resolutionWidth, int resolutionHeight)
        {
            // Create the image publisher component
            ImagePublisher publisher = this.gameObject.AddComponent<ImagePublisher>();
            // Parameterise the publisher            
            publisher.Topic = topic;
            publisher.FrameId = uniqueID.ToString();
            publisher.ImageCamera = targetCamera;
            publisher.resolutionWidth = resolutionWidth;
            publisher.resolutionHeight = resolutionHeight;
        }
        // Create image subscribe
        public void CreateImageSubscriber(string topic, Camera targetCamera)
        {
            // Create the image subscriber component
            ImageSubscriber subscriber = this.gameObject.AddComponent<ImageSubscriber>();
            // Parameterise the subscriber
            subscriber.Topic = topic;
        }

        // Check if the entity has a urdf
        private bool HasUrdf()
        {
            GameObject robot = GetConnectedEntity();

            if (null == robot.GetComponent<UrdfRobot>())
            {
                return false;
            }
            return true;
        }
    }
}
