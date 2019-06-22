using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float speed = 3.0f;
    public BoxCollider2D bound;
    private Vector3 bottomLeft;
    private Vector3 topRight;
    private float cameraHalfHeight;
    private float cameraHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = bound.bounds.min;
        topRight = bound.bounds.max;
        cameraHalfHeight = GetComponent<Camera>().orthographicSize;
        cameraHalfWidth = cameraHalfHeight * ((float)Screen.width / (float)Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        float cameraX = transform.position.x;
        float cameraY = transform.position.y;
        float targetX = target.transform.position.x;
        float targetY = target.transform.position.y;

        cameraX = Mathf.Lerp(cameraX, targetX, speed * Time.deltaTime);
        cameraY = Mathf.Lerp(cameraY, targetY, speed * Time.deltaTime);

        cameraX = Mathf.Clamp(cameraX, bottomLeft.x + cameraHalfWidth, topRight.x - cameraHalfWidth);
        cameraY = Mathf.Clamp(cameraY, bottomLeft.y + cameraHalfHeight, topRight.y - cameraHalfHeight);
        transform.position = new Vector3(cameraX, cameraY, transform.position.z);
    }
}
