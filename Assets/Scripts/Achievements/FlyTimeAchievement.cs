using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTimeAchievement : BaseAchievement
{
    [SerializeField] GameObject player;
    private Transform m_GroundCheck;
    public float baseFlyingTime = 0.0f;
    private float maxFlyingTime = 0.0f;
    private float lastLandTime;
    // Start is called before the first frame update
    void Start()
    {
        lastLandTime = Time.time;
        m_GroundCheck = player.transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(m_GroundCheck.position, Vector2.down, 0.2f, LayerMask.GetMask("Ground"));
        if (hit.collider == null)
        {
            //腾空
            float flyingTime = Time.time - lastLandTime;
            maxFlyingTime = Mathf.Max(maxFlyingTime, flyingTime);
        }
        else
        {
            //着地
            lastLandTime = Time.time;
        }
    }

    public override bool done()
    {
        return maxFlyingTime >= baseFlyingTime;
    }

    public override string getDescription()
    {
        return "腾空" + string.Format("{0:0}",baseFlyingTime) + "秒";
    }
}
