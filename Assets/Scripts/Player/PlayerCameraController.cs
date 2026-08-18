using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Mouse")]
    private float xRotate;
    private float yRotate;
    public float mouseSpeed = 1000f;
    public Transform playerCamere;
    

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 게임화면 중앙에 고정
        Cursor.visible = false; // 마우스 커서 숨김

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 충돌시 물리회전 고정
    }
    public void MouseController()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;
        yRotate += mouseX;
        xRotate -= mouseY;

        xRotate = Mathf.Clamp(xRotate, -90f, 90f); // 위 아래 90도 까지만
        playerCamere.rotation = Quaternion.Euler(xRotate, yRotate, 0f); // 카메라 회전.
                                                                        // x는 위 아래, y는 좌우, z는 카메라 고정
        transform.rotation = Quaternion.Euler(0f, yRotate, 0f); // 플레이어 몸통 회전. 좌우만 적용
    }

    private void Update()
    {
        MouseController();

        //MouseOnOff();
    }
    public void Zoom()
    {
        
    }


    //public void MouseOnOff()
    //{
    //    if (Input.GetKey(KeyCode.Escape))
    //    {
    //        Cursor.visible = true;
    //    }

    //}   
    
}
