using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAndSpeedup : MonoBehaviour
{
    private Transform m_GroundCheck;
    private bool sky = false;
    public float precent = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_GroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            if (sky)
            {
                
                sky = false;
                Rigidbody2D rigi = GetComponent<Rigidbody2D>();
                Debug.Log("Speedup: "+ rigi.velocity.y);
                rigi.AddForce(new Vector2(Mathf.Abs(rigi.velocity.y) * precent, 0));
            }
        }
        else
        {
            sky = true;
        }
    }
}
