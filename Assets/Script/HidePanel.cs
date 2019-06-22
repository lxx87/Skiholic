using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ButtonPanel;
    void Start()
    {
        ButtonPanel = GameObject.Find("ButtonPlace");
        ButtonPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
