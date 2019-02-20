using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Submarine", menuName = "Submarine")]
public class Submarine : ScriptableObject {

    [Serializable]
    public class Element {
        [SerializeField]
        UpgradeLevel m_level = UpgradeLevel.Basic;
        public UpgradeLevel Level => m_level;

        [Space]
        [SerializeField]
        float m_base = 0;
        public float Maximum => m_base * (int)Level;
        [SerializeField]
        float m_current = 0;
        public float Current {
            get => m_current;
            set => m_current = Mathf.Clamp(value, 0, Maximum);
        }
        public float Ratio => Mathf.Clamp01(Current / Maximum);

        public void Upgrade() {
            if (m_level < UpgradeLevel.Masterwork)
                m_level++;
        }

        public void Reduce(float _value) {
            if (_value <= 0)
                return;

            Current -= _value;
        }

        public void Augment(float _value) {
            if (_value <= 0)
                return;

            Current += _value;
        }

        public void Empty() {
            Current = 0;
        }

        public void Full() {
            Current = Maximum;
        }
    }

    [Header("Upgradables")]
    [SerializeField]
    Element m_battery = null;
    public Element Battery => m_battery;

    [SerializeField]
    Element m_armor = null;
    public Element Armor => m_armor;

    [SerializeField]
    Element m_storage = null;
    public Element Storage => m_storage;

    [SerializeField]
    Element m_taser = null;
    public Element Taser => m_taser;

    [SerializeField]
    Element m_propulsion = null;
    public Element Propulsion => m_propulsion;
}

public enum UpgradeLevel {
    None = 0,
    Basic,
    Amateur,
    Intermediate,
    Advanced,
    Masterwork
}