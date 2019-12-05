using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI
{
    /*
     * This class is a generic device with unspecified network affiliantions
     */
    public class Device : Entity
    {
        // Properties (made available to all subsequent behaviours)
        [Header("Device Information")]
        [Tooltip("Device Model.")]
        public string model = "Unassigned";
        [Tooltip("Device Manufacturer.")]
        public string manufacturer = "Unassigned";
        
        // Internal references
        private const TwinType twinClass = TwinType.device;

        /*
        // Before timeseries
        void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        */
    }
}