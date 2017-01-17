using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour {

	[SerializeField]
	float speed = 1;

	int direction = 1; //int direction where 0 is stay, 1 up, -1 down
	[SerializeField]
	float top = 0;
	[SerializeField]
	float bottom = 0;




	void Update ()
	{
		if (transform.position.y >= top)
			direction = -1;

		if (transform.position.y <= bottom)
			direction = 1;


		transform.Translate(0, speed * direction * Time.deltaTime, 0);
	//	Debug.Log (speed * direction * Time.deltaTime);
	}
}

