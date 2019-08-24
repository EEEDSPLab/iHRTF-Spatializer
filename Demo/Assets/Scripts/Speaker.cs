using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Speaker : EventTrigger
{

    private bool dragging;
    public Vector3 origin;
    // Use this for initialization

    private float speed = 2f;

    private Button move1;
    private Button move2;
    private Button move3;
    public Slider speedSlider;
    private bool updown = false;
    private bool leftright = false;
    private bool circle = false;

    public float azimuth;
    public float elevation;

    private GameObject speaker;
    void Start()
    {
        origin = transform.position;
        move1 = GameObject.Find("Move1").GetComponent<Button>();
        move2 = GameObject.Find("Move2").GetComponent<Button>();
        move3 = GameObject.Find("Move3").GetComponent<Button>();
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();

        move1.onClick.AddListener(OnClick_move1);
        move2.onClick.AddListener(OnClick_move2);
        move3.onClick.AddListener(OnClick_move3);
        speaker = GameObject.Find("Rotator");
    }

    // Update is called once per frame
    void Update()
    {
        speed = speedSlider.value;
        if (dragging)
        {
            Vector3 pos = Input.mousePosition - origin;
            if (Math.Abs(pos.x) >= 300)
                pos.x = 300 * pos.x / Math.Abs(pos.x);
            if (Math.Abs(pos.y) >= 200)
                pos.y = 200 * pos.y / Math.Abs(pos.y);
            transform.position = pos + origin;
        }

        if (updown)
        {
            move1.GetComponent<Image>().color = Color.yellow;
            float y = Mathf.Sin(Time.time * speed) * 200;
            Vector3 pos = new Vector3(0, y);
            transform.position = pos + origin;

        }
        else
            move1.GetComponent<Image>().color = Color.white;
        if (leftright)
        {
            float x = Mathf.Sin(Time.time * speed) * 200;
            Vector3 pos = new Vector3(x, 0);
            transform.position = pos + origin;
            move2.GetComponent<Image>().color = Color.yellow;
        }
        else
            move2.GetComponent<Image>().color = Color.white;
        if (circle)
        {
            float x = Mathf.Sin(Time.time * speed) * 150;
            float y = Mathf.Cos(Time.time * speed) * 150;
            
            Vector3 pos = new Vector3(x, y);
            transform.position = pos + origin;
            move3.GetComponent<Image>().color = Color.yellow;
        }
        else
            move3.GetComponent<Image>().color = Color.white;

        //change speaker position  based on speaker position
        //reversed compare to speaker
        Vector3 p = transform.position - origin;
        azimuth = p.x / 5;
        elevation = -p.y / 5;
        speaker.transform.eulerAngles = new Vector3(elevation, azimuth, 0);
        //Debug.Log(azimuth.ToString() + "; " + elevation.ToString());


    }

    void OnClick_move1()
    {
        updown = !updown;
        leftright = false;
        circle = false;
    }
    void OnClick_move2()
    {
        leftright = !leftright;
        updown = false;
        circle = false;
    }
    void OnClick_move3()
    {
        circle = !circle;
        updown = false;
        leftright = false;
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
