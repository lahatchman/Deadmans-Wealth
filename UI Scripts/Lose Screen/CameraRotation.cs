using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject cameraRotator;
    [SerializeField] private float rotationSpeed;

    void Update() { RotateCamera(); }

    void RotateCamera()
    {
        cameraRotator.transform.Rotate(-Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
