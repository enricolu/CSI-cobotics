using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CSI;

namespace CSI.User 
{
    // User-modes
    public enum handMode { right, left, ambidextrous };

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

        private float defaultHeight = 1.5f;
        private float defaultWeight = 90;

        // Before timeseries
        void Awake()
        {
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
            ScaleOperatorGeometry(); // Scale the avatar geometry to the 'height' parameter
        }

        // Scale the geometry of the avatar
        private void ScaleOperatorGeometry()
        {
            // Universal Scaler
            float uScale = height / defaultHeight;
            float wScale = weight / defaultWeight;
            // Dimensional scalars
            float xScale = wScale;
            float yScale = 1.0f;
            float zScale = wScale;

            // Scale the geometry
            transform.localScale = new Vector3(
                uScale * xScale,
                uScale * yScale,
                uScale * zScale);
        }
    }
}
