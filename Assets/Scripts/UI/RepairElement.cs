using System;
using Thalass.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Thalass.UI {
    public class RepairElement : MonoBehaviour, IObserver<Element.Values> {

        [SerializeField]
        Slider m_slider = null;

        [SerializeField]
        Button m_button = null;

        [SerializeField]
        bool m_bool = false;

        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnNext(Element.Values value) {
            m_slider.maxValue = value.Maximum;
            m_slider.value = value.Current;

            m_button.interactable = (value.Current < value.Maximum) ^ m_bool;
        }
    }
}
