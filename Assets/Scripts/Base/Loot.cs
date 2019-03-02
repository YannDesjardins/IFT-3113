using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    int slotsNbr = 60;

    // Logic
    public List<Object> slots = new List<Object>();

    // UI
    Slot[]  uiSlots;
    public LayerMask mask;


    public void Start()
    {
        for (int index = 0; index < slotsNbr; ++index)
            slots.Add(new Object());

        uiSlots = UIManager.windows[Window.Type.LOOT].GetComponentsInChildren<Slot>();
        for (int i = 0; i < uiSlots.Length; ++i)
            uiSlots[i].uid = i;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < uiSlots.Length; ++i)
            uiSlots[i].Assign(slots[i]);
    }

    public void Update()
    {
    }

    public void GetLoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, float.MaxValue, mask))
            {
            }
        }
    }
}
