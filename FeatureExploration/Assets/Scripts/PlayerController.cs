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
    //Variables

    public float maxShootSpeed;
    public float maxAmmo;
    public float moveSpeed;
    public float reloadSpeed;
    public float crouchSpeed;
    public float maxJumpHeight;
    public float chargeTime;

    public float jumpForce;
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
