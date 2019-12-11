using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.Events
{
    public class Collision : Interaction
    {
        // Additional collision parameters



        // Constructor
        public Collision(GameObject objectA, GameObject objectB)
        {
            idA = objectA.GetInstanceID();
            idB = objectB.GetInstanceID();
        }
    }
}

