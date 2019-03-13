using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject MainCamera;

	// Use this for initialization
	void Start ()
	{
	    Transform cameraTransform = MainCamera.transform;
	    Vector3 groundedCameraPosition = cameraTransform.position;
	    groundedCameraPosition.y = 1;
	    Quaternion groundedCameraRotation = cameraTransform.rotation;
        transform.SetPositionAndRotation(groundedCameraPosition, groundedCameraRotation);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Transform cameraTransform = MainCamera.transform;
	    Vector3 groundedCameraPosition = cameraTransform.position;
	    groundedCameraPosition.y = 1;
        Quaternion groundedCameraRotation = cameraTransform.rotation;
	    transform.SetPositionAndRotation(groundedCameraPosition, groundedCameraRotation);
    }
}
