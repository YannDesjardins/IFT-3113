using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    public AudioSource _impact;    

    private void OnCollisionEnter(Collision collision)
    {
        _impact.Play();
    }
}
