using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmarineController : MonoBehaviour
{
    public float swimSpeed;
    public Slider BatteryBar;
    public float energyLossSpeed;
    public float dragByWater;

    private Vector3 moveDirection;
    private Rigidbody rb;
    private Vector3 velocity;

    public Camera cam;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = rb.velocity;
        rb.drag = dragByWater;
        BatteryBar.value = 100f;
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = (horizontalMovement * cam.transform.right + verticalMovement * cam.transform.forward).normalized;
        if (moveDirection != Vector3.zero)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);
        }
        
    }


    private void Move()
    {
        BatteryBar.value -= energyLossSpeed;
        rb.velocity = moveDirection * swimSpeed * Time.deltaTime;   
    }
}
