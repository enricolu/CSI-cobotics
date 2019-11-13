using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InspectionMovement : MonoBehaviour
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
    public float zoomSensitivity = 5.0f;

    // Private references
    private float rotationSensitivity;
    private float translationSensitivity;
    // Containers
    private Vector2 cameraRotation;

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
        // Scale the sensitivities
        rotationSensitivity     = 320f * (mouseSensitivity / 10f);
        translationSensitivity  = 40f * (movementSensitivity / 10f);

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


        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta != 0f)
        {
            Debug.Log("Scrolling");
            AxialZoom(scrollDelta);
        }

        // Nominal translation behaviour
        PointTranslation(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0f);
    }

    // Zoom         - Zoom along axis by factor
    private void AxialZoom(float zoomDelta)
    {
        // Translate along the forward axis to emulate zoom
        transform.Translate(Vector3.forward * zoomSensitivity * zoomDelta);
    }
    // Translation  - XYZ translation from WASD
    private void PointTranslation(float xAxis,float yAxis,float zAxis)
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.position += transform.up * translationSensitivity * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            transform.position -= transform.up * translationSensitivity * Time.deltaTime;
        }
        return;
    }
    // Rotation     - Point rotation
    private void PointRotation(float xAxis,float yAxis)
    {
        // Calculate camera rotation   
        cameraRotation.x += xAxis * rotationSensitivity * Time.deltaTime;
        cameraRotation.y += yAxis * rotationSensitivity * Time.deltaTime;
        // Apply camera rotation
        transform.localRotation  = Quaternion.AngleAxis(cameraRotation.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(cameraRotation.y, Vector3.left);
        return;
    }
    // Translation  - XY mouse to XY translation
    private void PlanarTranslation(float xAxis,float yAxis)
    {
        // Modify camera position
        transform.position += transform.right * translationSensitivity* xAxis * Time.deltaTime;
        transform.position += transform.up * translationSensitivity* yAxis * Time.deltaTime;
        return;
    }
}
