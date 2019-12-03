using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.Robot
{
    // Robot kinematic types
    public enum robotType {serial, mobile, hybrid };

    public class Robot : Device
    {
        // General robot parameters
        [Header("Robot Parameters")]
        // Parameters
        [Tooltip("The robot kinematic types")]
        public robotType config = robotType.serial;
        [Tooltip("RMS error tolerance")]
        public float RMSErrorTolerance = 5.0f;  // mm

        private bool activeInterface = false;        

        /*
         * Manipulators can be connected or disconnected to an associated network
         */

        // Start is called before the first frame update
        void OnAwake()
        {
            // Get the general connection interface
            //if (this.gameObject.GetComponent<NetworkInterface>.IsNetworked())
            //{
            //    Debug.Log("Creating interfaces..");
            //   CreateIOComponents(type);
            //}
        }

        // Update is called once per frame
        void Update()
        {        
            /*
             * This script hands the creation of interfaces for the 
             * robot.
             * 
             */

            // Get the general connection interface
            NetworkInterface networkBridge = this.gameObject.GetComponent<NetworkInterface>();
            
            // Sanity check. has adapter and is not disabled 
            if (networkBridge == null || !networkBridge.isActiveAndEnabled)
                return;
            // Check enabled controller
            if (!networkBridge.isEnabled)
                return;

            // Create or destroy network bridge depending on selection
            if (!activeInterface && networkBridge.IsConnected())
            {
                CreateIOComponents();
                activeInterface = true;
            }
            else if (activeInterface && !networkBridge.IsConnected())
            {
                //DestroyInterface(type);
                activeInterface = false;
            }
        }

        /*
         * Create the Robot patch interfaces
         */
        private void CreateIOComponents()
        {
            switch (config)
            {
                case (robotType.serial):
                    // Create the joint state mirror
                    //this.gameObject.AddComponent<ROSConnector>();
                    break;
                default:
                    Debug.Log("Type " + config.ToString() + " not implemented yet.");
                    return;
            }
        }
    }
}


