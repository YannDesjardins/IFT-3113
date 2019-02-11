using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeBlinker : MonoBehaviour {
    CanvasGroup m_canvas;

    [Space]
    [SerializeField]
    bool m_blink = true;
    public bool Blink {
        get { return m_blink; }
        set { m_blink = value; }
    }

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_blinkDelay = 0.5f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_fadeSpeed = 0.5f;

    bool m_fadeIn = false;
    float m_start = 0;

    void Start() {
        m_canvas = GetComponent<CanvasGroup>();
    }

    void FixedUpdate()
    {
        if (!Blink)
            return;

        if(Time.timeSinceLevelLoad > m_start + m_blinkDelay) {
            if (!m_fadeIn) {
                if (m_canvas.alpha > 0.0f) {
                    m_canvas.alpha -= m_fadeSpeed;
                } else {
                    m_fadeIn = !m_fadeIn;
                    m_start = Time.timeSinceLevelLoad;
                }
            } else {
                if (m_canvas.alpha < 1.0f) {
                    m_canvas.alpha += m_fadeSpeed;
                } else {
                    m_fadeIn = !m_fadeIn;
                    m_start = Time.timeSinceLevelLoad;
                }
            }
        }
    }
}
