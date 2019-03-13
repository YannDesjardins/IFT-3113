using System;
using System.Collections.Generic;
using UnityEngine;

namespace Thalass.Entities {

    [Serializable]
    public class Element : IObservable<Element.Values> {

        [SerializeField]
        Level m_level = Level.Weak;
        public Level Level {
            get { return m_level; }
        }

        [Space]
        [SerializeField]
        float m_base = 0;
        public float Maximum {
            get { return m_base * (int)Level; }
        }

        [SerializeField]
        float m_current = 0;
        public float Current {
            get { return m_current; }
            set {
                m_current = Mathf.Clamp(value, 0, Maximum);
                Rollout();
            }
        }

        public float Ratio {
            get { return Mathf.Clamp01(Current / Maximum); }
        }

        /// <summary>
        /// Move up level enum by one.
        /// </summary>
        public void LevelUp() {
            if (m_level < Level.Epic) {
                m_level++;
                Rollout();
            }
        }

        /// <summary>
        /// Restore level enum to weak and 
        /// refresh current to updated maximum.
        /// </summary>
        public void Clear() {
            m_level = Level.Weak;
            Current = Current;
        }

        #region Observable pattern
        public struct Values {
            public float Current { get; }
            public float Maximum { get; }

            public Values(float _current, float _maximum) {
                Current = _current;
                Maximum = _maximum;
            }
        }

        List<IObserver<Values>> m_observers = new List<IObserver<Values>>();

        /// <summary>
        /// Register an observer to warn on value change.
        /// </summary>
        /// <param name="_observer">Observing callback.</param>
        /// <returns>Object for unsubscribing.</returns>
        public IDisposable Subscribe(IObserver<Values> _observer) {
            if (!m_observers.Contains(_observer))
                m_observers.Add(_observer);

            return new Unsubscriber<Values>(m_observers, _observer);
        }

        /// <summary>
        /// Warn every registered observers about a value change.
        /// </summary>
        void Rollout() {
            Values values = new Values(Current, Maximum);

            foreach (IObserver<Values> observer in m_observers)
                observer.OnNext(values);
        }
        #endregion
    }
}
