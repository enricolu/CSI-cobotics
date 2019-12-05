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
            // Confirm the objects connection status
            UpdateTwinBehaviour();

        }



        /*
         * Create the Robot patch interfaces
         */
        private void Setup()
        {

        }
        
    }
}


