using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EsayAnimation;

public class PlayerContorller : MonoBehaviour {

    private Animator animator;

    private float clickTime = 0.001f;

    private bool isClick;

    [Header("跳跃时间")]
    public float timeJumpMax = 0.5f;
    [Header("跳跃系数")]
    public float jumpOffset;

    public ParticleSystem downParticle;

    public GameObject xuli;

    private EaseAinmationDrive ead;
    [Header("是否部署超级瞄准")]
    public bool isVIP;

    // Use this for initialization
    void Start () {
        animator = transform.GetChild(0).GetComponent<Animator>();
        ead = new EaseAinmationDrive(5, 0, jumpOffset, EaseActionMethod.Linear);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.isGameing) {
            PlayerContor();
            if (isClick && clickTime < 5)
            {
                clickTime += Time.deltaTime;
                if (clickTime > 5)
                {
                    clickTime = 5;
                }
            }
            if (transform.position.y <= -1) {
                GameManager.Instance.isGameing = false;
            }
        }
        if (transform.position.y <= -5)
        {
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// 触摸控制方法
    /// </summary>
    public void PlayerContor() {
        if (GameManager.Instance.isGameing && !GameManager.Instance.isJumping) {

            if (Input.GetMouseButtonDown(0)) {
                xuli.SetActive(true);
                animator.SetBool("isJump" , true);
                isClick = true;
            }

            if (Input.GetMouseButtonUp(0) && isClick) {
                xuli.SetActive(false);
                GameManager.Instance.isJumping = true;
                isClick = false;
                StartCoroutine(move(clickTime));
                clickTime = 0.001f;
            }
        }
    }

    IEnumerator move(float timeClick) {
        transform.parent = null;
        float timelen = timeJumpMax;
        animator.SetFloat("jumpSpeed", timelen);
        animator.SetBool("isJump", false);

        float Movelength = timeClick * jumpOffset;

        Vector3 fromPos = transform.position;

        
        Vector3 movePos = (GameManager.Instance.nextFloor - transform.position);
        movePos = new Vector3(movePos.x, 0, movePos.z).normalized * Movelength;
        Debug.Log("点击时间:" + timeClick + "距离：" + movePos);
        ///VIP玩家 自动部署超级瞄准
        if (isVIP) 
            movePos = (GameManager.Instance.nextFloor - transform.position);

        Transform RotaTransform = transform.GetChild(0);

        //关闭受重力影响
        gameObject.GetComponent<Rigidbody>().useGravity = false;

        while (timelen >= 0) {
            timelen -= 0.02f;
            
            //移动进度（0 ~ 1)
            float timelv = (timeJumpMax - timelen) / timeJumpMax;

            if (timelv > 1)
            {
                timelv = 1;
            }

            transform.position = new Vector3(
                fromPos.x + movePos.x * timelv,
                fromPos.y + quadraticMath(timelv * Movelength, Movelength* 0.5f , 3) , 
                fromPos.z + movePos.z * timelv);

            //旋转到指定的跳跃方向
            if (GameManager.Instance.nextFloor.x > GameManager.Instance.nowFloor.x)
            {
                RotaTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -360 * timelv));
            }
            else
            {
                RotaTransform.rotation = Quaternion.Euler(new Vector3(360 * timelv, 0, 0));
            }
            

            animator.SetFloat("jumpSpeed", timelen);

            yield return new WaitForSeconds(0.02f);
            
        }
        //重置角度
        RotaTransform.rotation = Quaternion.Euler(0, 0, 0);
        //开启受重力影响
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        
        yield return 0;
    }

    //y轴抛物线函数
    public float quadraticMath(float x , float h , float k) {
        if (h == 0) {
            h = 1;
        }
        return  - (k * (x - h) * (x - h) / (h * h) - k);
    }

    private void OnCollisionEnter(Collision collision)
    {
        downParticle.Play();
    }


}
