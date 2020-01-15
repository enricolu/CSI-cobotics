using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.Events
{
    public class Safety : Event
    {
        // Properties
        public string warning;
        // Internal properties
        private GameObject entity;

        /*
         * Constructors
         */
        // Default
        public Safety(GameObject entityRef,string warningText = "warning triggered")
        {
            // Record reference to the concerned object
            entity = entityRef;
            // Assign the safety text
            warning = warningText;
        }
    }
}

