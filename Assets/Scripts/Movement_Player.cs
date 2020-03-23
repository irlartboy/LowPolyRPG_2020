using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement_Player : MonoBehaviour
{
    public Vector3 moveDirection;

    private CharacterController playerController;

    public float jumpSpeed = 10;
    public float speed = 5;
    public float gravity = 20;
    public static bool canMove;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (playerController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);
    }
}









