﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseVoice : MonoBehaviour
{
    // Start is called before the first frame update
    static CloseVoice _instance;
    void Start()
    {

    }

    public static CloseVoice instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CloseVoice>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != _instance)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

