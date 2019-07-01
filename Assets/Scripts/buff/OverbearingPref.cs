using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverbearingPref : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("destoryItself", 3);
        Invoke("destroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int layer = collision.gameObject.layer;
        Debug.Log("overbearing hit " + LayerMask.LayerToName(layer));
        if (collision.gameObject.layer == LayerMask.NameToLayer("Roadblock"))
        {
            collision.gameObject.layer = LayerMask.NameToLayer("Default");
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<ParticleSystem>().Play();
            animator.SetBool("destroy", true);
        }
    }

    void destoryItself()
    {
        animator.SetBool("disappear", true);
        GetComponent<CircleCollider2D>().enabled = false;
        Invoke("destroy", 2);
    }


    void destroy()
    {
        Destroy(gameObject);
    }
}
