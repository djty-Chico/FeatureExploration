using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Basic Movement Variables
    [SerializeField]
    private float walkSpeed = 10f;
    private Vector2 moveInput;
    private Rigidbody myRigidbody;
    
    //Player Control/input variables that are directly from overwatch.
    private float rateOfFire = 0.9f;
    private int maxAmmo = 13;
    private float moveSpeed = 5.5f;
    private float reloadSpeed = 1.5f;
    private float crouchSpeed = 3.3f;
    private float maxJumpHeight = 9.1f;
    private float chargeTime = 0.7f;

    public float jumpCharge;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerVelocity = new Vector3(moveInput.x * walkSpeed, myRigidbody.velocity.y, moveInput.y * walkSpeed);
        myRigidbody.velocity = transform.TransformDirection(playerVelocity);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
