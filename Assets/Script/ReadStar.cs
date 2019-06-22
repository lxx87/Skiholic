using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadStar : MonoBehaviour
{
    // Start is called before the first frame update
    private Text number;
    public TextAsset readtxt;
    void Start()
    {
        number = GetComponent<Text>();
        number.text = readtxt.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
