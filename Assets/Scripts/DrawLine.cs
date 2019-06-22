using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    private GameObject clone;
    private int count;
    public GameObject target;
    private List<Vector2> points = new List<Vector2>();
    private List<Vector3> curvePoints = new List<Vector3>();



    private GameObject line;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider2d;
    [SerializeField] private GameObject linePrefab;
    private List<Vector3> originWorldPoints = new List<Vector3>();
    private List<Vector2> colliderPosints = new List<Vector2>();
    public float cameraZ = -10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clone = (GameObject)Instantiate(target, target.transform.position, transform.rotation);
            lineRenderer = clone.GetComponent<LineRenderer>();
            edgeCollider2d = clone.GetComponent<EdgeCollider2D>();
            count = 0;
            points.Clear();
            originWorldPoints.Clear();
            curvePoints.Clear();
        }
        if (Input.GetMouseButton(0))
        {
            count++;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            originWorldPoints.Add(worldPoint);
            curvePoints.Add(worldPoint);
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

            lineRenderer.positionCount = curvePoints.Count;
            //lineRenderer.SetPosition(index - 1, worldPoint);//设置顶点位置
            lineRenderer.SetPositions(curvePoints.ToArray());
            //points.Add(new Vector2(worldPoint.x, worldPoint.y));

            for (int i = points.Count; i < curvePoints.Count; i++)
            {
                points.Add(new Vector2(curvePoints[i].x, curvePoints[i].y));
            }

            edgeCollider2d.points = points.ToArray();
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                line = Instantiate(linePrefab, linePrefab.transform.position, transform.rotation);
                lineRenderer = line.GetComponent<LineRenderer>();
                edgeCollider2d = line.GetComponent<EdgeCollider2D>();
                originWorldPoints.Clear();
                Debug.Log("Line++");
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, 0 - cameraZ));
                originWorldPoints.Add(worldPosition);
                lineRenderer.SetPositions(originWorldPoints.ToArray());
                colliderPosints.Add(worldPosition);
                edgeCollider2d.points = colliderPosints.ToArray();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                lineRenderer.Simplify(0.04f);
                Vector3[] positions = new Vector3[lineRenderer.positionCount];
                lineRenderer.GetPositions(positions);
                Vector2[] p = new Vector2[positions.Length];
                for (int i = 0; i < positions.Length; i++)
                {
                    p[i] = positions[i];
                }
                edgeCollider2d.points = p;
            }
        }
    }


}
