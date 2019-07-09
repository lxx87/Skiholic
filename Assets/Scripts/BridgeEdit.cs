using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BridgeEdit : MonoBehaviour
{
    private GameObject currBridge=null;
    public GameObject s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount==1&&Input.touches[0].phase==TouchPhase.Began)
        {
            Debug.Log("Touch Began mobile");
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            p.z = 0;
            transform.position = p;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Touch Began pc");
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0;
            transform.position = p;
        }
    }

    

    private void selectBridge(GameObject b)
    {
        if (b == currBridge)
            return;
        if(currBridge!=null)
        {
            Debug.Log("lighting off");
            
        }
        Debug.Log("linghting on");
        currBridge = b;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bridge")
        {
            Debug.Log("select bridge trigger");
            selectBridge(collision.gameObject);
        }
    }
}
