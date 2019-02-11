using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField]
    RectTransform m_strip = null;

    float m_angle = 0;
    public float Angle {
        get {
            if (m_angle > 180) return m_angle - 360;
            else if (m_angle < -180) return 360 + m_angle;
            else return m_angle;
        }

        set {
            m_angle = value % 360;
        }
    }

    void FixedUpdate() {
        m_strip.anchoredPosition = new Vector2(Angle * 2, 0);
    }
}
