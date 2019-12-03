﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI.ROS;
using CSI.ROS2;

namespace CSI
{
    // Communication types
    public enum networkType { ROS, ROS2, TCP };

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

        [Tooltip("Enable Connection")]
        public bool isEnabled = false;

        // Internal logic
        private bool activeConnection = false;

        // Connect on awake
        void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            CheckConnectionStatus();
        }
        
        // On NI destruction
        void OnDestroy()
        {
            Disconnect();
        }

        /*
         * Connection properties
         * 
         */
        // Checks the interfaces for connection status changes
        public void CheckConnectionStatus()
        {
            // Provide the new/reconnecting logic
            if (isEnabled && !IsConnected())
            {
                Connect();
                activeConnection = true;
            }
            else if (!isEnabled && IsConnected())
            {
                Disconnect();
                activeConnection = false;
            }
        }
        // Connect to the selected network
        public void Connect()
        {
            Debug.Log("Creating connector of type '" + deviceNetwork + "' for device '" + this.name + "'...");
            
            // Run the connection protocol for the selected method
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    ROSInterface ROSbridge = this.gameObject.AddComponent<ROSInterface>();
                    ROSbridge.Connect(deviceAddress, devicePort, deviceTimeOut);

                    break;
                case networkType.ROS2:
                    ROS2Interface ROS2bridge = this.gameObject.AddComponent<ROS2Interface>();
                    ROS2bridge.Connect(deviceAddress, devicePort, deviceTimeOut);
                    break;

                case networkType.TCP:
                    Debug.Log(".. To be implimented.");
                    break;

                default:
                    Debug.Log("Connection type not recognised.");
                    return;
            }
            //Debug.Log("...connection created.");
        }
        // Disconnect from the selected network
        public void Disconnect()
        {
            Debug.Log("Destroying '" + deviceNetwork + "' connection on device '" + this.name + "'...");
            // Destroy the connections
            Destroy(this.gameObject.GetComponent<ROSInterface>());
            Destroy(this.gameObject.GetComponent<ROS2Interface>());
        }        
        // Check if the connection is active
        public bool IsConnected()
        {
            return activeConnection;
        }
    }
}

