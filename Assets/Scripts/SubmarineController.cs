using System;
using UnityEngine;

/// <summary>
/// Défi 4 - Sébastien Bruere
/// Réécriture par Marc Lauzon.
/// </summary>

namespace Thalass {
    [RequireComponent(typeof(Rigidbody))]
    public class SubmarineController : MonoBehaviour {

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

        [Header("Interface")]
        [SerializeField]
        UI.MeterController m_batteryMeter = null;
        IDisposable m_batteryObserver = null;

        [SerializeField]
        UI.MeterController m_armorMeter = null;
        IDisposable m_armorObserver = null;

        Rigidbody m_rigidbody = null;
        Vector3 m_moveVelocity = Vector3.zero;
        Quaternion m_turnVelocity = Quaternion.identity;

        public AudioSource submarineEngineSound;
        
        void Start() {
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.drag = m_waterDrag;
            m_rigidbody.angularDrag = m_waterDrag;

            m_batteryObserver = m_submarine.Battery.Subscribe(m_batteryMeter);
            m_armorObserver = m_submarine.Armor.Subscribe(m_armorMeter);
        }

        void OnDisable() {
            m_batteryObserver.Dispose();
            m_armorObserver.Dispose();
        }

        void Update() {
            if (m_submarine.Battery.Current <= 0) {
                Debug.Log("EMERGENCY ESCAPE");
                return;
            }

            Move();
            if(Cursor.lockState != CursorLockMode.None)
                Turn();

            if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w") || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift))
            {
                if (!submarineEngineSound.isPlaying)
                {
                    submarineEngineSound.Play();
                }
            }
            else
            {

                if (submarineEngineSound.isPlaying)
                {
                    submarineEngineSound.Stop();
                }
            }
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
            if (Vector3.Distance(move, Vector3.zero) > m_moveDeadZone) {
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
                m_rigidbody.rotation = Quaternion.Lerp(m_rigidbody.rotation, Quaternion.Euler(0, m_rigidbody.rotation.eulerAngles.y, 0), m_waterDrag *2);
            }
        }

        public void GetDamaged(float _damage) {
            if (m_submarine.Armor.Current >= _damage) {
                m_submarine.Armor.Current -= _damage;
            } else {
                _damage -= m_submarine.Armor.Current;
                m_submarine.Armor.Current = 0;

                m_submarine.Battery.Current -= _damage;
            }

            m_rigidbody.velocity *= 1.25f;
            m_rigidbody.angularVelocity *= 0f;
        }

        void OnCollisionEnter(Collision collision) {

        }
    }
}
