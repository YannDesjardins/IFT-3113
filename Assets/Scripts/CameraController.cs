using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public float minimumX = -60f;
    //public float minimumY = -360f;
    //public float maximumX = 60f;
    //public float maximumY = 360f

    public float sensitivityX = 10f;
    public float sensitivityY = 10f;

    float rotationY = 0f;
    float rotationX = 0f;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Cursor.visible)
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivityY;
            rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

            transform.localEulerAngles = new Vector3(0, rotationY, 0);
            cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
