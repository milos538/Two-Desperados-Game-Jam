using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour{

    public Transform m_player;
    public Transform m_camera;
    public float m_xSensitivity;
    public float m_ySensitivity;
    public float m_maxAngle;
    private Quaternion m_camCenter;
    public static bool cursorLocked = true;
    void Start(){
        m_camCenter = m_camera.localRotation;
    }

    void Update(){
        setY();
        setX();
        updateCursorLock();
    }

    void setY(){
        float input = Input.GetAxis("Mouse Y") * m_ySensitivity * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, -Vector3.right);
        Quaternion delta = m_camera.localRotation * adj;
        if(Quaternion.Angle(m_camCenter, delta) < m_maxAngle){
            m_camera.localRotation = delta;
        }
    }
    void setX(){
        float input = Input.GetAxis("Mouse X") * m_xSensitivity * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, Vector3.up);
        Quaternion delta = m_player.localRotation * adj;
        m_player.localRotation = delta;
    }
    void updateCursorLock(){
        if (cursorLocked){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Escape)) cursorLocked = false;
        }
        else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.Escape)) cursorLocked = true;
        }
    }
}
