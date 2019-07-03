using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset readtxt;
    GameObject i3, i4, l3, l4;
    int number;
    void Start()
    {
        i3 = GameObject.Find("I3");
        i4 = GameObject.Find("I4");
        l3 = GameObject.Find("lock3");
        l4 = GameObject.Find("lock4");

        i3.SetActive(false);
        i4.SetActive(false);
        l3.SetActive(false);
        l4.SetActive(false);

        number = int.Parse(readtxt.text);
        if(number>=0&&number<3)
        {
            l3.SetActive(true);
            l4.SetActive(true);
        }
        if (number>=3)
        {
            i3.SetActive(true);
            l3.SetActive(false);
            l4.SetActive(true);
            if(number>=5)
            {
                i4.SetActive(true);
                l4.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
