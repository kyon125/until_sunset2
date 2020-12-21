using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public static Vector2 startPos;
    public Vector2 endPos;
    public List<Vector2> linePositions;

    public Camera camera;

    public GameObject an;

    public static bool hasHit;

    bool lineActive = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        drawLine();
    }

    void drawLine()
    {
        if (lineActive == true && Input.GetMouseButtonDown(0))
        {
            Destroy(GameObject.Find("Collider"));
            lineRenderer.SetPosition(0, new Vector2(0, 0));
            lineRenderer.SetPosition(1, new Vector2(0, 0));
            lineActive = false;
        }

        if (Bow.bowset.status == Bow.bowstatus.bridge && GameStatus.gameStatus.status == GameStatus.Status.onBowing)
        {
            if (hasHit == true && lineActive == false)
            {
                endPos = an.transform.position;
                float dis = (startPos - endPos).sqrMagnitude;

                if (dis > 0 && dis < 950)
                {
                    linePositions.Add(new Vector2(startPos.x, startPos.y));
                    linePositions.Add(new Vector2(endPos.x, endPos.y));
                    lineRenderer.SetPosition(0, linePositions[0]);
                    lineRenderer.SetPosition(1, linePositions[1]);
                    addColliderToLine();
                    linePositions.Clear();

                    lineActive = true;
                    hasHit = false;
                }
            }

            if (lineActive == true && Input.GetMouseButtonDown(0))
            {
                Destroy(GameObject.Find("Collider"));
                lineRenderer.SetPosition(0, new Vector2(0, 0));
                lineRenderer.SetPosition(1, new Vector2(0, 0));
                lineActive = false;
            }
        }
        else if (Bow.bowset.status == Bow.bowstatus.normal && GameStatus.gameStatus.status == GameStatus.Status.onBowing)
        {
            
        }
    }

    private void addColliderToLine()
    {
        BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D>();
        col.gameObject.layer = 9;
        col.transform.parent = lineRenderer.transform;
        float lineLength = Vector3.Distance(startPos, endPos);
        col.size = new Vector3(lineLength, 0.1f, 1f);
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint;

        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        col.transform.Rotate(0, 0, angle);
    }
}