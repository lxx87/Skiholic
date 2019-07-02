using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgZoom : MonoBehaviour
{
    public GameObject NML;

    public GameObject character;
    
    public Transform m_GroundCheck;

    public Vector3 originNmlScale;
    private float maxZoom = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        originNmlScale = this.NML.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nowScale = this.NML.transform.localScale;

        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        if (hit.collider == null)
        {
            if (nowScale.x > (originNmlScale.x-maxZoom))
            {
                this.NML.transform.localScale = new Vector3(nowScale.x - 0.0004f, nowScale.y - 0.0004f, originNmlScale.z);
            }
        }
        else
        {
            if (nowScale.x < (originNmlScale.x + maxZoom))
            {
                this.NML.transform.localScale = new Vector3(nowScale.x + 0.0004f, nowScale.y + 0.0004f, originNmlScale.z);
            }
        }
        //print(this.NML.transform.localScale.x);
    }
}
