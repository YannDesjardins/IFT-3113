using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 5.0f;
    public AudioSource submarine;
    
    void FixedUpdate()
    {

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        transform.Translate(x * Time.deltaTime * speed, 0, z * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w") || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift))
        {
            if (!submarine.isPlaying)
            {
                submarine.Play();
            }            
        }
        else
        {
            
            if (submarine.isPlaying)
            {
                submarine.Stop();
            }            
        }
    }
}
