using UnityEngine;

public class MainGuiController : MonoBehaviour
{
    [SerializeField]
    Submarine m_submarine = null;

    [Space]
    [SerializeField]
    bool m_enableDebug = true;

    [Header("Sliders")]
    [SerializeField]
    Compass m_compass = null;

    [SerializeField]
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

    [Space]
    [SerializeField]
    CanvasGroup m_maintenanceGroup = null;
    [SerializeField]
    CanvasGroup m_storageGroup = null;

    [Header("Upgradables")]
    [SerializeField]
    UpgradableSlot m_battery = null;
    [SerializeField]
    UpgradableSlot m_armor = null;
    [SerializeField]
    UpgradableSlot m_storage = null;
    [SerializeField]
    UpgradableSlot m_taser = null;
    [SerializeField]
    UpgradableSlot m_propulsion = null;

    [Space]
    [SerializeField]
    float m_batteryRefillSpeed = 5f;

    [Space]
    [SerializeField]
    GameObject m_storageGroup_Basic = null;
    [SerializeField]
    GameObject m_storageGroup_Amateur = null;
    [SerializeField]
    GameObject m_storageGroup_Intermediate = null;
    [SerializeField]
    GameObject m_storageGroup_Advanced = null;
    [SerializeField]
    GameObject m_storageGroup_Masterwork = null;

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
        m_warningSignalIsOn = _value;
        m_warningSignal.SetActive(_value);
    }

    public void SetLightSignal(bool _value) {
        m_lightSignalIsOn = _value;
        m_lightSignal.SetActive(_value);
    }

    public void SetEnableMaintenance(bool _value) {
        m_enableMaintenance = _value;
        m_liveText.SetActive(!_value);
    }

    public void UpgradeBattery() {
        m_submarine.Battery.Upgrade();
        UpdateSlot(m_submarine.Battery, m_battery);
        
    }

    public void UpgradeArmor() {
        m_submarine.Armor.Upgrade();
        UpdateSlot(m_submarine.Armor, m_armor);
        SetRightMeter(m_submarine.Armor.Ratio);
    }

    public void UpgradeStorage() {
        m_submarine.Storage.Upgrade();
        UpdateSlot(m_submarine.Storage, m_storage);
        SetStorageSpace(m_submarine.Storage.Level);
    }

    public void UpgradeTaser() {
        m_submarine.Taser.Upgrade();
        UpdateSlot(m_submarine.Taser, m_taser); 
    }

    public void UpgradePropulsion() {
        m_submarine.Propulsion.Upgrade();
        UpdateSlot(m_submarine.Propulsion, m_propulsion);
    }

    void UpdateSlot(Submarine.Element _element, UpgradableSlot _slot) {
        _slot.Current = (int)_element.Level;
        _slot.Enable = (_element.Level < UpgradeLevel.Masterwork);
    }

    void SetStorageSpace(UpgradeLevel _level) {
        m_storageGroup_Basic.SetActive(_level >= UpgradeLevel.Basic);
        m_storageGroup_Amateur.SetActive(_level >= UpgradeLevel.Amateur);
        m_storageGroup_Intermediate.SetActive(_level >= UpgradeLevel.Intermediate);
        m_storageGroup_Advanced.SetActive(_level >= UpgradeLevel.Advanced);
        m_storageGroup_Masterwork.SetActive(_level >= UpgradeLevel.Masterwork);
    }

    void Start() {
        UpdateSlot(m_submarine.Battery, m_battery);
        UpdateSlot(m_submarine.Armor, m_armor);
        UpdateSlot(m_submarine.Storage, m_storage);
        UpdateSlot(m_submarine.Taser, m_taser);
        UpdateSlot(m_submarine.Propulsion, m_propulsion);

        SetLeftMeter(m_submarine.Battery.Ratio);
        SetRightMeter(m_submarine.Armor.Ratio);
        SetStorageSpace(m_submarine.Storage.Level);
    }

    void FixedUpdate() {
        if (m_enableDebug) {
            SetCompassAngle(m_angle);
            SetLeftMeter(m_leftValue);
            SetRightMeter(m_rightValue);

            SetWarningSignal(m_warningSignalIsOn);
            SetLightSignal(m_lightSignalIsOn);

        }

        SetEnableMaintenance(m_enableMaintenance);
    }

    void Update() {
        if (m_enableMaintenance) {
            m_maintenanceGroup.gameObject.SetActive(true);
            m_storageGroup.gameObject.SetActive(true);

            Fade(m_maintenanceGroup);
            Fade(m_storageGroup);

        } else {
            if (m_maintenanceGroup.gameObject.activeSelf)
                m_maintenanceGroup.gameObject.SetActive(!Fade(m_maintenanceGroup, false, 0.05f));

            if (m_storageGroup.gameObject.activeSelf)
                m_storageGroup.gameObject.SetActive(!Fade(m_storageGroup, false, 0.05f));
        }

        if (m_submarine.Battery.Ratio < 1.0f) {
            m_submarine.Battery.Current += m_batteryRefillSpeed;
            SetLeftMeter(m_submarine.Battery.Ratio);
        }
            
    }

    /// <summary>
    /// Fade in or out a canvas group.
    /// </summary>
    /// <param name="_group">Group to fade.</param>
    /// <param name="_in">Fade in (true) will show group. Fade out (false) will hide group.</param>
    /// <param name="_speed">Alpha change per loop.</param>
    /// <returns>Returns true when fade is complete.</returns>
    bool Fade(CanvasGroup _group, bool _in = true, float _speed = 0.025f) {
        _group.interactable = _in;
        _group.blocksRaycasts = _in;

        if (!_in) _speed *= -1;
        _group.alpha = Mathf.Clamp01(_group.alpha + _speed);

        return (_in) ? (_group.alpha >= 1.0f) : (_group.alpha <= 0.0f);
    }
}
