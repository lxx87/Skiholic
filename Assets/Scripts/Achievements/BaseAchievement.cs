using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAchievement : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual public bool done()
    {
        return false;
    }

    virtual public string getDescription()
    {
        return "成就描述";
    }
}
