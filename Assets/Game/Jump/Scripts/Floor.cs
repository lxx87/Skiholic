using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EsayAnimation;

public class Floor : MonoBehaviour {

    public Material[] materials;

    private bool isFristJump;

    private EasyAnimation_Move eaMove;

    private bool isAnimationing;

    private void Start()
    {
        eaMove = GetComponent<EasyAnimation_Move>();
        
    }

    private void OnEnable()
    {
        RandomMaterial();
        isFristJump = false;
    }

    private void OnDisable()
    {
        if (eaMove != null) {
            eaMove.removeListener(jumpEvent, PlayActionType.On_End);
            eaMove.isAutoPlay = true;
            eaMove.isBack = false;
            eaMove.isInversion = true;
            eaMove.vector_To = new Vector3(0, -20f, 0);
            eaMove.easetype = EaseActionMethod.CubicEaseOut;
            eaMove.animationTime = 0.5f;
        }
    }

    void RandomMaterial() {
        if (materials.Length > 0)
        {
            int r = Random.Range(0, materials.Length);
            GetComponent<MeshRenderer>().material = materials[r];
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;    //获取碰撞点

        float FloorLength = Vector2.Distance(new Vector2(pos.x , pos.z) , new Vector2(transform.parent.position.x , transform.parent.position.z));
        float VLength = FloorLength / (transform.parent.localScale.x * 0.5f);
        Debug.Log("落点比例: " + VLength + "落点距离: " + FloorLength + " 落点位置：" + new Vector2(pos.x, pos.z) + " 地板位置：" + new Vector2(transform.position.x, transform.position.z) + " scale: " + transform.parent.localScale);

        //添加落地震动
        //Handheld.Vibrate();

        if (!isFristJump)
        {
            if (FloorLength <= 0.1f)
            {
                
                GamePool.Instance.DisableObjectWitchTable("floorEffect");
                //创建地板
                GamePool.Instance.InstantiatePoolObject<ParticleSystem>("floorEffect", pos, Quaternion.Euler(-90, 0, 0) , new Vector3(transform.parent.localScale.x - 0.5f, transform.parent.localScale.x - 0.5f, 0)).Play();
                superAward();
                downMove(collision.transform);
            }
            else if (VLength < 0.9f)
            {
                award();
                downMove(collision.transform);
            }
            else
            {
                GameManager.Instance.isGameing = false;
                collision.transform.parent = null;
                collision.rigidbody.freezeRotation = false;
                collision.transform.Find("Capsule").GetComponent<Animator>().enabled = false;
                collision.rigidbody.AddForce(new Vector3(-transform.position.x + pos.x, 0, -transform.position.z + pos.z) * 10);
            }
        }
        else {
            downMove(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        jumpMove();
    }

    /// <summary>
    /// 跳跃奖励，正确跳跃到方块时 触发该方法
    /// </summary>
    private void award() {
        GameManager.Instance.addScore(1);
    }

    /// <summary>
    /// 跳跃奖励，跳跃到方块中心时 触发该方法
    /// </summary>
    private void superAward()
    {
        GameManager.Instance.addScore(2);
    }

    public void downMove(Transform tran) {
        //判断是否第一次接触地板，如果是 则产生下一个地板
        if (!isFristJump) {
            GameManager.Instance.NextFloor(new Vector3(transform.position.x, -9, transform.position.z));
            isFristJump = true;
        }
        //判断是否正在播放动画，没有播放则开始播放动画
        if (!isAnimationing) {
            //设置主角父物体为当前地板，使得完全跟随父对象动画
            tran.parent = transform;
            eaMove.addListener(jumpEvent, PlayActionType.On_End);
            isAnimationing = true;
            eaMove.isAutoPlay = false;
            eaMove.isBack = true;
            eaMove.isInversion = false;
            eaMove.vector_To = new Vector3(0, -0.35f, 0);
            eaMove.easetype = EaseActionMethod.SineEaseOut;
            eaMove.animationTime = 0.35f;
            eaMove.Play();
        }
    }

    public void jumpMove() {
        if (!isAnimationing) {
            eaMove.isAutoPlay = false;
            eaMove.isBack = true;
            eaMove.isInversion = false;
            eaMove.vector_To = new Vector3(0, -0.25f, 0);
            eaMove.easetype = EaseActionMethod.Linear;
            eaMove.animationTime = 0.2f;
            eaMove.Play();
        }
    }

    private void jumpEvent()
    {
        GameManager.Instance.isJumping = false;
        isAnimationing = false;
        eaMove.removeListener(jumpEvent, PlayActionType.On_End);
    }
}
