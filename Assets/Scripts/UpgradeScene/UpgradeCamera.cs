using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCamera : MonoBehaviour
{
    public GameObject submarin;

	void Update ()
    {
        transform.RotateAround(submarin.transform.position, Vector3.up, 15f * Time.deltaTime);
    }
}
