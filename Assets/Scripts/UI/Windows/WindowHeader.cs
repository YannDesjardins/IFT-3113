using UnityEngine.EventSystems;
using UnityEngine;

public class WindowHeader : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Window window;
    bool      oldVisible = false;

    [Header("Drag Data")]
    public bool draggable = true;

    Vector2 lastCursorPos = Vector2.zero;

    public bool resetToPos = true;
    Vector3 initialWindowPosition = Vector3.zero;

    public void Start()
    {
        window = GetComponentInParent<Window>();
        initialWindowPosition = window.transform.position;
        oldVisible = window.visible;
    }

    public void Update()
    {
        if (oldVisible && !window.visible)
            window.transform.position = initialWindowPosition;
        oldVisible = window.visible;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!draggable || !window.visible)
            return;
        lastCursorPos = eventData.position;
        window.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!draggable || !window.visible)
            return;

        Vector3 offset = Vector3.zero;

        offset.x = eventData.position.x - lastCursorPos.x;
        offset.y = eventData.position.y - lastCursorPos.y;
        window.transform.position += offset;
        lastCursorPos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!draggable || !window.visible)
            return;
    }
}
