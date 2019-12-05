using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RS = RosSharp.RosBridgeClient;

namespace CSI.ROS
{
    public class ROSInterface : MonoBehaviour
    {
        /*
         * This connector object is designed to be a wrapper for the RosSharp library. 
         * It provides quick access for generic robot configurations.
         */

        // Get connection parameters from inputs
        public string address { get; set; }
        public string port { get; set; } 
        public int timeOut { get; set; }

        private RS.RosConnector ROSbridge;

        /*
         * Component behaviours
         */
        // Start is called before the first frame update
        void Start()
        {
        
        }
        // Update is called once per frame
        void Update()
        {

        }
        // On component destruction
        void OnDestroy()
        {
            Disconnect();  // On destruction of the ROSconnector, remove the RosSharp connector
        }

        /*
         * Create connection object
         */
        // Create a connection to a ROS network
        public void Connect(string deviceAddress, string devicePort, int deviceTimeOut)
        {
            // Allocate connection details locally
            address = deviceAddress;
            port    = devicePort;
            timeOut = deviceTimeOut;
            string deviceURL = "ws://" + address + ":" + port;      // Create the device URL

            // Create a ROS connector
            ROSbridge = gameObject.AddComponent<RS.RosConnector>();
            ROSbridge.RosBridgeServerUrl = deviceURL;
        }
        // Remove the ROSbridge
        public void Disconnect()
        {
            //Debug.Log("[" + this.name+"] Destroying connection to" + this.gameObject.name + "@" + address + ":" + port);
            // Destroy the component
            Destroy(ROSbridge);
        }
        /*
         * Serial robot (arm) parameter bridges
         */
        // Create a ROS-specific IO bridge for a serial robot
        public void CreateIOPatches_SerialRobot()
        {
            //this.gameObject.AddComponent<>();
        }
        // Create a ROS-specific IO bridge for a mobile robot 
        public void DestoryIOPatches_SerialRobot()
        {
            //this.gameObject.AddComponent<>();
        }

        /*
         * Mobile robot (rover) Parameter bridges
         */
        // Create a ROS-specific IO bridge for a serial robot
        public void CreateIOPatches_MobileRobot()
        {

        }
        // Create a ROS-specific IO bridge for a mobile robot 
        public void DestoryIOPatches_MobileRobot()
        {

        }

    }
}
