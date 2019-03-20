using TMPro;
using UnityEngine;

namespace Thalass {
    public class GameManager : MonoBehaviour {

        [SerializeField]
        SubmarineController m_submarine = null;

        [Header("Surfacing")]
        [SerializeField]
        GameObject m_timerObject = null;

        [Space]
        [SerializeField]
        float m_exitHeight = 30.0f;

        [SerializeField]
        float m_exitTimerDelay = 5.0f;
        float m_exitTimerLeft = 5.0f;
        bool m_isExiting = false;

        [Space]
        [SerializeField]
        TMP_Text m_countDown = null;

        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update() {
            /*
            if (Input.GetKeyUp(KeyCode.Escape))
                ToggleCursor();
            */
        }

        void LateUpdate() {
            if(m_submarine.transform.position.y > m_exitHeight) {
                m_timerObject.SetActive(true);

                if (m_isExiting) {
                    m_exitTimerLeft -= Time.fixedDeltaTime;
                    m_countDown.text = m_exitTimerLeft.ToString("F3");
                } else {
                    m_exitTimerLeft = m_exitTimerDelay;
                    m_isExiting = true;
                }
            } else {
                m_timerObject.SetActive(false);

                if (m_isExiting)
                    m_isExiting = false;
            }
        }

        void ToggleCursor() {
            Cursor.lockState = (Cursor.lockState == CursorLockMode.None) ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
