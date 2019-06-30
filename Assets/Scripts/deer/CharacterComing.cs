using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Character coming");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            transform.parent.gameObject.GetComponent<Animator>().SetBool("forward", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Character coming");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            transform.parent.gameObject.GetComponent<Animator>().SetBool("backward", true);
        }
    }
}
