using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour{

    public CharacterController m_controller;
    public float m_speed;
    public float m_sprintSpeed;
    public float m_gravity;
    public bool m_canMove = true;

    Vector3 m_velocity;
    private float m_verticalAxis;
    private float m_horizontalAxis;


    void Update(){
        if (m_canMove){
            // Axes
            m_verticalAxis = Input.GetAxis("Vertical");
            m_horizontalAxis = Input.GetAxis("Horizontal");
            Vector3 move = transform.right * m_horizontalAxis + transform.forward * m_verticalAxis;
            if (Input.GetKey(KeyCode.LeftShift) && m_verticalAxis > 0) m_controller.Move(move * m_sprintSpeed * Time.deltaTime);
            else m_controller.Move(move * m_speed * Time.deltaTime);

            m_velocity.y += m_gravity * Time.deltaTime;
            m_controller.Move(m_velocity * Time.deltaTime);
        }
    }
}
