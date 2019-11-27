using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.user
{ 
    // Selection controller
    public class UserSelection : MonoBehaviour
    {
        [Header("Inpsection Parameters")]
        // Selected object (mouse-click) 
        [Tooltip("Selected Object.")]
        public GameObject selectedObject;
        // Hover-over object (mouse-over)
        [Tooltip("Object currently hovered.")]
        public GameObject hoverObject;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        // LateUpdate is called every frame, if the Behaviour is enabled
        private void LateUpdate()
        {
            // Get object (if any) hovered over
            hoverObject = GetGameObjectOnHover(Input.mousePosition);
            // If selection is made, set this as the subject
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = hoverObject;
                //selectedObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alphaLevel);
            }
        }

        // Get the object hovered over
        private GameObject GetGameObjectOnHover(Vector3 mousePosition)
        {
            // We need to actually hit an object
            RaycastHit hit_01;
            if (Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(mousePosition), out hit_01, 100.0f))
            {
                // Get the associated game object 
                return hit_01.transform.gameObject;
            }
            return null;
        }
    }
}
