using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController characterController;
    private Animator animator;
    private GameObject mainCamera;
    private Vector2 move;
    private Vector2 look;
    private bool jump;
    private bool sprint;


    public float speed = 15f;


    void Start()
    {

    }

    private void Awake()
    {

        if (mainCamera != null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        //var movement = new Vector3(horizontal, 0, vertical);
        //characterController.SimpleMove(movement * speed * Time.deltaTime);
        //animator.SetFloat("Speed", movement.magnitude);




        //if (movement.magnitude > 0)
        //{
        //    Quaternion newDirection = Quaternion.LookRotation(movement);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turningSpeed);
        //}

        Move();
        
    }

    private void Move()
    {
        Vector3 moveInput = new Vector3(move.x * speed, rb.velocity.y, move.y * speed);
        characterController.SimpleMove(moveInput * speed * Time.deltaTime);
        animator.SetFloat("Speed", moveInput.magnitude);

    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
