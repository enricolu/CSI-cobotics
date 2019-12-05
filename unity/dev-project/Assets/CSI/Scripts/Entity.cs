using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI
{
    // Digital Twinning behaviours
    public enum TwinMode { passive, emulated, networked };
    // Types of devices
    public enum TwinType { none, device, user, sensor, robot};
    /*
     * Device description
     */
    [Serializable]
    public class Entity : MonoBehaviour
    {
        // Public properties (made available to all subsequent behaviours)
        [Header("General Parameters")]
        [Tooltip("Arbritrary designation")]
        public string name = "Unassigned";
        [Tooltip("Digital twinning mode; is the device real, emulated or passive?")]
        public TwinMode twinBehaviour = TwinMode.passive;   // Does not transmit or recieve data

        // Internal references
        private int id = 0;                                 // Unique reference
        private TwinMode priorBehaviour = TwinMode.passive; // Memory of previous mode
        private const TwinType twinClass = TwinType.none;

        /*
         * Component behaviours
         */
        // Before timeseries
        void Awake()
        {
            // If not provided with an ID, assign unique ID
            if (0 == id)
                id = GetInstanceID();
        }
        // General update function
        void Update()
        {
            Debug.Log("[" + this.name + "] in " + twinBehaviour + " mode..");

            // Confirm the entity has a network interface
            if (!HasNetworkInterface() && twinBehaviour != TwinMode.passive)
            {
                Debug.LogError("[" + this.name + "] No network interface, please add and configure.");
                twinBehaviour = TwinMode.passive;
                return;
            }

            // Check if the "Twin behaviour" has changed and create and new interfaces
            UpdateTwinBehaviour();
        }

        /*
         * Networking
         */
        // Check if the network interface exists
        public bool HasNetworkInterface()
        {
            if (null != GetComponent<NetworkInterface>())
                return true;
            return false;
        }

        /*
         * Twinning functions
         */
        // Update procedure for twin interfaces
        public void UpdateTwinBehaviour()
        {
            // Detect if the behaviour has changed
            if (twinBehaviour == priorBehaviour)
                return;

            // ======= Behaviour has changed ======
            if (twinBehaviour == TwinMode.passive)              // To an inactive status
            {
                // Remove connection object if present
                if (GetComponent<NetworkInterface>().Exists())
                {
                    GetComponent<NetworkInterface>().Remove();  // Remove any existing connection
                }
                // Destroy twin interface components
                DestroyTwinInterface();  
            }            
            else if (priorBehaviour == TwinMode.passive)        // From inactive status
            {
                // Create new connection object if not present
                if (!GetComponent<NetworkInterface>().Exists())
                {
                    GetComponent<NetworkInterface>().New();     // Create a new connection
                }
                // Create a new twin interface using the network interface
                CreateTwinInterface();
            }
            // Define the previous behaviour as the new behaviour
            priorBehaviour = twinBehaviour;
        }
        // Create the interfaces depending on twin type
        private void CreateTwinInterface()
        {            
            switch (twinBehaviour)
            {
                case TwinMode.passive:
                    return;
                case TwinMode.emulated:
                    CreateEmulationInterface();
                    return;
                case TwinMode.networked:
                    CreateNetworkingInterface();
                    return;
                default:
                    Debug.Log("[" + this.name + "] Unable to generate twin interfaces: unknown twin-mode.");
                    return;
            }
        }
        // Create the interfaces depending on twin type
        private void DestroyTwinInterface()
        {

        }
        // Get the objects twin class
        public TwinType GetTwinType()
        {
            return twinClass;
        }
        // Create the interfaces necessary for emulation
        private void CreateEmulationInterface()
        {
            Debug.LogError("[" + this.name + "] Has no emulated-twin interface.");
        }
        // Create the interfaces necessary for networking
        private void CreateNetworkingInterface()
        {
            Debug.LogError("[" + this.name + "] Has no networked-twin interface.");
        }

        /*
         * Heirarchy transversal
         */
        // Search parents with tag
        public Transform FindParentWithTag(Transform member, string tagString)
        {
            // Check if parent exists
            if (member.parent == null)
                Debug.LogWarning("Unable to find " + tagString + " transform.");
            return null;

            // Recursively check the parent
            if (member.tag != tagString)
                return FindParentWithTag(member.parent, tagString);

            // Else return the current member
            return member;
        }
        // Search through parent transform for gameobject with tag
        public static void AssignTagToChildren(Transform parentT, string tagString)
        {
            parentT.tag = tagString;

            foreach (Transform child in parentT)
            {
                AssignTagToChildren(child, tagString);
            }
        }
    }
}


