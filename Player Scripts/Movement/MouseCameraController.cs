using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    /*Brackeys, 2019. FIRST PERSON MOVEMENT in Unity - FPS Controller. [Online] 
      Available at: https://www.youtube.com/watch?v=_QajrabyTJc
      [Accessed 24/02/2021].*/

    [SerializeField] private float mouseSensetivity;
    [SerializeField] private Transform playerBody;
    private float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
