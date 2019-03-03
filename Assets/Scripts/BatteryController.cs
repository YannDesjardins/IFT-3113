using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    public GameObject BatteryBar;

    private float widthBar;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform theBarRectTransform = BatteryBar.transform as RectTransform;
        widthBar = theBarRectTransform.sizeDelta.x;

        Debug.Log(widthBar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
