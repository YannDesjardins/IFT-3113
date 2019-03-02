using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static Dictionary<Window.Type, Window> windows = new Dictionary<Window.Type, Window>();


    public void Start()
    {
        Window[] windowsT =  GetComponentsInChildren<Window>();

        foreach (Window window in windowsT)
        {
            if (windows.ContainsKey(window.type))
                continue;
            windows.Add(window.type, window);
        }
    }

    public void SetWindowVisual(Window.Type windowType, bool visible)
    {
        windows[windowType].SetVisualState(visible);
    }

    public void SetWindowKeyLink(Window.Type windowType, Window.KeyLink keylink)
    {
        windows[windowType].key = keylink;
    }
}
