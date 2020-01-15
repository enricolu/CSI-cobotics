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
    }
}