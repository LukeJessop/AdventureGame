using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    
    public UnityEvent jumpEvent;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;
    private Boolean playerIsGrounded;
    private ParticleSystem staminaParticles;
    private ParticleSystem.ShapeModule staminaShape;
    private ParticleSystem.EmissionModule staminaEmission;
    private ParticleSystem.MainModule staminaMain;

    void Start()
    {
        staminaParticles = GetComponent<ParticleSystem>();
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
        staminaShape = staminaParticles.shape;
        staminaEmission = staminaParticles.emission;
        staminaMain = staminaParticles.main;
        staminaParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter(); //movement management
        ApplyGravity(); //gravity
        KeepCharacterOnXAxis(); //keeps character on x axis
        CloseGame(); //closes the game on escape
    }

    private void MoveCharacter()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        var sprint = new Vector3(moveInput, 0f, 0f) * ((moveSpeed * sprintMultiplier) * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && playerIsGrounded)
        {
            jumpEvent.Invoke();
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            playerIsGrounded = false;
            
        }

        if (Input.GetKey(KeyCode.LeftShift) && staminaData.value > 0 && playerIsGrounded)
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
        if (playerIsGrounded)
        {
            
            if (controller.velocity.x < 0)
            {
                staminaEmission.rateOverTime= (controller.velocity.x * -1)/4;
            }
            else
            {
                staminaEmission.rateOverTime = controller.velocity.x/4;
            }
            if (controller.velocity.x < 0)
            {
                
                staminaShape.rotation = new Vector3(0f, 0f, 0f);
                staminaMain.startRotationY = 70f;
            }
            else
            {
                staminaShape.rotation = new Vector3(0f, 180f, 0f);
                staminaMain.startRotationY = 270f;
            }
        }
        else
        {
            staminaEmission.rateOverTime = 0f;
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

    public void PowerupActive(float powerupValue)
    {
        sprintMultiplier += powerupValue;
    }

    public void CloseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}