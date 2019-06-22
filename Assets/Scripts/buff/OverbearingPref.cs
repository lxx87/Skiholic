using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverbearingPref : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int layer = collision.gameObject.layer;
        Debug.Log("overbearing hit " + LayerMask.LayerToName(layer));
        if (collision.gameObject.layer == LayerMask.NameToLayer("Roadblock"))
        {
            collision.gameObject.layer = LayerMask.NameToLayer("Default");
            destoryItself();
        }
    }

    void destoryItself()
    {
        Debug.Log("Destory Overbearing");
        Destroy(this.gameObject);
        Destroy(this);
    }
}
