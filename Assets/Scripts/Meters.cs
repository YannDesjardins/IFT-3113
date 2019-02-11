using UnityEngine;
using UnityEngine.UI;

public class Meters : MonoBehaviour
{
    float MIN_LIMIT = 0.155f;
    float MAX_LIMIT = 0.845f;

    [SerializeField]
    Image m_leftFill = null;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_leftValue = 0;
    public float LeftValue {
        get { return m_leftValue; }
        set { m_leftValue = Mathf.Clamp01(value); }
    }

    [Space]
    [SerializeField]
    Image m_rightFill = null;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_rightValue = 0;
    public float RightValue {
        get { return m_rightValue; }
        set { m_rightValue = Mathf.Clamp01(value); }
    }

    void Update()
    {
        m_leftFill.fillAmount = LeftValue * (MAX_LIMIT - MIN_LIMIT) + MIN_LIMIT;
        m_rightFill.fillAmount = RightValue * (MAX_LIMIT - MIN_LIMIT) + MIN_LIMIT;
    }
}
