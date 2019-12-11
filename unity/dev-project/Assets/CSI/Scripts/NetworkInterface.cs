using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI.ROS;
using CSI.ROS2;

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
        private GameObject connection;

        /*
         * Component behaviours
         */
        // On component enable
        void OnEnable()
        {   
            Reset();
            Debug.Log("[" + this.name + "] Network interface enabled.");
        }
        // On component disable
        void OnDisable()
        {
            if (Exists())
                Remove();
            Debug.Log("[" + this.name + "] Network interface disabled.");
        }
        // On NI destruction
        void OnDestroy()
        {
            if (Exists())
                Remove();
            Debug.Log("[" + this.name + "] Network interface removed.");
        }

        /*
         * Connection properties
         */
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
                    RI.address = deviceAddress;
                    RI.port = devicePort;
                    RI.timeOut = deviceTimeOut;
                    // Connect to the ROS network
                    RI.Connect();
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
        // Create new blank connection object
        private void Create()
        {
            // Reset any existing connection object
            connection = new GameObject(deviceNetwork + " Adapter");
            connection.transform.SetParent(this.transform);
            connection.transform.localPosition = new Vector3(0, 0, 0);
            connection.tag = "network";
        }        
        // Remove connection object
        public void Remove()
        {            
            // Destroy the connections
            Destroy(connection);
        }        
        // Check the NI has a connection object
        public bool Exists()
        {
            // If the internal reference is empty
            if (null == connection)
                return false;
            if (!connection.transform.IsChildOf(this.transform))
                return false;
            return true;
        }

        /*
         * Twin Network Interfaces
         * - All devices should never see ROS or ROS2
         * - 
         * 
        */
        // Generic image publisher creation
        public void CreateImagePublisher(Camera targetCamera, int resolutionWidth, int resolutionHeight)
        {
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    // Get the ROS-bridge
                    ROSInterface ROSbridge = connection.GetComponent<ROSInterface>();

                    // Define the ROS topic
                    string ROStopic = this.name + "/" + publishMessage;
                    // Create the publisher
                    ROSbridge.CreateImagePublisher(targetCamera, ROStopic, resolutionWidth, resolutionHeight);
                    return;

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
                    // Define the ROS topic
                    string ROStopic = this.name + "/" + subscribeMessage;
                    // Create the publisher
                    ROSbridge.CreateImageSubscriber(targetCamera, ROStopic);
                    return;

                default:
                    Debug.LogError("[" + this.name + "] Interface not yet implemented for network type '" + deviceNetwork + "'");
                    return;
            }
        }
    }
}

