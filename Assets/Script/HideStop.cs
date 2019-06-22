using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStop : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject StopPanel;
    void Start()
    {
        StopPanel = GameObject.Find("StopPanel");
        StopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
