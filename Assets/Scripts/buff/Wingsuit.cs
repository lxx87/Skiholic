using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wingsuit : MonoBehaviour
{
    public float gravityScale = 0.0f;
    private float realGravityScale;
    private Transform m_GroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        m_GroundCheck = transform.Find("GroundCheck");
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        if (hit.collider == null)//在空中
        {
            Debug.Log("Set Gravity to Zero");
            this.realGravityScale = GetComponent<Rigidbody2D>().gravityScale;
            GetComponent<Rigidbody2D>().gravityScale = this.gravityScale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        if (hit.collider != null)//着地
        {
            Debug.Log("Reset Gravity to "+ realGravityScale);
            destroyItself();
        }
    }

    private void destroyItself()
    {
        if(GetComponent<Rigidbody2D>().gravityScale - gravityScale > 0.01f)//滑翔伞开启成功
        {
            GetComponent<Rigidbody2D>().gravityScale = realGravityScale;
        }
        Destroy(this);
    }
}
