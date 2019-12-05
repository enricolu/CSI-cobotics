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

        // Private properties
        private GameObject connection;
        //private string connectionLabel = "Network Adapter";

        /*
         * Component behaviours
         */
        // Update is called once per frame
        void Update()
        {

        }
        // On component enable
        void OnEnable()
        {
            Reset();
        }
        // On component disable
        void OnDisable()
        {
            if (Exists())
                Remove();
        }
        // On NI destruction
        void OnDestroy()
        {
            if (Exists())
                Remove();
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
            // For clarity
            Debug.Log("[" + this.name + "] Creating '" + deviceNetwork + "' adapter.");
            // Reset any existing connection object
            Create();
            // Run the connection protocol for the selected method
            switch (deviceNetwork)
            {
                // Create ROS adapter
                case networkType.ROS:
                    connection.AddComponent(typeof(ROSInterface));
                    // Create bridge to ROS network
                    //ROS_NI.Connect(deviceAddress, devicePort, deviceTimeOut);
                    break;

                // Create ROS2 adapter
                case networkType.ROS2:
                    connection.AddComponent(typeof(ROS2Interface));
                    //ROS2_NI.Connect(deviceAddress, devicePort, deviceTimeOut);
                    break;

                // Create ROS adapter
                case networkType.other:
                    Debug.Log("[" + this.name + "] .. to be implimented.");
                    break;

                default:
                    Debug.Log("Connection type not recognised.");
                    return;
            }
            //Debug.Log("...connection created.");
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
            connection.tag = "Network";
        }        
        // Remove connection object
        public void Remove()
        {            
            // Destroy the connections
            Destroy(connection);
            // For clarity
            Debug.Log("[" + this.name + "] Removing '"+ connection.name);
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
         * Patch-through creation
         */
        // Create new serial patches, dependant on network-type
        public void CreateSerialRobotPatches()
        {
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    ROSInterface ROSbridge = GetComponent<ROSInterface>();
                    ROSbridge.CreateIOPatches_SerialRobot();
                    return;

                case networkType.ROS2:
                    ROS2Interface ROS2bridge = GetComponent<ROS2Interface>();
                    //ROS2bridge.CreateIOPatches_SerialRobot();
                    return;

                case networkType.other:
                    Debug.Log("[" + this.name + "] '" + deviceNetwork + " not yet implimented.");

                    return;

                default:
                    Debug.LogError("[" + this.name + "] Unable to create device patches for network type '" + deviceNetwork + "'");
                    return;
            }

        }
        // Create new serial patches, dependant on network-type
        public void CreateMobileRobotPatches()
        {

        }
    }
}

