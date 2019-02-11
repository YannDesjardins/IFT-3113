using UnityEngine;

public class MainGuiController : MonoBehaviour
{
    [SerializeField]
    bool m_enableDebug = true;

    [Header("Sliders")]
    [SerializeField]
    Compass m_compass = null;

    [SerializeField]
    [Range(-180.0f, 180.0f)]
    float m_angle = 0;

    [Space]
    [SerializeField]
    Meters m_meters = null;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_leftValue = 0;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float m_rightValue = 0;

    [Header("Signals")]
    [SerializeField]
    GameObject m_warningSignal = null;
    [SerializeField]
    bool m_warningSignalIsOn = false;

    [Space]
    [SerializeField]
    GameObject m_lightSignal = null;
    [SerializeField]
    bool m_lightSignalIsOn = false;

    [Header("Maintenance")]
    [SerializeField]
    bool m_enableMaintenance = false;

    [Space]
    [SerializeField]
    GameObject m_liveText = null;
    [SerializeField]
    GameObject m_maintenanceText = null;



    public void SetCompassAngle(float _angle) {
        m_compass.Angle = _angle;
    }

    public void SetLeftMeter(float _value) {
        m_meters.LeftValue = _value;
    }

    public void SetRightMeter(float _value) {
        m_meters.RightValue = _value;
    }

    public void SetWarningSignal(bool _value) {
        m_warningSignal.SetActive(_value);
    }

    public void SetLightSignal(bool _value) {
        m_lightSignal.SetActive(_value);
    }

    void FixedUpdate() {
        if (m_enableDebug) {
            SetCompassAngle(m_angle);
            SetLeftMeter(m_leftValue);
            SetRightMeter(m_rightValue);

            SetWarningSignal(m_warningSignalIsOn);
            SetLightSignal(m_lightSignalIsOn);
        }
    }
}
