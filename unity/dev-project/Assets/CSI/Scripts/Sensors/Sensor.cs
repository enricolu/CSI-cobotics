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
            UpdateTwinBehaviour();

            Debug.Log("Type: " + twinClass.ToString());

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        void Setup()
        {
            //this.EntityClass = TwinClass.sensor;
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
