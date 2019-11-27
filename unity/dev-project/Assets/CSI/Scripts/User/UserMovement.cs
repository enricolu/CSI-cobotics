using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSI.user
{
    // Movement controller
    public class UserMovement : MonoBehaviour
    {
        [Header("Movement Parameters")]
        // Rotational sensitivity
        [Tooltip("Multiplier for camera sensitivity.")]
        [Range(0f, 10)]
        public float mouseSensitivity = 5.0f; //160f;
                                              // Translational sensitivity
        [Tooltip("Multiplier for camera translation.")]
        [Range(0f, 10f)]
        public float movementSensitivity = 5.0f;
        // Scroll sensitivity
        [Tooltip("Multiplier for camera translation.")]
        [Range(0f, 10f)]
        public float scrollZoomSensitivity = 5.0f;

        [Header("Movement Inversion")]
        // Inversion behaviour
        [Tooltip("Invert mouse behaviour.")]
        public bool invertMouse = false;
        [Tooltip("Invert movement behaviour.")]
        public bool invertMotion = false;

        // Private references
        private float cursorFactor;
        private float motionFactor;
        private float zoomFactor;
        // Containers
        private Vector2 cameraRotation;
        private int mouseCoefficient = -1;
        private int motionCoefficient = 1;

        // Start is called before the first frame update
        void Start()
        {
            // Initial camera orientation
            cameraRotation.x = transform.eulerAngles.y;
            cameraRotation.y = -transform.eulerAngles.x;
            // Calculate the inversion coefficient
            if (invertMouse)
                mouseCoefficient = -mouseCoefficient;
            if (invertMotion)
                motionCoefficient = -motionCoefficient;
        }

        // Update is called once per frame
        void Update()
        {

        }

        // LateUpdate is called every frame, if the Behaviour is enabled
        private void LateUpdate()
        {
            // Scale the sensitivities
            cursorFactor = 250f * (mouseSensitivity / 10f);
            zoomFactor = 20f * (scrollZoomSensitivity / 10f);
            motionFactor = 0.5f * (movementSensitivity / 10f);

            HandleMouseInputs();
            HandleKeyInputs();
        }

        // ////////////////// Process key inputs /////////////////
        // Key-wrapper
        private void HandleKeyInputs()
        {
            // Handle translational inputs
            PointTranslation(
                Input.GetKey(KeyCode.W),
                Input.GetKey(KeyCode.A),
                Input.GetKey(KeyCode.S),
                Input.GetKey(KeyCode.D));
            // Check for exit flag
            ExitGameCheck(
                Input.GetKey(KeyCode.Escape));

        }
        // Translation  - XYZ translation from WASD
        private void PointTranslation(bool forwardKey, bool leftKey, bool backwardKey, bool rightKey)
        {
            if (forwardKey)
                transform.position += motionCoefficient * motionFactor * transform.TransformDirection(Vector3.forward);
            if (leftKey)
                transform.position += motionCoefficient * motionFactor * transform.TransformDirection(Vector3.left);
            if (backwardKey)
                transform.position -= motionCoefficient * motionFactor * transform.TransformDirection(Vector3.forward);
            if (rightKey)
                transform.position -= motionCoefficient * motionFactor * transform.TransformDirection(Vector3.left);
        }
        // Exit application if requested
        private void ExitGameCheck(bool exitKey)
        {
            // Check for exit flag
            if (exitKey)
                Application.Quit();
        }

        // ///////////////// Process mouse inputs ////////////////
        // Mouse-wrapper
        private void HandleMouseInputs()
        {
            // Hold mouse 2 for rotation behaviour
            if (Input.GetMouseButton(1))
            {
                Debug.Log("Mouse 2 held");
                PointRotation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                return;
            }
            // Hold mouse 3 for translation behaviour
            if (Input.GetMouseButton(2))
            {
                Debug.Log("Mouse 3 held");
                PlanarTranslation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                return;
            }
            // Detect scroll inputs
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            if (scrollDelta != 0f)
            {
                Debug.Log("Scrolling");
                AxialZoom(scrollDelta);
            }
        }
        // Zoom         - Zoom along axis by factor
        private void AxialZoom(float zoomDelta)
        {
            // Translate along the forward axis to emulate zoom
            transform.Translate(Vector3.forward * zoomFactor * zoomDelta);
        }
        // Rotation     - Point rotation
        private void PointRotation(float xAxis, float yAxis)
        {
            // Calculate camera rotation 
            cameraRotation.x += mouseCoefficient * xAxis * cursorFactor * Time.deltaTime;
            cameraRotation.y += mouseCoefficient * yAxis * cursorFactor * Time.deltaTime;
            // Apply camera rotation
            transform.localRotation = Quaternion.AngleAxis(cameraRotation.x, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(cameraRotation.y, Vector3.left);
            return;
        }
        // Translation  - XY mouse to XY translation
        private void PlanarTranslation(float xAxis, float yAxis)
        {
            // Modify camera position
            transform.position += mouseCoefficient * (cursorFactor / 10f) * xAxis * Time.deltaTime * transform.right;
            transform.position += mouseCoefficient * (cursorFactor / 10f) * yAxis * Time.deltaTime * transform.up;
            return;
        }
    }
}
