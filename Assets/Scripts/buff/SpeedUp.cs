using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float power = 600.0f;
    private GameObject effortPref;
    private GameObject effort;
    // Start is called before the first frame update
    void Start()
    {
        effortPref = (GameObject)Resources.Load("Prefabs/firePref");
        effort = GameObject.Instantiate(effortPref);
        effort.transform.parent = this.transform;
        effort.transform.localPosition = new Vector3(-0.16f, 0, 0);
        effort.transform.rotation = this.transform.rotation;

        Rigidbody2D rigi = GetComponent<Rigidbody2D>();
        Vector2 direction = rigi.velocity.normalized;
        if (direction.x < 0)
            direction = -direction;
        rigi.AddForce(direction*power);

        Invoke("destoryItself", 1);
    }

    void destoryItself()
    {
        Destroy(effort);  
        Destroy(this);
    }
}
