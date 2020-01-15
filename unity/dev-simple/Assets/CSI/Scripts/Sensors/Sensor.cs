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

        // Internal references
        private const TwinType twinClass = TwinType.sensor;


        /*
         * Component behaviours
         */
        // Update is called once per frame
        void Update()
        {
            /*
             * This handles the update of the 'sensor' digital twins
             */

            // Detect if the twin behaviour has changed
            UpdateTwinBehaviour(); // Look for changes in the twin-behaviour

            // Sensor update procedure...

        }
    }
}
