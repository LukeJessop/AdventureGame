using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float gravity = -9.81f;
    public int jumpCounter = 0;
    public UnityEvent decreaseStamina;
    public UnityEvent increaseStamina;
    public SimpleFloatData staminaData;
    
    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;
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
        var sprint = new Vector3(moveInput, 0f, 0f) * ((moveSpeed * 2) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
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

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.5f; 
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
