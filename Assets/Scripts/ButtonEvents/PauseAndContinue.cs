﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndContinue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gamePause()
    {
        Time.timeScale = 0;
    }

    public void gameContinue()
    {
        Time.timeScale = 1;
    }
}
