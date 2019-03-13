using System;
using UnityEngine;

/// <summary>
/// Défi 2 - Guillaume Dubé
/// Réécriture par Marc Lauzon.
/// </summary>

namespace Thalass.Inventory {
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject {

        [SerializeField]
        [Tooltip("Do not edit")]
        string m_id = "";
        public Guid ID { get; }

        [Space]
        [SerializeField]
        string m_name = "No Name";
        public string Name {
            get { return m_name; }
        }

        [SerializeField]
        Sprite m_icon = null;
        public Sprite Icon {
            get { return m_icon; }
        }

        [Space]
        [SerializeField]
        string m_description = "No Description";
        public string Description {
            get { return m_description; }
        }

        Item() {
            ID = new Guid();
            m_id = ID.ToString();
        }
    }
}
