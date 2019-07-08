using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    
    public float power = 30.0f;
    private GameObject trail;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("use power: " + power);
        Rigidbody2D rigi = GetComponent<Rigidbody2D>();
        Vector2 direction = rigi.velocity.normalized;
        if (direction.x < 0)
            direction = -direction;
        rigi.AddForce(direction*power);
        trail = transform.Find("Trail").gameObject;
        trail.GetComponent<TrailRenderer>().enabled = true;
        Invoke("destoryItself", 1);
    }

    void destoryItself()
    {
        trail.GetComponent<TrailRenderer>().enabled = false;
        Destroy(this);
    }
}
