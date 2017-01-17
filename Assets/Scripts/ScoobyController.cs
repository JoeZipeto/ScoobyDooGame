using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoobyController : MonoBehaviour {

	[SerializeField]
	private float force = 1f;

	[SerializeField]
	private float jumpforce = 30f;

	[SerializeField]
	private  float scaleX = 2;

	private Rigidbody2D _rigidBody = null;
	private Animator _animator = null;
	private string direction = "Right";


	// Use this for initialization
	void Start () {
		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
		_animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float jump = Input.GetAxis ("Jump");
	
		//get controls	
        float fx = Input.GetAxis("Horizontal");
        float fy = Input.GetAxis("Vertical");

        if ( !IsGrounded()) {
            fy = 0;
            fx = 0;
		}

        Vector2 forceVector = new Vector2(fx*force, fy*jumpforce);
	 //   Debug.Log("velocity:" + _rigidBody.velocity.x);

		//extra keys to control game
        if (Input.GetKeyDown(KeyCode.R))
        {
        	SceneManager.LoadScene("LevelOne");
		}

		if (Input.GetKeyDown(KeyCode.T))
		{
			SceneManager.LoadScene("LevelTwo");
		}

		//flip directions
		if (fx < 0) {
			if (transform.eulerAngles.y != 180 && direction == "Right") {
				transform.Rotate (0, 180, 0);
				direction = "Left";
			}
		}

		if (fx > 0) {
			if (transform.eulerAngles.y != 0 && direction == "Left") {
				transform.Rotate (0, 180, 0);
				direction = "Right";
			}
		}

		/* possble code
		if (_rigidBody.velocity.x < 0) {

			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		} else {
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		}*/
		if (IsGrounded()) {
			_animator.SetInteger ("Speed", (int)Mathf.Abs (_rigidBody.velocity.x) * 100000);
			_rigidBody.AddForce (forceVector * force);
		}

		//set the parameters to default
		_animator.SetBool ("isGrounded", IsGrounded ());      
    }

	private bool IsGrounded(){
		//check to see if scooby is grounded
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();

		RaycastHit2D res = Physics2D.Linecast(
			new Vector2 (gameObject.transform.position.x,
				gameObject.transform.position.y )
			,
			new Vector2(gameObject.transform.position.x,
				gameObject.transform.position.y-(sr.bounds.size.y  / 2) ));

		Debug.DrawLine (
            new Vector2 (gameObject.transform.position.x,
			    gameObject.transform.position.y ),
			new Vector2 (gameObject.transform.position.x,
				gameObject.transform.position.y - (sr.bounds.size.y  / 2)));
        Debug.Log(gameObject.transform.localScale.y);
	//  testing purposes only
	//	if(res!=null && res.collider!=null)	
	//	Debug.Log (res.collider.gameObject.name);

		return res.collider != null;
	}
}
