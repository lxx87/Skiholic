using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeaving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            transform.parent.gameObject.GetComponent<Animator>().SetBool("backward", false);
        }
    }
}
