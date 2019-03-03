using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour
{
    Canvas  topParent;
    public Slot slot;
    Vector3 posInSlot;
    Image img;

    public void Start()
    {
        img = GetComponent<Image>();
        img.raycastTarget = true;
    }
}
