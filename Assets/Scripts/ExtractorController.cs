using UnityEngine;

namespace Thalass.Player {
    public class ExtractorController : MonoBehaviour {

        [SerializeField]
        Entities.Submarine m_submarine = null;

        [SerializeField]
        Inventory.Storage m_storage = null;

        [Space]
        [SerializeField]
        Camera m_camera = null;

        [Header("Effects")]
        [SerializeField]
        ProgressControlV3D m_effect = null;

        [Header("Modifiers")]
        float m_baseDamage = 10.0f;

        float Range {
            get { return m_submarine.Weaponry.Maximum; }
        }

        public float Damage {
            get { return m_submarine.Weaponry.Current; }
        }

        void Start() {
            m_storage.SetMaxStacks(Mathf.CeilToInt(m_submarine.Storage.Maximum));
            m_storage.Clear(); //DEBUG.
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetButton("Fire1")) {
                Shoot();
            } else {
                m_effect.extract = false;
                m_effect.triggerExtract = false;
            }
                
        }

        void Shoot() {          
            if (Physics.Raycast(m_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) {
                transform.LookAt(hit.point);
                float distance = Vector3.Distance(transform.position, hit.point);

                //Update weaponry damage.
                m_submarine.Weaponry.Current = m_baseDamage * (1 - distance / Range);

                //If deposit.
                Entities.Deposit deposit = hit.collider.gameObject.GetComponent<Entities.Deposit>();

                if (deposit && distance < Range) {
                    deposit.Grind(this);
                    m_effect.extract = true;
                    m_effect.triggerExtract = true;
                }

                //If wildlife.
                WildlifeController wildlife = hit.collider.gameObject.GetComponent<WildlifeController>();

                if (wildlife && distance < Range) {
                    wildlife.GetDamaged(m_submarine.Weaponry.Current);
                    m_effect.extract = true;
                    m_effect.triggerExtract = true;
                }
            }
        }

        public void Harvest(Inventory.Stack _stack) {
            m_storage.Add(_stack);
        }
    }
}
