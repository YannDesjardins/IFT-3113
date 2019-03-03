using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeRender : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material previsual;
    public Material final;

    MeshRenderer[]   objRenderers;
    public GameObject       objectLink;

    public void Awake()
    {
        objRenderers = objectLink.GetComponentsInChildren<MeshRenderer>(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        objectLink.SetActive(true);
        for (int i = 0; i < objRenderers.Length; ++i)
            objRenderers[i].material = previsual;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectLink.SetActive(false);
        for (int i = 0; i < objRenderers.Length; ++i)
            objRenderers[i].material = final;
    }
}
