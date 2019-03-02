using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject CameraP;

    private GameObject camera;
    private float speed_player = 0.1f;

    void Start()
    {

        Cursor.visible = false;
        camera = (GameObject)GameObject.Instantiate(CameraP);
        camera.transform.SetParent(transform);
        camera.transform.localPosition = Vector3.zero;
        camera.transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {

        this.transform.rotation = camera.transform.rotation;
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 position = this.transform.position;
            position += camera.transform.right * speed_player;
            this.transform.position = position;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 position = this.transform.position;
            position += camera.transform.right * (-1) * speed_player;
            this.transform.position = position;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 position = this.transform.position;
            position += camera.transform.forward * speed_player;
            this.transform.position = position;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Vector3 position = this.transform.position;
            position += camera.transform.forward * (-1) * speed_player;
            this.transform.position = position;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
