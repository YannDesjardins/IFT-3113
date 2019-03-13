﻿using UnityEngine;

/// <summary>
/// Défi 4 - Sébastien Bruere
/// Réécriture par Marc Lauzon.
/// </summary>

namespace Thalass.Player {
    [RequireComponent(typeof(Rigidbody))]
    public class SubmarineController : MonoBehaviour {

        [Header("Entities")]
        [SerializeField]
        Entities.Submarine m_submarine = null;

        [Space]
        [SerializeField]
        Camera m_camera = null;

        [Header("Movement")]
        [SerializeField]
        float m_energyConsumption = 0.01f;

        [SerializeField]
        float m_waterDrag = 0.1f;

        [SerializeField]
        float m_moveDeadZone = 0.2f;

        Rigidbody m_rigidbody = null;
        Vector3 m_moveVelocity = Vector3.zero;
        Quaternion m_turnVelocity = Quaternion.identity;
        

        void Start() {
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.drag = m_waterDrag;
        }

        void Update() {
            Move();
            if(Cursor.lockState == CursorLockMode.Locked)
                Turn();
        }

        void Move() {
            //Get controls.
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Height"), Input.GetAxis("Vertical"));

            //Cummulate movement.
            m_moveVelocity += move.x * m_camera.transform.right + move.y * m_camera.transform.up + move.z * m_camera.transform.forward;

            //Calculate propulsion.
            m_submarine.Propulsion.Current = m_moveVelocity.magnitude * (int)m_submarine.Propulsion.Level;

            //Inaction slowdown.
            m_moveVelocity = Vector3.Lerp(m_moveVelocity, Vector3.zero, m_waterDrag);

            //Apply.
            m_rigidbody.velocity = m_moveVelocity.normalized * m_submarine.Propulsion.Current * Time.deltaTime;

            //Consume energy on move.
            if (Vector3.Distance(move, Vector3.zero) < m_moveDeadZone) {
                m_submarine.Battery.Current -= m_energyConsumption;
            }
        }

        void Turn() {
            //Get controls.
            Quaternion turn = Quaternion.Euler(-Input.GetAxis("Mouse Y") * Time.deltaTime, Input.GetAxis("Mouse X") * Time.deltaTime, -Input.GetAxis("Roll") * Time.deltaTime);

            //Cummulate rotation.
            m_turnVelocity *= turn;

            //Inaction slowdown.                    
            m_turnVelocity = Quaternion.Lerp(m_turnVelocity, Quaternion.identity, m_waterDrag);

            //Apply.
            m_rigidbody.rotation *= m_turnVelocity.normalized;

            //Restore orientation.
            if (Quaternion.Angle(turn, Quaternion.identity) < m_moveDeadZone) {
                m_rigidbody.rotation = Quaternion.Lerp(m_rigidbody.rotation, Quaternion.Euler(0, m_rigidbody.rotation.eulerAngles.y, 0), m_waterDrag);
            }
        }
    }
}