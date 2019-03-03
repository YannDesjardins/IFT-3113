using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeObj : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [System.Serializable]
    public struct ObjUI
    {
        public Image sprite;
        public Text data;
    }

    public string objName;

    public ObjUI gear = new ObjUI();

    public GameObject ressourcePrefab;
    public GameObject ressourceDest;

    public bool click = false;

    public bool hover = false;
    public bool hasExit = false;

    public void AddPreRequis(Gear.Prerequis required)
    {
        GameObject requis = Instantiate(ressourcePrefab, ressourceDest.transform);

        Image img = requis.GetComponentInChildren<Image>();
        Text data = requis.GetComponentInChildren<Text>();

        img.sprite = Manager.resourcesFactory.objs[required.ressourceID].Key;
        data.text = required.nbr.ToString();
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
        hasExit = true;
    }
}
