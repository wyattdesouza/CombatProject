using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
        [Header("Movement")]
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float walkSpeed;
        [SerializeField]
        private float runSpeed;

        [SerializeField] private float jumpForce = 2;

        private Vector3 moveDirection = Vector3.zero;
        
        private CharacterController characterController;

        [Header("Gravity")]
        [SerializeField] private float gravity;
        [SerializeField] private float groundDistance;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private bool isCharacterGrounded = false;
        private Vector3 velocity = Vector3.zero;
        
        private Animator animator;

        private void Start()
        {
                GetReferences();
                InitializeVariables();
        }

        private void Update()
        {
                HandleIsGrounded();
                HandleJumping();
                HandleGravity();
                HandleRunning();
                HandleMovement();
                HandleAnimations();
        }

        private void GetReferences()
        {
                characterController = GetComponent<CharacterController>();
                animator = GetComponentInChildren<Animator>();
        }

        private void InitializeVariables()
        {
                moveSpeed = walkSpeed;
        }

        private void HandleIsGrounded()
        {
                isCharacterGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        }

        private void HandleJumping()
        {
                if (Input.GetKeyDown(KeyCode.Space) && isCharacterGrounded)
                {
                        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
                }
        }

        private void HandleGravity()
        {
                if(isCharacterGrounded && velocity.y < 0)
                {
                        velocity.y = -2f;
                }
                
                velocity.y += gravity * Time.deltaTime;
                characterController.Move(velocity * Time.deltaTime);
        }

        private void HandleRunning()
        {
                moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        }

        private void HandleAnimations()
        {
                if (moveDirection == Vector3.zero)
                {
                        animator.SetFloat("Speed", 0, 0.2f, Time.deltaTime);
                }
                else if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                {
                        animator.SetFloat("Speed", 0.5f, 0.2f, Time.deltaTime);
                }
                else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                {
                        animator.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
                }
        }
        
        private void HandleMovement()
        {
                float moveX = Input.GetAxisRaw("Horizontal");
                float moveZ = Input.GetAxisRaw("Vertical");
                
                moveDirection = new Vector3(moveX, 0, moveZ).normalized;
                moveDirection = transform.TransformDirection(moveDirection);
                
                characterController.Move(moveDirection * Time.deltaTime * moveSpeed);   
        }
}
