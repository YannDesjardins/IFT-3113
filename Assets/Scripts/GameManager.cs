using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            ToggleCursor();
    }

    void ToggleCursor() {
        Cursor.lockState = (Cursor.lockState == CursorLockMode.None) ? CursorLockMode.Confined : CursorLockMode.None;
    }
}
