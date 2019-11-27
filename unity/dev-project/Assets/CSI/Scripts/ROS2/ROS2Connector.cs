using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.ROS2
{
    public class ROS2Connector : MonoBehaviour
    {
        // Default connection details
        public string address = "127.0.0.1";
        public string port = "9090";

        /*
         * 
         * Create connection object
         * 
         */
        // This method creates a connection to a known ROS network
        public ROS2Connector(string deviceAddress, string devicePort)
        {
            // Allocate connection details locally
            address = deviceAddress;
            port = devicePort;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
