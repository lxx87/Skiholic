using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wingsuit : MonoBehaviour
{
    public float gravityScale = 0.006f;
    private float realGravityScale;
    private Transform m_GroundCheck;
    private GameObject effortPref;
    private GameObject effort;
    public float duration = 3.0f;//持续时间
    private bool wingsuitOn = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("wingsuit on");
        m_GroundCheck = transform.Find("GroundCheck");
        effortPref = (GameObject)Resources.Load("Prefabs/wingsuitPrefab");
        effort = GameObject.Instantiate(effortPref, this.transform);
        /*effort.transform.parent = this.transform;
        effort.transform.localPosition = new Vector3(-0.2699996f, 1.02f, 0);*/
        /*effort.transform.localScale = new Vector3(0.05435295f, 0.05435295f, 1);*/
        Invoke("stop", duration);

        realGravityScale = GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        bool g = ground();
        if (!g && !wingsuitOn)//在空中且滑翔伞未打开
        {
            GetComponent<Rigidbody2D>().gravityScale = this.gravityScale;
            wingsuitOn = true;
        }
        if(g && wingsuitOn)//不在空中且滑翔伞已打开，即从空中回落至地面
        {
            stop();
        }
    }


    private bool ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }


    private void stop()
    {
        Debug.Log("wingsuit off");
        if(this!=null)
        {
            Debug.Log("wingsuit off: true");
            effort.GetComponent<Animator>().SetBool("disappear", true);
            if(wingsuitOn)
            {
                GetComponent<Rigidbody2D>().gravityScale = realGravityScale;
            }
            Destroy(this);
            Invoke("destroyItself", 1f);
        }
    }

    private void destroyItself()
    {
        Destroy(effort);
        
    }
}
