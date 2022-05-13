using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*Brackeys, 2019. FIRST PERSON MOVEMENT in Unity - FPS Controller. [Online] 
      Available at: https://www.youtube.com/watch?v=_QajrabyTJc
      [Accessed 24/02/2021].*/

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed, gravity, groundDistance, jumpHeight;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
