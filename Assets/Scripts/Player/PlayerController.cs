using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Speed")]
    public float moveSpeed = 5;
    public float sprintSpeed = 10;
    public float applySpeed;

    [Header("Jump")]
    public bool isJumping = false;
    public bool isGrounded;
    public float jumpForce = 5;
    public LayerMask groundLayer;
    public Transform groundCheck;

    //private float sphereRadios = 0.2f;
    public float dirRacast = 0.007f;
    private float xInput;
    private float zInput;

    

    public void Move()
    {
        Vector3 dirMove = (transform.right * xInput + transform.forward * zInput).normalized; 
        dirMove *= applySpeed;
        
        rb.velocity = new Vector3(dirMove.x, rb.velocity.y, dirMove.z);
    }
    public void Sprint()
    {
        applySpeed = sprintSpeed;
    }
    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f ,rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
    }
    

    private void Start()
    {
        applySpeed = moveSpeed;
    }
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        else
        {
            applySpeed = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumping = true;
        }
        
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(groundCheck.position,Vector3.down, dirRacast,groundLayer);
        //isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadios, groundLayer);
        if (isJumping == true)
        {
            Jump();
            isJumping = false;
        }
        if (isGrounded == true)
        {
            Move();
        }
    }
}
