using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject ship;
    [SerializeField] private float speed, distance;
    //Private Variables
    private Vector3 startingPos;

    void Awake()
    {
        startingPos = ship.transform.position;   
    }

    void Update()
    {
        ship.transform.position = startingPos + transform.up * (Mathf.Sin(speed * Time.time) * distance);
    }
}
