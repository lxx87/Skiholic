using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //磁铁buff
    private LayerMask coinMask;
    public float radius = 1.5f;
    public float coinMoveSpeed = 10f;
    public float duration = 3.0f;//持续时间
    private GameObject effortPref;
    private GameObject effort;
    // Start is called before the first frame update
    void Start()
    {
        coinMask = LayerMask.GetMask("Coin");
        effortPref = (GameObject)Resources.Load("Prefabs/manetEffort");
        Invoke("destoryItself", duration);
        effort = GameObject.Instantiate(effortPref);
        effort.transform.parent = this.transform;
        effort.transform.localPosition = new Vector3(0, 0, -4);
        effort.transform.localScale = new Vector3(radius, radius, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] coins = Physics2D.OverlapCircleAll(transform.position, radius, coinMask);
        for (int i=0;i<coins.Length;i++)
        {
            coins[i].gameObject.transform.position=Vector3.MoveTowards(coins[i].gameObject.transform.position, this.transform.position, 
                Time.deltaTime * coinMoveSpeed);
        }
    }

    void destoryItself()
    {
        Debug.Log("Destory Magnet");
        Destroy(effort);
        Destroy(this);
    }
}
