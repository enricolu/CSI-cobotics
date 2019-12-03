using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI
{
    // Digital Twinning behaviours
    public enum TwinMode { passive, emulated, networked };

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

        // Before timeseries
        void Awake()
        {
            // If not provided with an ID, assign unique ID
            if (0 == id)
                id = GetInstanceID();

            // No further setup for passive objects
            if (twinBehaviour != TwinMode.passive)
                return;

            // Confirm the entity has a network interface
            if (!HasNI())
                Debug.LogError("[ERROR] Entity '" + name + "' has no network interface, please add and configure.");
                return;

        }
        
        // General update function
        void Update()
        {
            Debug.Log("I '" + name + "' in " + twinBehaviour + " mode..");
        }

        /*
         * Networking
         */
        // Check a network-interface exists
        public bool HasNI()
        {
            if (GetNI() != null)
                return true;
            return false; 
        }        
        // Get the entities network interface
        public NetworkInterface GetNI()
        {
            return this.gameObject.GetComponent<NetworkInterface>();
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


