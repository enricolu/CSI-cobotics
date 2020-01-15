using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.ROS2
{
    public class ROS2Interface : MonoBehaviour
    {
        // Get connection parameters from inputs
        public string address { get; set; }
        public string port { get; set; }
        public int timeOut { get; set; }

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

        /*
        * Connection operations
        */
        // Check we are connected to a ROS network
        public bool IsConnected()
        {
            return false;
        }        
        // This method creates a connection to a known ROS network
        public void Connect(string deviceAddress, string devicePort, int deviceTimeOut)
        {
            // Allocate connection details locally
            address = deviceAddress;
            port    = devicePort;
            timeOut = deviceTimeOut;
            // Create the device URL
            string deviceURL = "ws://" + address + ":" + port;

        }
        // Disconnect behaviour
        public void Disconnect()
        {
            Debug.Log("Destroying connection to" + this.gameObject.name + "@" + address + ":" + port);

        }
    }
}