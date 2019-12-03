using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RS = RosSharp.RosBridgeClient;

namespace CSI.ROS
{
    public class ROSInterface : MonoBehaviour
    {
        /*
         * This connector object is designed to be a wrapper for the RosSharp library. 
         * 
         */
        // Get connection parameters from inputs
        public string address { get; set; }
        public string port { get; set; } 
        public int timeOut { get; set; }

        private RS.RosConnector ROSbridge;

        /*
         * 
         * Create connection object
         * 
         */
        // This method creates a connection to a known ROS network
        public void Connect(string deviceAddress, string devicePort, int deviceTimeOut)
        {
            // Allocate connection details locally
            address = deviceAddress;
            port    = devicePort;
            timeOut = deviceTimeOut;
            // Create the device URL
            string deviceURL = "ws://" + address + ":" + port;

            // Create a ROS connector
            ROSbridge = gameObject.AddComponent<RS.RosConnector>();
            ROSbridge.RosBridgeServerUrl = deviceURL;

        }
        public void Disconnect()
        {
            Debug.Log("Destroying connection to" + this.gameObject.name + "@" + address + ":" + port);
            // Destroy the component
            Destroy(ROSbridge);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            // On destruction of the ROSconnector, remove the RosSharp connector
            Destroy(ROSbridge);
            Debug.Log("Connection removed.");
        }
    }
}
