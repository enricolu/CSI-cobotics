using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.Sensors
{
    /*
     * The behaviour defining the Kinetic sensor
     */
    public class Kinect : WebCamera
    {

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
            // Handle changes in network-mode
            UpdateTwinBehaviour();

            // Kinect behaviours....
        }

        /*
         * Twinning interface creation
         */
        // Create the interfaces necessary for emulation
        public override void CreateTwinInterface_emulated()
        {
            Debug.Log("[" + this.name + "] Creating emulated-twin interface.");
            // Get the NI
            NetworkInterface NI = this.gameObject.GetComponent<NetworkInterface>();
        }
        // Create the interfaces necessary for networking
        public override void CreateTwinInterface_networked()
        {
            Debug.Log("[" + this.name + "] Creating networked-twin interface.");
            // Get the NI
            NetworkInterface NI = this.gameObject.GetComponent<NetworkInterface>();
        }
    }
}
