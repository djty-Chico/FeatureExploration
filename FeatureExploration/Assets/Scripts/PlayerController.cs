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

    private PlayerController playercontroller;

    //Player Control/input variables that are directly from overwatch.
    private float walkSpeed = 5.5f;
    private float rateOfFire;
    private int maxAmmo = 13;
    private float moveSpeed = 5.5f;
    private float reloadSpeed = 1.5f;
    private float maxJumpHeight = 600f;
    private float chargeTime = 0.7f;
    private float minJumpHeight;
    [SerializeField]
    public float jumpHeight;

    public GameObject healShot;
    public GameObject healSpawnPoint;
    public GameObject healAOE;

    private bool crouchOn = false;
    public bool onGround = true;
    private bool jumpPressed = false;
    private bool readyToFire = true;


    //Enum for the different movement states that the player can be in,
    public enum MovementState
    {
        walking,
        crouching,
        jump
    }
    public MovementState state;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        playercontroller = GetComponent<PlayerController>();
        maxJumpHeight = 600f;
        minJumpHeight = 200f;
        jumpHeight = minJumpHeight;
        rateOfFire = 0.9f;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed, myRigidbody.velocity.y, moveInput.y * walkSpeed);
        myRigidbody.velocity = transform.TransformDirection(playerVelocity);
        
    }

    public void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    public IEnumerator chargingJump()
    {
        while (jumpHeight < maxJumpHeight)
        {
            jumpHeight+= 57.14f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator jumpChargeCancel()
    {
        yield return new WaitForSeconds(1f);
        jumpHeight = minJumpHeight;
    }

    public IEnumerator waitForFire()
    {
        yield return new WaitForSeconds(rateOfFire);
        readyToFire = true; 
    }
    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(chargingJump());
            Debug.Log("Crouch Perfromed");
            crouchOn = true;
            transform.localScale = new Vector3(1, 0.75f, 1);
            //exact crouch speed from Overwatch
            walkSpeed = 3.3f;
            state = MovementState.crouching;
        }
        else
        {
            //go back to normal move speed/scale while not crouched
            crouchOn = false;
            transform.localScale = new Vector3(1, 1, 1);
            walkSpeed = 5.5f;

        }
        if (context.canceled)
        {
            StartCoroutine(jumpChargeCancel());
        }
    }


    //To jump to specific height 
    // v = sqrt(-2 * jumpHeight * gravity);
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump Started");
            onGround = false;
            myRigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Force);
            state = MovementState.jump;
        }
    }

    public void Heal_Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (readyToFire == true)
            {
                Instantiate(healShot, healSpawnPoint.transform.position, healSpawnPoint.transform.rotation);
                waitForFire();
            }
            else
            {
                waitForFire();
            }
        }
    }
    public void AOE_Heal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(context);
            Instantiate(healAOE, transform.position, transform.rotation);
        }
    }

}
