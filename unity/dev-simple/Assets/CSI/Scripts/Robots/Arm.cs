using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;
using RosSharp.Urdf;

namespace CSI.Robot
{
    public class Arm : Robot
    {
        // General robot parameters
        [Header("Arm Parameters")]
        
        // Interal parameters
        private const dynamicMode dynamicBehaviour = dynamicMode.serial;

        /*
         * Twin Interface creation
         */
        // Create the interfaces necessary for emulation
        public override void CreateTwinInterface_emulated()
        {
            Debug.Log("[" + this.name + "] Creating emulated-twin interface.");
            // Get the network interface
            NetworkInterface NI = this.gameObject.GetComponent<NetworkInterface>();
            // Get the robot URDF
            UrdfRobot urdfRobot = this.GetComponent<UrdfRobot>();
            // Create the joint angle subscriber
            NI.CreateJointStateBroadcaster(urdfRobot);
        }
        // Create the interfaces necessary for networking
        public override void CreateTwinInterface_networked()
        {
            Debug.Log("[" + this.name + "] Creating networked-twin interface.");
            // Get the network interface
            NetworkInterface NI = this.gameObject.GetComponent<NetworkInterface>();
            // Get the robot URDF
            UrdfRobot urdfRobot = this.GetComponent<UrdfRobot>();
            // Create the joint angle subscriber
            NI.CreateJointStateListener(urdfRobot);
        }

    }
}