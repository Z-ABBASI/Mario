using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mario : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 10f;
    public bool onTheGround;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * acceleration;

        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * 2f;

        onTheGround = Physics.Raycast(startPoint, Vector3.down, 2f);

        if (onTheGround)
        {
            rbody.velocity += new Vector3(Vector3.right.x * Input.GetAxis("Horizontal") * Time.deltaTime * acceleration, Input.GetAxis("Jump"), 0);
        }

        if (rbody.velocity.x > maxSpeed)
        {
            Vector3 newVel = rbody.velocity;
            newVel.x = maxSpeed;
            rbody.velocity = newVel;
        }
    }
}