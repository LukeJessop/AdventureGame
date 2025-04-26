using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float gravity = -9.81f;
    public float sprintMultiplier = 1.5f;
    public int jumpCounter = 0;
    public UnityEvent decreaseStamina;
    public UnityEvent increaseStamina;
    public SimpleFloatData staminaData;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;
    private Boolean playerIsGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        var sprint = new Vector3(moveInput, 0f, 0f) * ((moveSpeed * sprintMultiplier) * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && playerIsGrounded)
        { 
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            playerIsGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && staminaData.value > 0)
        {
            controller.Move(sprint);
            decreaseStamina.Invoke();
        }
        else
        {
            controller.Move(move);
            if (staminaData.value <= 1)
            {
                increaseStamina.Invoke();
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var controllerPosition = hit.controller.transform.position;


        if (hit.point.y < controllerPosition.y && (hit.moveDirection.y < 0f))
        {
            playerIsGrounded = true;
            velocity.y = 0f;
            
        }

        if (hit.point.y > controllerPosition.y && (hit.moveDirection.y > 0f))
        {
            velocity.y -= velocity.y;
        }
        
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}