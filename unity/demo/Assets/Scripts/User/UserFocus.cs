using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI
{
    // A class that retains the users focus on various objects in the world.
    public class UserFocus : MonoBehaviour
    {
        // It is assumed this attached to a camera
        private Camera UserCamera;
        private GameObject priorSelectedObject;
        private GameObject selectedObject;
        private GameObject hoverOverObject;
        

        // Get object currently hovered over
        public  GameObject GetHoverOverObject()
        {
            return hoverOverObject;
        }
        // Get object currentl selected
        public  GameObject GetSelectedObject()
        {
            return selectedObject;
        }
        // Get object previously selected
        public  GameObject GetPreviousObject()
        {
            return priorSelectedObject;
        }
        // Return the game-object hovered over
        private GameObject GetGameObjectOnHover(Vector3 mousePosition)
        {
            // Get tte current camera properties
            Camera subjectCamera = GetComponent<Camera>();

            // We need to actually hit an object
            RaycastHit hit_01;
            if (Physics.Raycast(subjectCamera.ScreenPointToRay(Input.mousePosition), out hit_01, 100.0f))
            {
                // Get the associated game object 
                return hit_01.transform.gameObject;
            }
            return null;
        }
        
        // Return main camera
        public Camera FindMainCamera()
        {
            return Camera.main;
        }
        // Start is called before the first frame update
        void Start()
        {
            // Initialise the prior 
            priorSelectedObject = GetGameObjectOnHover(Input.mousePosition);
        }


        void Update()
        {
            hoverOverObject = GetGameObjectOnHover(Input.mousePosition);
            // Check for new selections
            if (Input.GetMouseButton(0) == true)
            {
                selectedObject = hoverOverObject;
            }
        }

        // At the end of the frame generation
        void LateUpdate()
        {
            // Nothing is selected
            if (selectedObject == null)
            {
                return;
            }

            // Update the prior object from the selected object
            if (priorSelectedObject == null)
            {
                priorSelectedObject = selectedObject;   // The new object is now the prior
            }
            else if (priorSelectedObject.GetInstanceID() != selectedObject.GetInstanceID())
            {
                priorSelectedObject = selectedObject;
            }
        }        

    }
}
