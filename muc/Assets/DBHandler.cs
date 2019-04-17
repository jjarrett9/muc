using UnityEngine;

public class DBHandler : MonoBehaviour, IDBHandler
{
  public string ServerAddress { get; set; }
  public string DatabaseName { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }

  public string ConnectionString
  {
    get
    {
      return "Server=" + ServerAddress + ";Database=" + DatabaseName + ";User Id=" + Username + ";Password=" + Password + ";";
    }
  }

	// Use this for initialization
	void Start ()
	{
	  PopulateConnectionStringFields();
	}

	public Vector3? GetNextObjectLocation()
	{
	  const string queryString = "SELECT Location_X, Location_Y, Location_Z FROM Orders WHERE Fulfilled=False";
	  //using (var connection = new SqlConnection(ConnectionString))
	  //{
   //   var query = new SqlCommand(queryString, connection);
   //   connection.Open();
	  //  var reader = query.ExecuteReader();
	  //  if (!reader.Read()) return null;
	  //  var x = (int) reader[0];
	  //  var y = (int) reader[1];
	  //  var z = (int) reader[2];
	  //  return new Vector3(x, y, z);
	  //}

	  return null;
	}

  private void PopulateConnectionStringFields()
  {
    
  }

}