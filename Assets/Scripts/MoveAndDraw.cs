﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndDraw : MonoBehaviour
{
    public Button moveButton;
    public Button drawButton;
    public GameObject gocamera;
    public GameObject golineDrawer;

    public GameObject mob;
    public GameObject drb;

    public Sprite move_first;
    public Sprite move_second;
    public Sprite draw_first;
    public Sprite draw_second;

    int choosed;

    // Start is called before the first frame update
    void Start()
    {
        choosed = 1;
        this.golineDrawer.GetComponent<DrawLine>().enabled = false;
        this.gocamera.GetComponent<CameraMove>().enabled = true;

        moveButton.onClick.AddListener(delegate ()
        {
            choosed = 1;
            this.golineDrawer.GetComponent<DrawLine>().enabled = false;
            this.gocamera.GetComponent<CameraMove>().enabled = true;
            this.moveButton.GetComponent<Image>().sprite = move_first;
            this.drawButton.GetComponent<Image>().sprite = draw_second;
        });

        drawButton.onClick.AddListener(delegate ()
        {
            choosed = 2;
            this.gocamera.GetComponent<CameraMove>().enabled = false;
            this.golineDrawer.GetComponent<DrawLine>().enabled = true;
            this.moveButton.GetComponent<Image>().sprite = move_second;
            this.drawButton.GetComponent<Image>().sprite = draw_first;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clearMoveDraw()
    {
        this.mob.SetActive(false);
        this.drb.SetActive(false);
    }


}