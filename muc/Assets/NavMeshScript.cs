using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
  public NavMeshSurface NavMeshSurface;
  public GameObject CameraTracker;
  public LineRenderer LineRenderer;
  public Vector3 Destination;
  public Vector3[] Corners;

  private Vector3 _objectLocation = new Vector3(1, 1, 1);
  private Vector3 _nextObject;
  private GameObject _destinationMark;
  private bool _pointFound;

  void Start()
  {
    NavMeshHit hit;
    _pointFound = NavMesh.SamplePosition(_objectLocation, out hit, 3.0f, NavMesh.AllAreas);
    if (_pointFound)
    {
      Destination = hit.position;
    }
    MarkDestination();
  }

  // Update is called once per frame
  void Update()
  {
    NavMeshSurface.BuildNavMesh();
    if (!_pointFound)
    {
      NavMeshHit hit;
      _pointFound = NavMesh.SamplePosition(new Vector3(1, 1, 1), out hit, 3.0f, NavMesh.AllAreas);

      Destination = hit.position;
    }

    NavMeshPath path = new NavMeshPath();

    if (_pointFound)
    {
      NavMesh.CalculatePath(CameraTracker.transform.position, Destination, NavMesh.AllAreas, path);
    }

    if (path.corners.Length > 0)
    {
      Corners = (from corner in path.corners
                select new Vector3(corner.x, corner.y + .5f, corner.z)).ToArray();
      LineRenderer.positionCount = path.corners.Length;
      LineRenderer.SetPositions(path.corners);
    }
  }

  private void MarkDestination()
  {
    _destinationMark = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    _destinationMark.transform.position = _objectLocation;
    _destinationMark.transform.localScale = new Vector3(.1f, .1f, .1f);
    _destinationMark.GetComponent<Renderer>().material.color = new Color(0, 1, 0, .3f);
  }
}