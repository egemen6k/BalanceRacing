using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 15f;

    private float movement = 0f;
    private float rotation = 0f;

    public Rigidbody2D rb;
    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    private void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed;
        rotation = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }
        rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
