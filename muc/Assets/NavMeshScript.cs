using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
  public NavMeshSurface NavMeshSurface;
  public GameObject CameraTracker;
  public LineRenderer LineRenderer;
  public Vector3 destination;
  public Vector3[] corners;
  public bool pointFound;

  void Start()
  {
    NavMeshHit hit;
    pointFound = NavMesh.SamplePosition(new Vector3(1, 1, 1), out hit, 3.0f, NavMesh.AllAreas);
    if (pointFound)
    {
      destination = hit.position;
    }
  }

  // Update is called once per frame
  void Update()
  {
    NavMeshSurface.BuildNavMesh();
    if (!pointFound)
    {
      NavMeshHit hit;
      pointFound = NavMesh.SamplePosition(new Vector3(1, 1, 1), out hit, 3.0f, NavMesh.AllAreas);

      destination = hit.position;
    }

    NavMeshPath path = new NavMeshPath();

    if (pointFound)
    {
      NavMesh.CalculatePath(CameraTracker.transform.position, destination, NavMesh.AllAreas, path);
    }

    if (path.corners.Length > 0)
    {
      corners = path.corners;
      LineRenderer.positionCount = path.corners.Length;
      LineRenderer.SetPositions(path.corners);
    }
  }
}