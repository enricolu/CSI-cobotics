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
        [Header("Generic robot parameters")]

        // Internal references
        private const TwinType twinClass = TwinType.robot;
        private const dynamicMode dynamicBehaviour = dynamicMode.other;

        /*
         * Component behaviours
         */
        // Update is called once per frame
        void Update()
        {
            // Handle changes in network-mode
            UpdateTwinBehaviour();
        }


        /*
         * Twinning interface creation
         */
        // Create the interfaces necessary for emulation
        public override void CreateTwinInterface_emulated()
        {
            Debug.LogError("[" + this.name + "] Has no emulated-twin interface.");



        }
        // Create the interfaces necessary for networking
        public override void CreateTwinInterface_networked()
        {
            Debug.LogError("[" + this.name + "] Has no networked-twin interface.");
        }
    }
}


