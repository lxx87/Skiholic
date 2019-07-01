using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    private ParticleSystem particle;
    private GameObject coin;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        coin = transform.Find("Coin-1").gameObject;
    }

    public void hitCharacter()
    {
        Debug.Log("Hit coin");
        particle.Play();
        GetComponent<CircleCollider2D>().enabled = false;
        coin.SetActive(false);
        Invoke("destoryItself", 1);
    }

    private void destoryItself()
    {
        Destroy(gameObject);
    }
}
