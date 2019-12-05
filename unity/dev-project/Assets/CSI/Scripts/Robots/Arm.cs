using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.Robot
{
    public class Arm : Robot
    {
        // General robot parameters
        [Header("Arm Parameters")]
        
        // Interal parameters
        private const dynamicMode dynamicBehaviour = dynamicMode.serial;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /*
         * Twin Interface creation
         */
        // Create the interfaces necessary for emulation
        private void CreateEmulationInterface()
        {
            Debug.LogError("[" + this.name + "] Arm has no emulated-twin interface.");
        }
        // Create the interfaces necessary for networking
        private void CreteNetworkingInterface()
        {
            Debug.LogError("[" + this.name + "] Arm has no networked-twin interface.");
        }
    }
}