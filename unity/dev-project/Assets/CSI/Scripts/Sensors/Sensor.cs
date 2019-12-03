using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI.Sensors
{
    public class Sensor : Device
    {
        // General sensing parameters
        [Header("Sensing Parameters")]

        [Tooltip("Effective sensor range.")]
        public float range = 4.0f;

        // Update is called once per frame
        void Update()
        {
            /*
             * This handles the update of the 'sensor' digital twins
             */

            // Was the update successful (message placeholder)
            bool isSuccessful = new bool();

            switch (twinBehaviour)
            {
                case TwinMode.passive:
                    // Do nothing..
                    return;
                case TwinMode.emulated:
                    // Sensor is simulation only
                    isSuccessful = EmulationUpdate(GetNI());

                    return;

                case TwinMode.networked:
                    // Sensor is real and networked
                    isSuccessful = NetworkedUpdate(GetNI());

                    return;

                default:
                    Debug.Log("Twin mode not recognised for '" + name);
                    return;
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }


        /*
         * Networked sensor methods
         */
        private bool NetworkedUpdate(NetworkInterface sensorNI)
        {
            Debug.Log("Sensor:'" + name + "' updating in network mode..");
            return true;
        }

        /*
         * Emulated sensor methods
         */
        private bool EmulationUpdate(NetworkInterface sensorNI)
        {
            Debug.Log("Sensor:'" + name + "' updating in locally emulated mode..");
            return true;
        }
    }
}
