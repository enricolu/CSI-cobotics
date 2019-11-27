using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CSI
{
    // Device types
    public enum EntityType { generic, device, sensor, manipulator, user };

    /*
     * Device description
     */
    [Serializable]
    public class Entity : MonoBehaviour
    {
        // Public properties (made available to all subsequent behaviours)
        [Header("Overview")]
        public string name = "Unassigned";
        public const EntityType type = EntityType.generic;
        private int id = 0;                           // Unique reference

        // Before timeseries
        void Awake()
        {
            // If not provided with an ID, assign unique ID
            if (0 == id)
            {
                id = GetInstanceID();
            }
            // Assign the device tag
            AssignEntityType(type);
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

        /*
         * Assignments
         */
        // Assign tag to device based on "type"
        public void AssignEntityType(EntityType type)
        {
            /* 
             * This function ensures that the device tag matches its type, in addition to any further actions.
             */
            
            // Tag this device as the string "type"
            this.tag = type.ToString();
        }
    }
}


