using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace CSI
{
    [Serializable]
    [RequireComponent(typeof(UserFocus))]
    public class UserCamera : MonoBehaviour
    {
        public Material highlightMaterial;      // Material used to highlight gameobject.
        private GameObject cameraSubject;       // The current target

        public bool CameraOrbit = false;
        public bool ReorientCamera = true;

        [Range(0.01f, 10)]
        public float OrbitRadius = 2;
        public float OrbitSpeed = 5.0f;
        public float TranslationSpeed = 1;

        // Private camera properties
        private float OrbitmRadiusMin = 0.1f;

        // Adjust camera separation
        void AdjustCameraSeparation(float radius, float Speed)
        {
             // Move our position a step closer to the target.
            float step = Speed * Time.deltaTime; // calculate distance to move           
            Vector3 rVector = cameraSubject.transform.position - this.transform.position;
            Vector3 targetPosition = cameraSubject.transform.position - (rVector.normalized * radius);
            // Move the camera to the radial position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        //  Orient the camera towards a point
        void OrientCameraTowardPoint(Vector3 point, float Speed)
        {
            // Orientation vector
            Vector3 newDir = Vector3.RotateTowards(transform.forward,
                point - transform.position,
                Speed * Time.deltaTime, 0.0f);
            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        // Orbit the camera around point
        void OrbitCameraAboutPoint(Transform target, float radius, float Speed)
        {
            //Vector3 offset = new Vector3(0, 1, 1);
            Vector3 rVector = cameraSubject.transform.position - this.transform.position;

            //Vector3 offset = new Vector3(transform.position.x, 2, transform.position.z);  // - (rVector.normalized * radius);
            /*
            // Calculate step
            float OrbitAngleRate = Speed * Time.deltaTime;                                      // Calculate distance to move
            offset = Quaternion.AngleAxis(OrbitAngleRate * OrbitSpeed, Vector3.up) * offset;    // Adjust the Orbit
            transform.position = target.position + offset;                                      // Reposition
            */

            /*
            // Modify the offset by the radius
            offset = Vector3.MoveTowards(cameraPosition,
                cameraPosition + offset.normalized * radius,
                Speed * Time.deltaTime);

            // Calculate step
            float OrbitAngleRate = Speed * Time.deltaTime;                                      // Calculate distance to move
            offset = Quaternion.AngleAxis(OrbitAngleRate * OrbitSpeed, Vector3.up) * offset;    // Adjust the Orbit
            transform.position = target.position + offset;                                      // Reposition
            */
            Vector3 offset = new Vector3(transform.position.x,1, transform.position.z);
            // Calculate step
            float OrbitAngleRate = Speed * Time.deltaTime;                                      // Calculate distance to move
            offset = Quaternion.AngleAxis(OrbitAngleRate * Speed, Vector3.up) * offset;         // Adjust the Orbit
            transform.position = target.position + offset;                                                // Re-position

            // If look at object
            if (ReorientCamera)
                transform.LookAt(target);                                                     // Reorient

            return;
        }


        // Get WASD translation inputs
        void GetWASDInputs()
        {
            Vector3 pos = new Vector3(0, 0, 0);

            if (Input.GetKey("w"))
            {
                pos.x += TranslationSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.x -= TranslationSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.z += TranslationSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.z -= TranslationSpeed * Time.deltaTime;
            }

            transform.position -= pos;
        }
        // Get the mouse hold inputs
        void GetMouseHoldDownInputs()
        {

        }

        // Highlight the object with a colour
        void OnPostRender()
        {
            GameObject cameraHoverOver = GetComponent<UserFocus>().GetHoverOverObject();
            if (cameraHoverOver == null)
                return;

            highlightMaterial.SetPass(0);
            Component[] meshes = cameraHoverOver.GetComponentsInChildren(typeof(MeshFilter));
            foreach (MeshFilter m in meshes)
            {
                Graphics.DrawMeshNow(m.sharedMesh, m.transform.position, m.transform.rotation);
            }
        }

        // Initialisation
        void Start()
        {
        }
        void Update()
        {
            // Get the WASD inputs
            GetWASDInputs();
            // Get the house 
            GetMouseHoldDownInputs();

            // Get the object currently selected by the user
            cameraSubject = GetComponent<UserFocus>().GetSelectedObject();
            // If there is a target
            if (cameraSubject != null)
            {
                // Update zoom
                OrbitSpeed  += Input.GetAxis("Mouse X") * Time.deltaTime;
                OrbitRadius -= Input.GetAxis("Mouse ScrollWheel") * TranslationSpeed;
                
                // Sanity check
                if (OrbitRadius < OrbitmRadiusMin)
                    OrbitRadius = OrbitmRadiusMin;

                // Move the camera to a target radius
                AdjustCameraSeparation(OrbitRadius, TranslationSpeed);

                // Orbit the camera around the target
                if (CameraOrbit)
                {
                    OrbitCameraAboutPoint(cameraSubject.transform, OrbitRadius, OrbitSpeed);
                }

                // Reorient the camera toward the object (post-orbit)
                if (ReorientCamera)
                {
                    OrientCameraTowardPoint(cameraSubject.transform.position, TranslationSpeed);
                }
            }
        }

        void LateUpdate()
        {
        }
    }
}

