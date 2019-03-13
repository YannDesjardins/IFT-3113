using System;
using UnityEngine;

/// <summary>
/// Défi 2 - Guillaume Dubé
/// Réécriture par Marc Lauzon.
/// </summary>

namespace Thalass.Inventory {
    [Serializable]
    public class Stack {

        public const int MAX_PER_STACK = 10;

        [SerializeField]
        Item m_item = null;

        public Guid ID {
            get { return (m_item) ? m_item.ID : Guid.Empty; }
        }

        public string Name {
            get { return (m_item) ? m_item.Name : "Empty"; }
        }

        public Sprite Icon {
            get { return (m_item) ? m_item.Icon : null; }
        }

        public string Description {
            get { return (m_item) ? m_item.Description : "No Description"; }
        }

        [SerializeField]
        int m_quantity = 0;
        public int Quantity { get { return m_quantity; } }

        public int Free { get { return MAX_PER_STACK - Quantity; } }

        public Stack(Item _item, int _quantity) {
            m_item = _item;
            m_quantity = _quantity;
        }

        public bool Add(int _value) {
            if ((Quantity + _value) > MAX_PER_STACK)
                return false;

            m_quantity += _value;
            return true;
        }

        public bool Remove(int _value) {
            if ((Quantity - _value) < 0)
                return false;

            m_quantity -= _value;
            return true;
        }

        public void Empty() {
            Remove(Quantity);
        }
    }
}
