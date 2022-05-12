using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private Queue<Vector3> pathPoints = new Queue<Vector3>();
    private void Awake()
    {
        FindObjectOfType<DrawPath>().OnNewPathCreated += SetPoints;
    }

    private void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }
    private void Update()
    {
        UpdatePathing();
    }

    private void UpdatePathing()
    {
        if (ShouldSetDestination())
        {
            _navMeshAgent.SetDestination(pathPoints.Dequeue());
        }
    }

    private bool ShouldSetDestination()
    {
        if (pathPoints.Count == 0)
        {
            return false;
        }

        if (_navMeshAgent.hasPath == false || _navMeshAgent.remainingDistance <.5f)
        {
            return true;
        }
        return false;
    }
}
