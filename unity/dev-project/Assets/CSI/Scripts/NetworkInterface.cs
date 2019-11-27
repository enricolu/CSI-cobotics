using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI.ROS;
using CSI.ROS2;

namespace CSI
{
    // Communication types
    public enum networkType { ROS, ROS2, TCP };

    [Serializable]
    [RequireComponent(typeof(Device))]
    public class NetworkInterface : MonoBehaviour
    {
        [Header("Network Properties")]
        [Tooltip("Network address")]
        public string deviceAddress = "127.0.0.1";
        [Tooltip("Network port")]
        public string devicePort = "9090";
        [Tooltip("Network type ")]
        public networkType deviceNetwork = networkType.ROS;
        [Tooltip("Enable Connection")]
        public bool isEnabled = true;

        // Connect on awake
        void Awake()
        {
            if (isEnabled)
                Connect();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        void Connect()
        {
            Debug.Log("Creating connector of type '" + deviceNetwork + "' for device '" + this.name + "'...");
            
            // Run the connection protocol for the selected method
            switch (deviceNetwork)
            {
                case networkType.ROS:
                    ROSConnector ROSbridge = this.gameObject.AddComponent<ROSConnector>();
                    break;
                case networkType.ROS2:
                    ROS2Connector ROS2bridge = this.gameObject.AddComponent<ROS2Connector>();
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
    }
}

