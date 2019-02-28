using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour
{
    private enum Element {
        Compass,
        Energy,
        Armor
    }
    [SerializeField]
    Element m_element = Element.Compass;

    [SerializeField]
    MainGuiController m_mainGui = null;
    [SerializeField]
    Submarine m_submarine = null;

    [Space]
    [SerializeField]
    InputField m_textField = null;

    void Start() {
        switch (m_element) {
            case Element.Energy:
                m_textField.text = m_submarine.Battery.Current.ToString();
                break;
            case Element.Armor:
                m_textField.text = m_submarine.Armor.Current.ToString();
                break;
        }
    }

    void LateUpdate() {
        switch (m_element) {
            case Element.Energy:
                m_textField.text = m_submarine.Battery.Current.ToString();
                break;
            case Element.Armor:
                m_textField.text = m_submarine.Armor.Current.ToString();
                break;
        }
    }

    public void Increase() {
        if (float.TryParse(m_textField.text, out float value))
            m_textField.text = (value + 1.0f).ToString();
    }

    public void Decrease() {
        if (float.TryParse(m_textField.text, out float value))
            m_textField.text = (value - 1.0f).ToString();
    }

    public void AngleChange() {
        if (float.TryParse(m_textField.text, out float value))
            m_mainGui.SetCompassAngle(value);
    }

    public void LeftChange() {
        if (float.TryParse(m_textField.text, out float value))
            m_submarine.Battery.Current = value;
    }

    public void RightChange() {
        if (float.TryParse(m_textField.text, out float value))
            m_submarine.Armor.Current = value;
    }
}
