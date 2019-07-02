using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCaculate : MonoBehaviour
{

    private int idelFPS = 0;
    private Rigidbody2D rigi;
    private bool win = false;
    private bool deathorFail = false;
    private int coinNum = 0;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(rigi.velocity.x) <= 0.01f && Mathf.Abs(rigi.velocity.y) <= 0.01f)
        {
            idelFPS++;
        }
        else
        {
            idelFPS = 0;
        }

        if (idelFPS>=5&&!win)
        {
            GetComponent<Animator>().SetBool("Fail", true);
            deathorFail = true;
            enabled = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Roadblock"))
        {
            collision.gameObject.GetComponent<RoadblockHit>().hit();
            enabled = false;
            GetComponent<Animator>().SetBool("Death", true);
            charactrterDeath();
            deathorFail = true;
        }

        if (layer == LayerMask.NameToLayer("Coin"))
        {
            this.coinNum++;
            collision.gameObject.GetComponent<CoinHit>().hitCharacter();
            //Destroy(collision.gameObject);
        }

        if (layer == LayerMask.NameToLayer("End"))
        {
            win = true;
            enabled = false;
        }
    }

    public bool isDeathOrFail()
    {
        return deathorFail;
    }

    public bool isWin()
    {
        return win;
    }

    public int getCoinNum()
    {
        return coinNum;
    }

    private void charactrterDeath()
    {
        if (deathorFail)
            return;
        GetComponent<SkinnedMeshRenderer>().enabled = false;

        transform.Find("555_extra").gameObject.SetActive(true);
        Transform groundCheck = transform.Find("GroundCheck");
        Transform ceilingChecking = transform.Find("CeilingCheck");
        Vector2 up = ceilingChecking.position - groundCheck.position;
        GetComponent<Rigidbody2D>().AddForce(up.normalized * GetComponent<Rigidbody2D>().velocity.magnitude);

        CapsuleCollider2D[] colliders = GetComponents<CapsuleCollider2D>();
        for(int i=0;i<2;i++)
        {
            colliders[i].enabled = !colliders[i].enabled;
        }
    }
}
