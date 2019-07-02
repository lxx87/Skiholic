using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpendicularToGround : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask ground;
    private Transform m_GroundCheck;
    void Start()
    {
        m_GroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down,0.2f,LayerMask.GetMask("Ground"));
        if(hit.collider!=null)
        {
            
            Quaternion nextRot = Quaternion.LookRotation(new Vector3(0,0,1), hit.normal);
            //transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, 0.1f*Time.deltaTime);
            transform.rotation = nextRot;


        }
        else
        {
            Quaternion nextRot = Quaternion.LookRotation(Vector3.forward,Vector3.up);
            //transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, 0.1f * Time.deltaTime);
            transform.rotation = nextRot;
        }
    }
}
