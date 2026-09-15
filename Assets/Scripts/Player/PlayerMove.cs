using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    [Header("Move")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float applySpeed;
    public Animator animator;

    private float xInput;
    private float zInput;

    [Header("Jump")]
    public float jumpForce = 5f;
    private bool isJumping = false;
    public bool isGrounded;

    //public CinemachineImpulseSource CI;
    //public float cameraShake = 0.02f;
    public bool canShoot = true;

    void Start()
    {
        applySpeed = moveSpeed;
    }
    public void Move()
    {
        Vector3 dirMove = (transform.right * xInput + transform.forward * zInput).normalized;
        dirMove *= applySpeed;
        rb.velocity = new Vector3(dirMove.x, rb.velocity.y, dirMove.z);
   
    }
    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce ,ForceMode.Impulse);
        isGrounded = false;
        canShoot = false; // 점프중일경우엔 총을 쏠 수 없음.
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        //if (isGrounded == true)
        //{
            
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            applySpeed = sprintSpeed;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
            canShoot = true;
            //Debug.Log("점프 가능");
        }
    }
    private void FixedUpdate()
    {
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

    //public void CameraMove()
    //{
    //    CI.GenerateImpulse(cameraShake);
    //}
}
