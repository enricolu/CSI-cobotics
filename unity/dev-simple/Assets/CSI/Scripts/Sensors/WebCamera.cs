using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSI;

namespace CSI.Sensors
{
    /*
     * The behaviour defining a network camera as a sensor
     */
    public class WebCamera : Sensor
    {
        // Parameters
        [Tooltip("Target unity camera")]
        public Camera targetCamera;
        [Tooltip("Camera resolution")]
        public int widthResolution = 640;
        public int heightResolution = 480;      



        /*
         * General
         */


        /*
         * Twinning interface creation
         */
        // Create the interfaces necessary for emulation
        public override void CreateTwinInterface_emulated()
        {
            Debug.Log("[" + this.name + "] Creating emulated-twin interface.");
            // Get the NI
            NetworkInterface NI = this.gameObject.GetComponent<NetworkInterface>();
            // Create an image subscriber
            NI.CreateImagePublisher(targetCamera, widthResolution, heightResolution);
        }
        // Create the interfaces necessary for networking
        public override void CreateTwinInterface_networked()
        {
            Debug.Log("[" + this.name + "] Creating networked-twin interface.");
            // Get the NI
            NetworkInterface NI = this.gameObject.GetComponent<NetworkInterface>();
            // Create an image subscriber
            NI.CreateImageSubscriber(targetCamera);
        }
    }
}
