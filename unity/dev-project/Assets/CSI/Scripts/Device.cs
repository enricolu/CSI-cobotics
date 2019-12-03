using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI
{
    // Device type
    public enum deviceMode { unknown, networked, emulated };

    public class Device : Entity
    {
        // Properties (made available to all subsequent behaviours)
        [Header("Device Information")]
        [Tooltip("Device Model.")]
        public string model = "Unassigned";
        [Tooltip("Device Manufacturer.")]
        public string manufacturer = "Unassigned";
        [Tooltip("Is the device real, or emulated?")]
        public deviceMode mode = deviceMode.unknown;

        // Before timeseries
        void Awake()
        {
            AssignEntityType(EntityType.device);    // Override entity description as device
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}