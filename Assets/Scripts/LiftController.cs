using UnityEngine;
using System.Collections;

public class LiftController : MonoBehaviour {

	[SerializeField]
	float vSpeed = 0;

	[SerializeField]
	float hSpeed = 0;

	[SerializeField]
	float top = -.7f;

	[SerializeField]
	float bottom = -2.5f;

	[SerializeField]
	float rightBoundary = 0f;

	[SerializeField]
	float leftBoundary = 0f;

	int vDirection = 1; //int direction where 0 is stay, 1 up, -1 down
	int hDirection = 1;

	void Update ()
	{
		if (transform.position.x >= rightBoundary)
			hDirection = -1;

		if (transform.position.x <= leftBoundary)
			hDirection = 1;

		if (transform.position.y >= top)
			vDirection = -1;

		if (transform.position.y <= bottom)
			vDirection = 1;


		transform.Translate(hSpeed * hDirection * Time.deltaTime, vSpeed * vDirection * Time.deltaTime, 0);
	}
}
