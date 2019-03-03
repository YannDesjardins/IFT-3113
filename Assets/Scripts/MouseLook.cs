using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    CursorLockMode locked;
    CursorLockMode unlocked;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        locked = CursorLockMode.Locked;
        unlocked = CursorLockMode.None;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = locked;
            Cursor.visible = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Cursor.lockState = unlocked;
            Cursor.visible = true;
        }
    }
}