using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera mainCamera;
    public float xOffset = 0.1f;
    public float yOffset = 0.1f;
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
        if (Input.GetKey(KeyCode.A))
            move(0 - xOffset, 0);
        if (Input.GetKey(KeyCode.D))
            move(xOffset, 0);
        if (Input.GetKey(KeyCode.S))
            move(0, 0 - yOffset);
        if (Input.GetKey(KeyCode.W))
            move(0, yOffset);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                move(0-touch.deltaPosition.x * Time.deltaTime * 0.5f, 0-touch.deltaPosition.y * Time.deltaTime * 0.5f);
            }
        }
    }

    void move(float mXOffset, float mYOffset)
    {
        float cameraX = transform.position.x + mXOffset;
        float cameraY = transform.position.y + mYOffset;

        cameraX = Mathf.Clamp(cameraX, bottomLeft.x + cameraHalfWidth, topRight.x - cameraHalfWidth);
        cameraY = Mathf.Clamp(cameraY, bottomLeft.y + cameraHalfHeight, topRight.y - cameraHalfHeight);
        mainCamera.transform.position = new Vector3(cameraX, cameraY, transform.position.z);
    }
}
