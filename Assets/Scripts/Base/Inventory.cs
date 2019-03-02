using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    // Logic
    public List<Object> slots = new List<Object>();

    // UI
    public GameObject inventoryUI = null;
    public Slot[]  uiSlots;


    public void Start()
    {
        for (int index = 0; index < 25; ++index)
            slots.Add(new Object());

        GetUI();
    }

    public void GetUI()
    {
        if (inventoryUI != null)
            return;

        inventoryUI = GameObject.FindGameObjectWithTag("InventoryUI");

        if (inventoryUI == null)
            return;

        uiSlots = inventoryUI.GetComponentsInChildren<Slot>();
        for (int i = 0; i < uiSlots.Length; ++i)
            uiSlots[i].uid = i;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (inventoryUI == null)
            return;
        for (int i = 0; i < uiSlots.Length; ++i)
            uiSlots[i].Assign(slots[i]);
    }

    public bool ContainPreRequis(List<Gear.Prerequis> prerequis)
    {
        foreach (var requis in prerequis)
            foreach (var slot in slots)
                if (slot.id == requis.ressourceID && slot.categorie == AObject.Categorie.RESSOURCE && slot.quantity >= requis.nbr)
                    return true;
        return false;
    }

    public void ConsumeRessource(List<Gear.Prerequis> prerequis)
    {
        foreach (var requis in prerequis)
            foreach (var slot in slots)
                if (slot.id == requis.ressourceID && slot.categorie == AObject.Categorie.RESSOURCE && slot.quantity >= requis.nbr)
                {
                    slot.quantity -= requis.nbr;
                    if (slot.quantity <= 0)
                    {
                        slot.id = -1;
                        slot.quantity = 0;
                        slot.categorie = AObject.Categorie.ITEM;
                    }
                    break;
                }
    }

    public void AddRessource(ResourcesFactory.ID id, int quantity)
    {
        foreach (var slot in slots)
            if (slot.categorie == AObject.Categorie.RESSOURCE && slot.id == (int)id)
            {
                slot.categorie = AObject.Categorie.RESSOURCE;
                slot.id = (int)id;
                slot.quantity += quantity;
                UpdateUI();
                return ;
            }
        foreach (var slot in slots)
            if (slot.categorie == AObject.Categorie.ITEM && slot.id == -1)
            {
                slot.categorie = AObject.Categorie.RESSOURCE;
                slot.id = (int)id;
                slot.quantity += quantity;
                UpdateUI();
                return;
            }
        ;
    }
}
