using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{


	[SerializeField]
	Transform target = null;
    [SerializeField]
    float leftLimit = -7.78f;
    [SerializeField]
    float rightLimit = 25f;
    [SerializeField]
    float topLimit = 7.5f;
    [SerializeField]
    float bottomLimit = -4.1f;



	// Use this for initialization
	void Start ()
	{
		//move the camera to scooby 	
		gameObject.transform.position = 
			new Vector3 (target.position.x, target.position.y,	transform.position.z);
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//every frame check to see if the camera is within the limits
		var pos = transform.position;
		pos.x = Mathf.Clamp (target.position.x, leftLimit, rightLimit);
		pos.y = Mathf.Clamp (target.position.y, bottomLimit, topLimit);
		gameObject.transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
	}
}


