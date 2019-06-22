using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset readtxt;
    GameObject text3;
    GameObject text4;
    //GameObject i3;
    //GameObject i4;
    Button item3;
    Button item4;
    int number;
    void Start()
    {
        text3 = GameObject.Find("Introduction3");
        text4 = GameObject.Find("Introduction4");
        item3 = GameObject.Find("I3").GetComponent<Button>();
        item4 = GameObject.Find("I4").GetComponent<Button>();
        item3.interactable = false;
        item4.interactable = false;
        text3.SetActive(false);
        text4.SetActive(false);
        number = int.Parse(readtxt.text);
        if(number>=0&&number<3)
        {
        }
        if (number>=3)
        {
            text3.SetActive(true);
            item3.interactable = true;
            if(number>=5)
            {
                text4.SetActive(true);
                item4.interactable = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
