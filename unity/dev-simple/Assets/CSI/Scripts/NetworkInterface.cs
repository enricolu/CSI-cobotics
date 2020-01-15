using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI.ROS;
using CSI.ROS2;
using RosSharp.Urdf;

namespace CSI
{
    // Communication types
    public enum networkType { ROS, ROS2, other };

    /*
     * 
     * Generic Network Interface class
     * 
     */

    [Serializable]
    [RequireComponent(typeof(Entity))]
    public class NetworkInterface : MonoBehaviour
    {
        [Header("Network Properties")]
        [Tooltip("Network address")]
        public string deviceAddress = "127.0.0.1";
        [Tooltip("Network port")]
        public string devicePort = "9090";
        [Tooltip("Network time-out")]
        public int deviceTimeOut = 10;
        [Tooltip("Network type ")]
        public networkType deviceNetwork = networkType.ROS;

        [Header("Message Labels")]
        [Tooltip("Broadcast message label")]
        public string publishMessage = "publisher-topic";
        [Tooltip("Recieve message label")]
        public string subscribeMessage = "subscriber-topic";

        // Private properties
        private string deviceLocation;
        private GameObject connection;

        /*
         * Component behaviours
         */
        // On component enable
        void OnEnable()
        {
            Debug.Log("[" + this.name + "] Enabling network interface...");
            Reset();
        }
        // On component disable
        void OnDisable()
        {
            Debug.Log("[" + this.name + "] Disabling network interface...");
            if (Exists())
                Remove();
        }

        /*
         * General tools
         */
        // Ping an IP address
        public void Ping()
        {
            // Ensure the network location is defined
            deviceLocation = "ws://" + deviceAddress.ToString() + ":" + devicePort.ToString();
            // Intialise thread
            StartCoroutine(StartPing());
        }
        // Starts a ping activity
        IEnumerator StartPing()
        {
            WaitForSeconds f = new WaitForSeconds(deviceTimeOut);
            // Initiate the ping
            Ping newPing = new Ping(deviceLocation);
            while (newPing.isDone == false)
            {
                yield return f;
            }
            PingFinished(newPing);
        }
        // On ping completed
        public bool PingFinished(Ping newPing)
        {
            // stuff when the Ping p has finshed....
            Debug.Log("Ping complete.");
            return true;
        }

        /*
         * Connection construction/manipulation
         */
        // High-level connection indicator
        public bool IsActive()
        {
            // Check if the connection is disabled
            if (!IsEnabled())
                return false;

            // Call the connections logical
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    return connection.GetComponent<ROSInterface>().IsConnected();
                case networkType.ROS2:
                    return connection.GetComponent<ROS2Interface>().IsConnected();
                default:
                    Debug.LogError("[" + this.name + "] Connection not defined for network " + deviceNetwork.ToString());
                    return false;
            }
        }
        // Connection Disable/Enable 
        public void EnableDisable()
        {
            connection.SetActive(!connection.activeSelf);
        }
        // Confirm the adapter is enabled
        public bool IsEnabled()
        {
            return connection.activeSelf;
        }

        // Connect to the selected network
        public void New()
        {
            // Ensure the network location is defined
            deviceLocation = "ws://" + deviceAddress.ToString() + ":" + devicePort.ToString();

            // Reset any existing connection object
            Create();

            // Run the connection protocol for the selected method
            switch (deviceNetwork)
            {
                // Create ROS adapter
                case networkType.ROS:
                    // Create bridge to ROS network
                    ROSInterface RI = connection.AddComponent<ROSInterface>();
                    // Parameterise
                    RI.networkAddress = deviceLocation;
                    RI.timeOut = deviceTimeOut;
                    RI.uniqueID = this.name + '-' + this.gameObject.GetComponent<Entity>().id.ToString();

                    // Connect to the ROS network
                    RI.Connect();

                    //WaitForSeconds f = new WaitForSeconds(deviceTimeOut);

                    break;

                // Create ROS2 adapter
                case networkType.ROS2:
                    // Create bridge to ROS2 network
                    connection.AddComponent(typeof(ROS2Interface));
                    break;

                // Alternative adapters
                default:
                    Debug.LogError("[" + this.name + "] .. to be implimented.");
                    return;
            }
            //Debug.Log("[" + this.name + "] Created '" + deviceNetwork + "' adapter.");       
        }
        // Reset connection object
        public void Reset()
        {
            // Remove connection object
            if (Exists())
            {
                Remove();
            }
            // Create new connection
            New();
        }
        // Remove connection object
        public void Remove()
        {            
            // Destroy the connections
            Destroy(connection);
        }        
        // Create new blank connection object
        private void Create()
        {
            // Reset any existing connection object
            connection = new GameObject(deviceNetwork + " Adapter");
            connection.transform.SetParent(this.transform);
            connection.transform.localPosition = new Vector3(0, 0, 0);
            connection.tag = "network";
        }    
        // Check the NI has a connection object
        private bool Exists()
        {
            // If the internal reference is empty
            if (null == connection)
                return false;
            if (!connection.transform.IsChildOf(this.transform))
                return false;
            return true;
        }

        /*
         * Twin (Network) Interfaces
         * - All devices should never see ROS or ROS2
         * - 
         * 
        */
        // Generic joint angle subscriber creation
        public void CreateJointStateBroadcaster(UrdfRobot urdfRobot)
        {
            // Sanity check
            if (null == urdfRobot)
            {
                Debug.LogError("[" + this.name + "] Unable to create a joint state broadcaster; device has no URDF description.");
                return;
            }

            // Switch based on network behaviour
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    // Get the ROS-bridge
                    ROSInterface ROSbridge = connection.GetComponent<ROSInterface>();
                    // Robot joint states
                    ROSbridge.CreateJointStatePublisher(
                        "test",
                        urdfRobot);
                    
                    break;
                default:
                    Debug.LogError("[" + this.name + "] Interface not yet implemented for network type '" + deviceNetwork + "'");
                    return;
            }
        }        
        // Generic joint angle publisher creation
        public void CreateJointStateListener(UrdfRobot urdfRobot)
        {
            // Sanity check
            if (null == urdfRobot)
            {
                Debug.LogError("[" + this.name + "] Unable to create a joint state Listener; device has no URDF description.");
                return;
            }

            // Switch based on network behaviour
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    // Get the ROS-bridge
                    ROSInterface ROSbridge = connection.GetComponent<ROSInterface>();
                    // Robot joint states
                    ROSbridge.CreateJointStateSubscriber(
                        "test",
                        urdfRobot);

                    break;
                default:
                    Debug.LogError("[" + this.name + "] Interface not yet implemented for network type '" + deviceNetwork + "'");
                    return;
            }
        }


        // Generic image publisher creation
        public void CreateImagePublisher(Camera targetCamera, int resolutionWidth, int resolutionHeight)
        {
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    // Get the ROS-bridge
                    ROSInterface ROSbridge = connection.GetComponent<ROSInterface>();
                    // ROS message
                    string rosTopic = this.name + "/" + publishMessage;
                    // Create the publisher
                    ROSbridge.CreateImagePublisher(
                        rosTopic,
                        targetCamera,
                        resolutionWidth, 
                        resolutionHeight);
                    break;

                default:
                    Debug.LogError("[" + this.name + "] Interface not yet implemented for network type '" + deviceNetwork + "'");
                    return;
            }
        }
        // Generic image subscriber creation
        public void CreateImageSubscriber(Camera targetCamera)
        {
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    // Get the ROS-bridge
                    ROSInterface ROSbridge = connection.GetComponent<ROSInterface>();
                    // ROS message
                    string rosTopic = this.name + "/" + subscribeMessage;
                    // Create the subscriber
                    ROSbridge.CreateImageSubscriber(rosTopic,targetCamera);
                    break;

                default:
                    Debug.LogError("[" + this.name + "] Interface not yet implemented for network type '" + deviceNetwork + "'");
                    return;
            }
        }
    }
}

