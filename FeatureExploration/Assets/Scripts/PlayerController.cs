using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Basic Movement Variables
    [SerializeField]
    private Vector2 moveInput;
    private Rigidbody myRigidbody;

    //Player Control/input variables that are directly from overwatch.
    private float walkSpeed = 5.5f;
    private float rateOfFire = 0.9f;
    private int maxAmmo = 13;
    private float moveSpeed = 5.5f;
    private float reloadSpeed = 1.5f;
    private float maxJumpHeight = 9.1f;
    private float chargeTime = 0.7f;

    public float jumpCharge;


    private bool crouchOn = false;
    public bool inAir = false;

    //Enum for the different movement states that the player can be in,
    public enum MovementState
    {
        walking,
        crouching,
        air
    }
    public MovementState state;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed, myRigidbody.velocity.y, moveInput.y * walkSpeed);
        myRigidbody.velocity = transform.TransformDirection(playerVelocity);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            crouchOn = true;
            transform.localScale = new Vector3(1, 0.75f, 1);
            //exact crouch speed from Overwatch
            walkSpeed = 3.3f;
        }
        else
        {
            crouchOn = true;
            transform.localScale = new Vector3(1, 1, 1);
            walkSpeed = 5.5f;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inAir = true;
        }
    }
}
