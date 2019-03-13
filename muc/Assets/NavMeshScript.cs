using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{

    public NavMeshSurface NavMeshSurface;
    public GameObject CameraTracker;
    public LineRenderer LineRenderer;
    private NavMeshAgent _agent;
    Vector3 destination = new Vector3(1, 1, 1);
    public bool destinationSet = false;

    void Start()
    {
        _agent = CameraTracker.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
	void Update () {
		NavMeshSurface.BuildNavMesh();
	    try
	    {
	        destinationSet = _agent.SetDestination(destination);
	    }
	    catch
	    {

	    }
	    if (_agent.hasPath)
	    {
            LineRenderer.SetPositions(_agent.path.corners);
	    }
	}
}
