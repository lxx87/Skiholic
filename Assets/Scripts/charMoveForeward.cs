using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class charMoveForeward : MonoBehaviour
{
    public float maxVelocity = 1.1f;
    public float speed = 0.02f;
    private PlatformerCharacter2D m_Character;
    private float currVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2(300, 0));
        //GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currVelocity = Mathf.Lerp(currVelocity, maxVelocity, speed);
        //m_Character.Move(currVelocity, false, false);
    }
}
