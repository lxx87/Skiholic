using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroup : MonoBehaviour
{
    public Camera mainCamera;
    public float halfWidth;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*float dist = mainCamera.transform.position.x - this.transform.position.x;
        if (dist > halfWidth)
        {
            Vector3 p = this.transform.position;
            p.x += halfWidth*2;
            this.transform.position = p;
        }*/
        float backgroupX = Mathf.Lerp(transform.position.x, mainCamera.transform.position.x, speed * Time.deltaTime);
        transform.position = new Vector3(backgroupX, transform.position.y, transform.position.z);
    }
}
