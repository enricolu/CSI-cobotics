using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI.Sensors
{
    public class Sensor : Device
    {
        // Properties (made available to all subsequent behaviours)
        [Header("Sensing Parameters")]
        [Tooltip("Effective sensor range.")]
        public float range = 4.0f;
        
        // Before timeseries
        void Awake() 
        {
            // Override device description as sensor
            AssignEntityType(EntityType.sensor);
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }
    }
}
