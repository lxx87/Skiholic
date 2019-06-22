﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStart : MonoBehaviour
{
    public GameObject canvas;
    public GameObject charactor;
    [SerializeField]
    private GameObject pauseButton;
    public void begin()
    {
        canvas.transform.Find("buffBtn").gameObject.SetActive(true);
        charactor.GetComponent<charMoveForeward>().enabled = true;
        charactor.GetComponent<Rigidbody2D>().gravityScale = 1;
        charactor.GetComponent<ScoreCaculate>().enabled = true;
        canvas.GetComponent<Props>().clearProps();
        canvas.GetComponent<MoveAndDraw>().clearMoveDraw();
        pauseButton.SetActive(true);

        startAchievementJudge();
    }

    private void startAchievementJudge()
    {
        BaseAchievement[] achievements = GetComponents<BaseAchievement>();
        for (int i = 0; i < achievements.Length; i++)
        {
            achievements[i].enabled = true;
        }
    }
}
