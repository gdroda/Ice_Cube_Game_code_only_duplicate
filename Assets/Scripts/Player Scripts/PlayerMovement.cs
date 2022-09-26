using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private NewPlayer playerInput;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI miscText;

    [SerializeField] private PlayerStats playerStats;

    [HideInInspector] public float playerSpeed;

    float rotAmount;

    Vector2 movementInput;
    Vector3 acceleration;

    void Awake() 
    {
        playerInput = new NewPlayer();
        playerSpeed = playerStats.playerSpeed + playerStats.speedUpgrade;
        rotAmount = playerStats.rotAmount;

        rb.velocity = new Vector3(0f, 0f, 15f);
    }

    private void OnEnable() 
    {
        playerInput.Enable();
    }

    private void OnDisable() 
    {
        playerInput.Disable();
    }

    private void FixedUpdate()
    {
        // faster acceleration when below 10
        if (rb.velocity.z < 10)
        {
            acceleration = new Vector3(0f, 0f, 0.15f);
        }
        else
        {
            acceleration = new Vector3(0f, 0f, 0.05f);
        }
        
        //if (rb.velocity.z < playerStats.playerMaxSpeed) rb.AddForce(acceleration, ForceMode.VelocityChange);
        rb.AddForce(acceleration, ForceMode.VelocityChange);

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 0.15f, rb.velocity.z); // harder fall
        
        // Turning Add Force
        if (movementInput.x > 0)
        {
            rb.AddForce(new Vector3(playerStats.turnSpeed, 0f, 0f));
        }
        else if (movementInput.x < 0)
        {
            rb.AddForce(new Vector3(-playerStats.turnSpeed, 0f, 0f));
        }
        
        #region Added Rotation
        // Add small rotation on movement.

        // make rotation value smaller when cube gets smaller
        
        if (transform.localScale.x < 0.7) rotAmount = playerStats.rotAmount/2;
        else rotAmount = playerStats.rotAmount;

        var cubeAngle = Vector3.Angle(transform.up, Vector3.up);
        var rotAngle = new Vector3(0f, rotAmount, 0f);
        
        if (cubeAngle < 10) rotAngle = new Vector3(0f, rotAmount, 0f); // if face up
        else if (cubeAngle > 80 && cubeAngle < 100) rotAngle = new Vector3(rotAmount, 0f, rotAmount); // if on the side
        else if (cubeAngle > 170) rotAngle = new Vector3(0f, -rotAmount, 0f); // if upside down

        // Adding Torque Force
        if (movementInput.x > 0)
        {
            rb.AddRelativeTorque(rotAngle, ForceMode.Force);
        }
        else if (movementInput.x < 0)
        {
            rb.AddRelativeTorque(rotAngle * -1, ForceMode.Force);
        }
        #endregion
        
    }

    void Update()
    {
        // The read value is now set here after 1.1.1 input system update.
        movementInput = playerInput.MainAction.Movement.ReadValue<Vector2>();
        //movementInput = new Vector2 (playerStats.direction,0);

        speedText.text = "Speed: " + rb.velocity.z;
        miscText.text = movementInput.ToString();
    }

    public void Dash()
    {
        rb.AddForce(0f, 0f, 15f,ForceMode.VelocityChange);
    }
}