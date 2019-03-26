using System;
using Thalass.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Thalass.UI {
    public class UpgradeElement : MonoBehaviour, IObserver<Entities.Element.Values> {

        [SerializeField]
        Button m_button = null;

        [SerializeField]
        Slider m_slider = null;

        public void OnCompleted() {
            throw new NotImplementedException();
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnNext(Element.Values value) {
            m_slider.value = value.Level;
            m_button.interactable = (value.Level < 5);
        }
    }
}
