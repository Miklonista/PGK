using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;

    public float playerSpeed = 40f;
    float x = 0f;
    bool playerJump = false;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            playerJump = true;
        }       
    }

    private void FixedUpdate()
    {
        controller.Move(x * Time.fixedDeltaTime * playerSpeed, false, playerJump);
        playerJump = false;
    }
}
