using System.Collections.Generic;
 using UnityEngine;
 
 [RequireComponent(typeof(LineRenderer))]
public class BrushController : MonoBehaviour
{
    List<Vector2> linePoints = new List<Vector2>();
    LineRenderer lineRenderer;
    public float startWidth = 0.2f;
    public float endWidth = 0.2f;
    public float threshold = 0.001f;
    Camera thisCamera;
    int lineCount = 0;

    Vector2 lastPos = Vector2.one * float.MaxValue;


    void Awake()
    {
         
        thisCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButton("paint"))
        {
            Vector2 mousePos = Input.mousePosition;
            //mousePos.z = thisCamera.nearClipPlane;
            Vector2 mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);

            float dist = Vector3.Distance(lastPos, mouseWorld);
            if (dist <= threshold)
                return;

            lastPos = mouseWorld;
            if (linePoints == null)
                linePoints = new List<Vector2>();
            linePoints.Add(mouseWorld);
        }
        else if (Input.GetButtonUp("paint"))
        {
            linePoints.Clear();
        }
        UpdateLine();
    }


    void UpdateLine()
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.positionCount = linePoints.Count;

        for (int i = lineCount; i < linePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i]);
        }
        lineCount = linePoints.Count;
    }
}