using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor_PC : MonoBehaviour
{
    // Component references
    CharacterController controller;

    float moveSpeed;
    Vector3 movementVector;
    float xDir;
    float yDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            xDir = 1;
        }
    }
}
