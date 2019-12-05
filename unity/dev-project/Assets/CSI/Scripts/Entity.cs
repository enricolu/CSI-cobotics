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
        private TwinType twinClass = TwinType.none;
        /*
         * Component behaviours
         */
        // Before timeseries
        void Awake()
        {
            // If not provided with an ID, assign unique ID
            if (0 == id)
                id = GetInstanceID();

            // Confirm the entity has a network interface
            if (!HasNetworkInterface() && twinBehaviour != TwinMode.passive)
            {
                Debug.LogError("[" + this.name + "] No network interface, please add and configure.");
                twinBehaviour = TwinMode.passive;
                return;
            }
        }
        // General update function
        void Update()
        {
            Debug.Log("[" + this.name + "] in " + twinBehaviour + " mode..");
            // Update behaviour if needed
            if(HasNetworkInterface())
                UpdateNetworkingBehaviour();

            // No further action
        }

        /*
         * General
         */
        // This function returns the twin class of the object
        public TwinType GetTwinType()
        {
            return twinClass;
        }
        /*
         * Networking
         */
        // Check for changes in networking settings
        public void UpdateNetworkingBehaviour()
        {
            // Sanity check
            NetworkInterface EntityNI = GetComponent<NetworkInterface>();

            switch (twinBehaviour)
            {
                case TwinMode.passive:
                    // Remove if present
                    if (EntityNI.Exists())
                        EntityNI.Remove();  // Remove any existing connection
                    break;
                case TwinMode.emulated:
                    // Create if not present
                    if (!EntityNI.Exists())
                        EntityNI.New();     // Create a new connection
                    break;
                case TwinMode.networked:
                    // Create if not present
                    if (!EntityNI.Exists())
                        EntityNI.New();     // Create a new connection
                    break;
                default:
                    Debug.Log("[" + this.name + "] Twin mode not recognised");
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


