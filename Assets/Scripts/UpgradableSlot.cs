using UnityEngine;
using UnityEngine.UI;

public class UpgradableSlot : MonoBehaviour
{
    [SerializeField]
    Button m_button;

    public bool Enable {
        get => m_button.interactable;
        set => m_button.interactable = value;
    }

    [SerializeField]
    Slider m_slider;

    public float Minimum {
        get => m_slider.minValue;
        set => m_slider.minValue = value;
    }

    public float Maximum {
        get => m_slider.maxValue;
        set => m_slider.maxValue = value;
    }

    public float Current {
        get => m_slider.value;
        set => m_slider.value = value;
    }
}
