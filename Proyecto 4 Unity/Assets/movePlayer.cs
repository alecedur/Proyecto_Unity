using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public Transform floorCheck;
    public float floorDistance = 5f;
    public LayerMask floorMask;
    bool isInFloor;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isInFloor = Physics.CheckSphere(floorCheck.position, floorDistance, floorMask);
        if(isInFloor && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movePlayerVector = transform.right * x + transform.forward * z;
        controller.Move(movePlayerVector * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isInFloor)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
