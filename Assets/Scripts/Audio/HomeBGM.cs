using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBGM : MonoBehaviour
{
    // Start is called before the first frame update
    static HomeBGM _instance;
    void Start()
    {
        
    }

    public static HomeBGM instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<HomeBGM>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if(_instance==null)
        {
            _instance=this;
            DontDestroyOnLoad(this);
        }
        else if(this!= _instance)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
