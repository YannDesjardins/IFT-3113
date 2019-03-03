using UnityEngine.EventSystems;
using UnityEngine;
using System;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour, IPointerClickHandler
{
    CanvasGroup canvas;

    public enum Type
    {
        INVENTORY,
        LOOT,
        SETTINGS
    }

    [Serializable]
    public struct KeyLink
    {
        public bool    lctrl;
        public bool    rctrl;
        public bool    lalt;
        public bool    ralt;
        public bool    lshift;
        public bool    rshift;
        public KeyCode key;
    }


    public Type type;
    public KeyLink  key;
    public bool visible = false;

    public void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        SetVisualState(visible);
    }

    public bool KeyLinkPressed()
    {
        if (key.lctrl == Input.GetKey(KeyCode.LeftControl) && key.rctrl == Input.GetKey(KeyCode.RightControl) &&
            key.lalt == Input.GetKey(KeyCode.LeftAlt) && key.ralt == Input.GetKey(KeyCode.RightAlt) &&
            key.lshift == Input.GetKey(KeyCode.LeftShift) && key.rshift == Input.GetKey(KeyCode.RightShift)
            && Input.GetKeyDown(key.key))
            return true;
        return false;
    }

    public void Update()
    {
        if (KeyLinkPressed())
            SetVisualState(!visible);
    }

    public void OnEscape()
    {
        SetVisualState(false);
    }

    public void SetVisualState(bool v)
    {
        visible = v;
        canvas.alpha = Convert.ToInt16(visible);
        transform.SetAsLastSibling();
        canvas.blocksRaycasts = visible;
    }

    public void OnCall()
    {
        visible = !visible;
        canvas.alpha = Convert.ToInt16(visible);
        transform.SetAsLastSibling();
        canvas.blocksRaycasts = visible;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }
}
