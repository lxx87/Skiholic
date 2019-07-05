using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private GameObject line;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider2d;
    [SerializeField] private GameObject linePrefab;
    private List<Vector3> originWorldPoints = new List<Vector3>();
    private List<Vector2> colliderPosints = new List<Vector2>();
    public float cameraZ = -10f;
    [SerializeField] private Managememt managememt;
    private List<GameObject> lines = new List<GameObject>();
    private bool begin = false;
    private float length = 0;
    private float currLength = 0;
    public float maxLength = 20;
    public float lineWidth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!managememt.isClick()&&!Application.isMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                drawBegin();
            }

            if (Input.GetMouseButton(0))
            {
                /*if(count>=4)
                {
                    for(float i=0.0f;i<=1.0;i+=0.2f)
                    {
                        float a1 = Mathf.Pow((1.0f - i), 3) / 6;
                        float a2 = (3 * Mathf.Pow(i, 3) - 6 * Mathf.Pow(i, 2) + 4) / 6;
                        float a3 = (-3 * Mathf.Pow(i, 3) + 3 * Mathf.Pow(i, 2) + 3 * i + 1) / 6;
                        float a4 = Mathf.Pow(i, 3) / 6;

                        Vector3 temp = originWorldPoints[count - 4] * a1 + originWorldPoints[count - 3] * a2 
                            + originWorldPoints[count - 2] * a3 + originWorldPoints[count - 1] * a4;
                        curvePoints.Add(temp);
                    }
                }*/
                drawMove(Input.mousePosition);

            }

            if (Input.GetMouseButtonUp(0)&&begin)
            {
                begin = false;
                drawEnd();
            }
        }

        if (Input.touchCount == 1&&!managememt.isClick())
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                drawBegin();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                //Debug.Log("touch move");
                drawMove(touch.position);
            }
            if (touch.phase == TouchPhase.Ended&&begin)
            {
                begin = false;
                drawEnd();
            }
        }
    }

    private void drawBegin()
    {
        line = Instantiate(linePrefab, linePrefab.transform.position, transform.rotation);
        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        edgeCollider2d = line.GetComponent<EdgeCollider2D>();
        originWorldPoints.Clear();
        lines.Add(line);
        begin = true;
        
    }

    private void drawMove(Vector3 position)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(position.x,position.y, 0 - cameraZ));
        originWorldPoints.Add(worldPosition);
        lineRenderer.positionCount = originWorldPoints.Count;
        lineRenderer.SetPositions(originWorldPoints.ToArray());
        colliderPosints.Add(worldPosition);
        edgeCollider2d.points = colliderPosints.ToArray();

        if (originWorldPoints.Count == 1)
            return;
        caculateLength(position, originWorldPoints[originWorldPoints.Count - 2]);
    }

    private void drawEnd()
    {
        lineRenderer.Simplify(0.04f);
        Vector3[] positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);
        float len = caculateLength(positions, lineRenderer.positionCount);
        length += len;
        if (len<0.1f)
        {
            clearLast();
            return;
        }
        if(length>maxLength)
        {
            clearLast();
            return;
        }
        Debug.Log("Line++: " + lines.Count+" "+len);
        currLength = 0;
        Vector2[] p = new Vector2[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            p[i] = positions[i];
        }
        edgeCollider2d.points = p;
    }

    private void caculateLength(Vector2 p1,Vector2 p2)
    {
        currLength += Vector2.Distance(p1, p2);
    }

    private float caculateLength(Vector3[]points,int count)
    {
        float temp = 0;
        for (int i = 1; i < count; i++)
        {
            temp += Vector2.Distance(points[i - 1], points[i]);
        }
        return temp;
    }
    /*private void OnGUI()
    {
        GUIStyle style = new GUIStyle
        {
            fontSize = 24,
        };
        string text = "辅助轨道长度: " + length+"m";
        Rect position = new Rect(5, Screen.height-30, 1, 1);
        GUI.Label(position, text.ToString(), style);
    }*/

    public float getLength()
    {
        float temp = length + currLength;
        if (temp < 0.1f)
            temp = 0;
        return temp;
    }

    public float getLeftLength()
    {
        float len = maxLength - length;
        if (len < 0.1f)
            len = 0;
        return len;
    }

    public void clearAll()
    {
        foreach(GameObject l in lines)
        {
            Destroy(l);
        }
        lines.Clear();
        length = 0;
    }

    public void clearLast()
    {
        if (lines.Count == 0)
            return;
        LineRenderer temp = lines[lines.Count - 1].GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[temp.positionCount];
        temp.GetPositions(points);
        length -= caculateLength(points, temp.positionCount);
        Destroy(lines[lines.Count - 1]);
        lines.RemoveAt(lines.Count - 1);
    }
}
