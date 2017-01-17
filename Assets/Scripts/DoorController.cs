using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	[SerializeField]
	float closed = 7.5f;

	[SerializeField]
	float open = 9f;

	public bool isKeyFound;

	private Animator _animator = null;

	void Start(){
		isKeyFound = false;
		_animator = gameObject.GetComponent<Animator> ();
		_animator.SetBool ("isOpen", false);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(ScoobyDoo.Instance.HasKey == true && ScoobyDoo.Instance.Treasure == 100){
			_animator.SetBool ("isOpen", true);
		}
	}


}
