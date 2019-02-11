using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextTyper : MonoBehaviour
{
    TMP_Text m_text;

    [SerializeField]
    string m_message;
    int m_index = 0;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_typeDelay = 0.5f;

    float m_start = 0;

    void OnEnable() {
        m_start = Time.timeSinceLevelLoad;
    }

    void Start() {
        m_text = GetComponent<TMP_Text>();
        m_text.text = "";
    }

    void FixedUpdate() {
        if (Time.timeSinceLevelLoad > m_start + m_typeDelay) {
            if (m_index >= m_message.Length)
                return;

            m_text.text += m_message[m_index++];

            m_start = Time.timeSinceLevelLoad;
        }
    }

    void OnDisable() {
        m_text.text = "";
        m_index = 0;
    }
}
