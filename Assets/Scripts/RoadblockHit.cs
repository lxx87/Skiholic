using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadblockHit : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hit()
    {
        AudioSource audioSource = GameObject.Find("Management").GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

    }
}
