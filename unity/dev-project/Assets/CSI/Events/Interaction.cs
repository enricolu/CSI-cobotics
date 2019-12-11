using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.Events
{
    public class Interaction : Event
    {
        // Interaction parameters
        public int idA;
        public int idB;

        /*
         * Constructors
         */
        // Default
        public Interaction()
        {

        }
        // With two game-objects
        public Interaction(GameObject objectA, GameObject objectB)
        {
            idA = objectA.GetInstanceID();
            idB = objectB.GetInstanceID();
        }
    }
}

