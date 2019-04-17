using UnityEngine;

public class DBHandlerForTesting : IDBHandler
{
  private readonly Vector3[] _objects =
  {
    new Vector3(1, 1, 1),
    new Vector3(1, 1, 2),
    new Vector3(1, 1, 3), 
  };

  private int _index;

  public Vector3? GetNextObjectLocation()
  {
    if (_index < _objects.Length)
    {
      return _objects[_index++];
    }
    return null;
  }
}