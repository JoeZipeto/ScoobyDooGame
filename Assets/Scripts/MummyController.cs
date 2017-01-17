using UnityEngine;
using System.Collections;

public class MummyController : MonoBehaviour {

	[SerializeField]
	private LayerMask enemyMask;
	[SerializeField]
	private float speed = 1f;

	private Rigidbody2D _body = null;
	private	Transform _transform = null;
	private float _width, _height;

	// Use this for initialization
	void Start () {
		_body = gameObject.GetComponent<Rigidbody2D> ();
		_transform = this.transform;
		SpriteRenderer sprite = this.GetComponent<SpriteRenderer> ();
		_width = sprite.bounds.extents.x;
		_height = sprite.bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 lineCastPos = (Vector2)_transform.position - (Vector2)_transform.right * _width;// - Vector2.up * _height;
		Debug.DrawLine (lineCastPos, lineCastPos + Vector2.down/2);

		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down/2, enemyMask);
		Debug.Log (isGrounded);
		if (!isGrounded) {
			//gameObject.transform.RotateAround (lineCastPos-new Vector2(_width,0), Vector2.up, 180);
			Vector3 currRot = _transform.eulerAngles;
			currRot.y += 180;
			_transform.eulerAngles = currRot; 
		}

		Vector2 _velocity = _body.velocity;
		_velocity.x = -_transform.right.x * speed;
		_body.velocity = _velocity;
	}
}
