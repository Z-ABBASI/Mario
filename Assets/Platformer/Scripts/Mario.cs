using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Mario : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float maxTurboSpeed;
    public bool onTheGround;
    public float jumpForce;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate Mario based on direction
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        
        // Move Mario horizontally
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * acceleration;
        
        // Animate Mario
        anim.SetFloat("Speed", Math.Abs(rbody.velocity.x));

        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * 2f;

        Debug.DrawRay(startPoint, Vector3.down, Color.red, 2f);

        onTheGround = Physics.Raycast(startPoint, Vector3.down, 2f);

        if (onTheGround && Input.GetButton("Jump"))
        {
            rbody.velocity += new Vector3(0, jumpForce, 0);
        }
        
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if ((rbody.velocity.x > maxTurboSpeed))
            {
                Vector3 newVel = rbody.velocity;
                newVel.x = maxTurboSpeed;
                rbody.velocity = newVel;
            }
        } else {
            if (rbody.velocity.x > maxSpeed)
            {
                Vector3 newVel = rbody.velocity;
                newVel.x = maxSpeed;
                rbody.velocity = newVel;
            }
        }
        
        
        Debug.DrawRay(startPoint, Vector3.down, Color.green, 0.2f);
        anim.SetBool("In Air", !Physics.Raycast(startPoint, Vector3.down, 0.5f));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Goomba"))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1f))
            {
                Destroy(other.gameObject);
            }
            else
            {
                GameManager.color = Color.red;
                GameManager.message = "DEAD!";
            }
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            GameManager.color = Color.green;
            GameManager.message = "MARIO SAVES THE DAY!";
        }
    }
}