using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.Robot
{
    // Robot kinematic types
    public enum dynamicMode {serial, mobile, other };

    public class Robot : Device
    {
        // General robot parameters
        [Header("Robot Parameters")]
        // Parameters
        [Tooltip("The robot kinematic types")]
        public dynamicMode dynamicBehaviour = dynamicMode.serial;

        // Internal references
        private TwinType twinClass = TwinType.robot;

        /*
         * Component behaviours
         */
        // Update is called once per frame
        void Update()
        {
            // Confirm the objects connection status
            UpdateNetworkingBehaviour();

            //CreateNIinterfaces();
        }



        /*
         * Create the Robot patch interfaces
         */
        private void Setup()
        {
            //SetTwinClass(TwinClass.robot);
        }
        
        
        private void CreateNIinterfaces()
        {
            /*
             * Assemble the interfaces for a given robot configuration
             */

            // Robot network interface
            NetworkInterface robotNI = gameObject.GetComponent<NetworkInterface>();

            switch (dynamicBehaviour)
            {
                case (dynamicMode.serial):
                    CreateNetworkComponents_Serial(robotNI);
                    break;

                case (dynamicMode.mobile):
                    CreateNetworkComponents_Mobile(robotNI);
                    break;

                default:
                    Debug.LogError("[" + this.name + "] Dynamic configuration '" + dynamicBehaviour.ToString() + "' not recognised.");
                    return;
            }
        }
        // Build patchers for serial-link systems (arms)
        private void CreateNetworkComponents_Serial(NetworkInterface robotNI)
        {
            /*
             * This function creates the parameter-listeners for a serial 
             * robot using the network-interface with a given network type.
             */

            robotNI.CreateSerialRobotPatches();
        }
        // Build interfaces for mobile robots
        private void CreateNetworkComponents_Mobile(NetworkInterface robotNI)
        {
            /*
             * This function creates the parameter-listeners for a mobile 
             * robot using the network-interface with a given network type.
             */
            robotNI.CreateMobileRobotPatches();
        }
        // Build listening interfaces for hybrid robots
        private void CreateNetworkComponents_Other(NetworkInterface robotNI)
        {
            Debug.Log("[" + this.name + "] Not implimented.");
        }
    }
}


