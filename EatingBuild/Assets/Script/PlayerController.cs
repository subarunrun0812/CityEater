using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DynamicJoystick joystick;
    [SerializeField] private float speed = 1f;
    [SerializeField] public Rigidbody rb;
    private Vector3 m_Direction;
    void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        // float x = joystick.Horizontal;
        // float z = joystick.Vertical;
        // transform.position += new Vector3(x * speed, 0, z * speed);
        m_Direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
    }
    void Update()
    {

        if (m_Direction != new Vector3(0, 0, 0))
        {
            transform.localRotation = Quaternion.LookRotation(m_Direction);
        }
    }
}