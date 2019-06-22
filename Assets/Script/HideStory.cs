using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStory : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject StoryPanel;
    void Start()
    {
        StoryPanel = GameObject.Find("StoryPanel");
        StoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
