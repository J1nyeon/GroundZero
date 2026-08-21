using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayeNewInputMoveTest : MonoBehaviour
{
    private Vector3 inputDir;
    public float speed = 5f;
    
    private void Update()
    {
        transform.position += new Vector3(inputDir.x, 0, inputDir.z) * Time.deltaTime * speed;
        
    }

    public void On_Move(InputValue value)
    {
        inputDir = value.Get<Vector3>();
    }

}
