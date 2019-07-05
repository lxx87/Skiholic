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

    public float hardMaxSize;
    public float softMaxSize;
    public float hardMinSize;
    public float softMinSize;

    public float softZommSpeed = 0.1f;
    public float zoomSpeed = 3f;
    public float moveSpeed = 0.5f;

    private Vector2[] lastPositions = new Vector2[2];//上一帧两个手指的位置

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
        /*input for pc*/
        if (Input.GetKey(KeyCode.A))
            move(0 - xOffset, 0);
        if (Input.GetKey(KeyCode.D))
            move(xOffset, 0);
        if (Input.GetKey(KeyCode.S))
            move(0, 0 - yOffset);
        if (Input.GetKey(KeyCode.W))
            move(0, yOffset);

        float zoomDelta;
        zoomDelta = Input.GetAxis("Mouse ScrollWheel");
        if (zoomDelta != 0)
        {
            zoom(Time.deltaTime * (0 - zoomDelta) * zoomSpeed);
            return;
        }
        /*if (mainCamera.orthographicSize > softMaxSize)
            zoom(0 - Time.deltaTime * softZommSpeed);

        if (mainCamera.orthographicSize < softMinSize)
            zoom(Time.deltaTime * softZommSpeed);*/

        /*input for android*/
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 movedDelta = Input.touches[0].deltaPosition;
                float currSpeed = moveSpeed * mainCamera.orthographicSize * 0.2f;//平衡不同镜头大小情况下镜头移动的速度，避免镜头较小时镜头移动过快
                move(0 - movedDelta.x * Time.deltaTime * currSpeed, 0 - movedDelta.y * Time.deltaTime * currSpeed);
                //move(0-touch.deltaPosition.x * Time.deltaTime * 0.5f, 0-touch.deltaPosition.y * Time.deltaTime * 0.5f);
            }
        }

        if (Input.touchCount > 1)
        {
            if (Input.touches[0].phase == TouchPhase.Moved
                && Input.touches[1].phase == TouchPhase.Moved
                && isMove(Input.touches[0].deltaPosition, Input.touches[1].deltaPosition))//双指同向移动，移动镜头
            {
                /*Vector2 movedDelta = Vector2.Max(Input.touches[0].deltaPosition, Input.touches[1].deltaPosition);
                float currSpeed = moveSpeed * mainCamera.orthographicSize * 0.2f;//平衡不同镜头大小情况下镜头移动的速度，避免镜头较小时镜头移动过快
                move(0 - movedDelta.x * Time.deltaTime * currSpeed, 0 - movedDelta.y * Time.deltaTime * currSpeed);*/
            }
            else
            {
                
                if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)//双指反向移动，缩放镜头
                {
                    Vector2 currPosition1 = Input.touches[0].position;
                    Vector2 currPosition2 = Input.touches[1].position;
                    if (!Enlarge(lastPositions[0], lastPositions[1], currPosition1, currPosition2))
                    {
                        zoom(zoomSpeed * Time.deltaTime * (Input.touches[0].deltaPosition.magnitude +
                            Input.touches[1].deltaPosition.magnitude));
                    }
                    else
                    {
                        zoom(zoomSpeed * (0 - Time.deltaTime * (Input.touches[0].deltaPosition.magnitude +
                            Input.touches[1].deltaPosition.magnitude)));
                    }
                }
            }
            lastPositions[0] = Input.touches[0].position;
            lastPositions[1] = Input.touches[1].position;
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

    private void zoom(float delta)
    {
        float size = mainCamera.orthographicSize + delta;
        size = Mathf.Clamp(size, hardMinSize, hardMaxSize);
        mainCamera.orthographicSize = size;

        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * ((float)Screen.width / (float)Screen.height);
        float cameraX = transform.position.x;
        float cameraY = transform.position.y;

        cameraX = Mathf.Clamp(cameraX, bottomLeft.x + cameraHalfWidth, topRight.x - cameraHalfWidth);
        cameraY = Mathf.Clamp(cameraY, bottomLeft.y + cameraHalfHeight, topRight.y - cameraHalfHeight);
        mainCamera.transform.position = new Vector3(cameraX, cameraY, transform.position.z);

    }

    private bool isMove(Vector2 deltaPositin1, Vector2 deltaPosition2)
    {
        return Vector2.Dot(deltaPositin1, deltaPosition2) /
            (deltaPositin1.magnitude + deltaPosition2.magnitude) > 0.865f;
    }

    private bool Enlarge(Vector2 lastPosition1, Vector2 lastPosition2,
        Vector2 currPosition1, Vector2 currPosition2)
    {
        return Vector2.Distance(lastPosition1, lastPosition2) < Vector2.Distance(currPosition1, currPosition2);
    }
}
