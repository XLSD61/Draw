using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            points.Clear();
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (DistanceToLastPoint(hitInfo.point) > 1f)
                {
                    points.Add(hitInfo.point);
                    _lineRenderer.positionCount = points.Count;
                    _lineRenderer.SetPositions(points.ToArray());
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnNewPathCreated(points);
        }
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
        {
            return Mathf.Infinity;
        }
        return Vector3.Distance(points.Last(), point);
    }
}
