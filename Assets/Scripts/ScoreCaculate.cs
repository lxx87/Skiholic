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
            Debug.Log("You Are Fail");
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
            deathorFail = true;
            enabled = false;
            Debug.Log("You Are Fail");
            GetComponent<Animator>().SetBool("Death", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (layer == LayerMask.NameToLayer("Coin"))
        {
            this.coinNum++;
            Destroy(collision.gameObject);
        }

        if (layer == LayerMask.NameToLayer("End"))
        {
            win = true;
            enabled = false;
            Debug.Log("You Are Win");
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
}
