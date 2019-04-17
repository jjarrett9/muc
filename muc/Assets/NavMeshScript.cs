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
  public IDBHandler DbHandler = new DBHandlerForTesting();

  private Vector3 _objectLocation;
  private Vector3? _nextObject;
  private GameObject _destinationMark;
  private bool _pointFound;

  void Start()
  {
    _nextObject = DbHandler.GetNextObjectLocation();
    _destinationMark = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    if (_nextObject != null)
    {
      UpdateDestination();
    }
  }

  public void UpdateDestination()
  {
    if (_nextObject != null)
    {
      _objectLocation = (Vector3)_nextObject;
      _nextObject = DbHandler.GetNextObjectLocation();
      NavMeshHit hit;
      _pointFound = NavMesh.SamplePosition(_objectLocation, out hit, 3.0f, NavMesh.AllAreas);
      if (_pointFound)
      {
        Destination = hit.position;
      }

      MarkDestination();
    }
    else
    {
      LineRenderer.positionCount = 0;
      if (_destinationMark != null)
      {
        _destinationMark.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0); ;
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
    NavMeshSurface.BuildNavMesh();

    NavMeshPath path = new NavMeshPath();

    if (_pointFound)
    {
      NavMesh.CalculatePath(CameraTracker.transform.position, Destination, NavMesh.AllAreas, path);
    }

    if (path.corners.Length > 0)
    {
      Corners = (from corner in path.corners
                select new Vector3(corner.x, corner.y + 1f, corner.z)).ToArray();
      LineRenderer.positionCount = path.corners.Length;
      LineRenderer.SetPositions(path.corners);
    }
  }

  private void MarkDestination()
  {
    _destinationMark.transform.position = _objectLocation;
    _destinationMark.transform.localScale = new Vector3(.1f, .1f, .1f);
    _destinationMark.GetComponent<Renderer>().material.color = new Color(0, 1, 0, .3f);
  }
}