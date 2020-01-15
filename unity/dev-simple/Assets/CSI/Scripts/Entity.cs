using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI
{
    // Digital Twinning behaviours
    public enum TwinMode { disabled, emulated, networked };
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
        //[Tooltip("Arbritrary designation")]
        //public string name = "Unassigned";
        [Tooltip("A unique object reference")]
        public int id = 0;                                   // Unique reference
        [Tooltip("Digital twinning mode; is the device real, emulated or disabled?")]
        public TwinMode twinBehaviour = TwinMode.disabled;   // Does not transmit or recieve data
        
        // Internal references
        private TwinMode priorBehaviour = TwinMode.disabled; // Memory of previous mode
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

            // Ensure property aligns
            //this.gameObject.name = name;
            
            // Preliminary NI update
            UpdateNetworkInterface(twinBehaviour);
        }
        // General update function
        void Update()
        {
            Debug.Log("[" + this.name + "] in " + twinBehaviour + " mode..");    
            // Detect if the behaviour has changed
            UpdateTwinBehaviour(); // Look for changes in the twin-behaviour
        }

        /*
         * Twinning functions
         */
        // Update procedure for twin interfaces
        public void UpdateTwinBehaviour()
        {
            // Sanity check
            if (twinBehaviour == priorBehaviour)
                return;

            // Update the network interfaces 
            UpdateNetworkInterface(twinBehaviour);

            // Update interfaces             
            switch (twinBehaviour)
            {
                // Destroy twin interface components
                case TwinMode.disabled:
                    break;
                case TwinMode.emulated:  
                    CreateTwinInterface_emulated();
                    break;
                case TwinMode.networked:
                    CreateTwinInterface_networked();
                    break;
                default:
                    Debug.Log("[" + this.name + "] Unable to generate twin interface: unknown twin-mode.");
                    return;
            }

            // Define the previous behaviour as the new behaviour
            priorBehaviour = twinBehaviour;
        }
        // Create the interfaces necessary for emulation
        public virtual void CreateTwinInterface_emulated()
        {
            Debug.LogError("[" + this.name + "] Has no emulated-twin interface.");
            // Reset the behaviour
            twinBehaviour = TwinMode.disabled;
        }
        // Create the interfaces necessary for networking
        public virtual void CreateTwinInterface_networked()
        {
            Debug.LogError("[" + this.name + "] Has no networked-twin interface.");
            // Reset the behaviour
            twinBehaviour = TwinMode.disabled;
        }
        // Get the objects twin class
        public TwinType GetTwinType()
        {
            return twinClass;
        }

        /*
         * Networking
         */
        // Update the network interface
        private void UpdateNetworkInterface(TwinMode currentMode)
        {
            /*
             * This function updates the network interface 
             * based on the current twin mode
             */

            // Get the network interface
            NetworkInterface NI = GetComponent<NetworkInterface>();
            // If there is no interface 
            if (NI == null) 
            {
                // If there should be one
                if (currentMode != TwinMode.disabled)
                {
                    Debug.LogError("[" + this.name + "] has no network interface, please add and configure one for network behaviour.");
                }
                return;
            }
            // Enable-disable network interface
            switch (currentMode)
            {
                case TwinMode.disabled:
                    NI.enabled = false;
                    break;
                default:
                    NI.enabled = true;
                    return;
            }
        }
        // Check if the network interface exists
        public bool HasNetworkInterface()
        {
            if (null != GetComponent<NetworkInterface>())
                return true;
            return false;
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
        // Search children with tag
        public List<Transform> FindChildWithTag(Transform member, string tagString)
        {
            // Create the container
            List<Transform> candidates = new List<Transform>();
            // For each child
            for (int i = 0; i < member.childCount; i++)
            {
                Transform child = member.GetChild(i);
                if (child.tag == tagString)
                {
                    candidates.Add(child.transform);
                }
                if (child.childCount > 0)
                {
                    FindChildWithTag(child, tagString);
                }
            }
            return candidates;
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


