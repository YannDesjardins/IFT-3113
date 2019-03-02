using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Canvas  topParent;
    public Slot slot;
    Vector3 posInSlot;
    Image img;

    public void Start()
    {
        topParent = GetComponentInParent<Canvas>();
        slot = GetComponentInParent<Slot>();
        posInSlot = transform.localPosition;
        img = GetComponent<Image>();
        img.raycastTarget = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(topParent.transform);

        img.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetDragObject();
    }

    public void ResetDragObject()
    {
        transform.SetParent(slot.transform);
        transform.SetAsFirstSibling();

        transform.localPosition = posInSlot;

        img.raycastTarget = true;
    }
}
