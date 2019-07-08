using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSecomd : MonoBehaviour
{
    public float duration = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyItself", duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destroyItself()
    {
        Destroy(gameObject);
    }
}
