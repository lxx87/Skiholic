using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    private ParticleSystem particle;
    private GameObject coin;
    public AudioClip audioClip;
    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        coin = transform.Find("Coin-1").gameObject;
    }

    public void hitCharacter()
    {
        AudioSource audioSource = GameObject.Find("Management").GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
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
