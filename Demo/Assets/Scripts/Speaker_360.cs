using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Speaker_360 : EventTrigger
{

    private bool dragging;
    public Vector3 origin;
    // Use this for initialization

 
    private GameObject speaker;
    private Text azm_text;

    void Start()
    {
        origin = GameObject.Find("Head").transform.position;
        azm_text = GameObject.Find("AzimuthText").GetComponent<Text>();
        speaker = GameObject.Find("Rotator");
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector3 pos = Input.mousePosition - origin;
            float r = Mathf.Atan2(pos.x, pos.y);

            pos.x = Mathf.Sin(r) * 200;
            pos.y = Mathf.Cos(r) * 200;
            
            transform.position = pos + origin;

        }
        Vector3 p = transform.position - origin;
        float azimuth = Mathf.Atan2(p.x, p.y);
        azimuth = azimuth * (180.0f / Mathf.PI);
        speaker.transform.eulerAngles = new Vector3(0, azimuth, 0);
        azm_text.text = "Azimuth: " + ((int)azimuth).ToString();


    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
