using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedMusic : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bgm;
    void Start()
    {
        bgm = GameObject.Find("BGM");
        if(bgm != null)
        {
            Destroy(bgm);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
