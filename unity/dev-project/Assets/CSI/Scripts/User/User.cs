using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI.User 
{
    // User-modes
    public enum handMode { right, left, ambidextrous };

    [Serializable]
    public class User : Entity
    {
        // Operator properties 
        [Header("Operator Parameters")]
        [Tooltip("Operator height in meters (m).")]
        public float height = 1.75f;                        // Average height of ~5ft 9"
        [Tooltip("Operator weight in kilograms (kg).")]
        public float weight = 90;                           // Average weight of 196.9 pounds
        [Tooltip("Dominant hand for interactions.")]
        public handMode dominantHand = handMode.right;      // Average hand dominance

        private float modelHeight = 1.5f;

        // Before timeseries
        void Awake()
        {
            // Ensure the entity type is consistant
            AssignEntityType(EntityType.user);
            // Scale the avatar geometry to the 'height' parameter
            ScaleOperatorGeometry();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ScaleOperatorGeometry()
        {
            // Universal Scaler
            float uScale = height / modelHeight;
            // Dimensional scalars
            float xScale = 1.0f;
            float yScale = 1.0f;
            float zScale = 1.0f;

            // Scale the geometry
            transform.localScale = new Vector3(
                uScale * xScale,
                uScale * yScale,
                uScale * zScale);
        }
    }
}
