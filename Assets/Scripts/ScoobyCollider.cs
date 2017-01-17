using UnityEngine;
using System.Collections;

public class ScoobyCollider : MonoBehaviour
{

	static public HUDController hud = null;
	public DoorController dc = null;
	private Animator _animator = null;

	AudioSource audio;
	public AudioClip crateExplosion;
	public AudioClip scoobyLaugh;
	public AudioClip scoobySnack;
	public AudioClip scoobyScared;
	public AudioClip scoobyDoobieDo;



	[SerializeField]
	GameObject explosion = null;

	public void Start ()
	{
		audio = gameObject.GetComponent<AudioSource> ();
		_animator = gameObject.GetComponent<Animator> ();
        dc = gameObject.GetComponent<DoorController>();
	}
	void OnCollisionEnter2D (Collision2D other)
	{ 
		if (other.gameObject.tag == "Crate") {

			//Play explosion animation
			if (other != null) {
				GameObject gm = Instantiate (explosion);

				//Play audio here
				PlayAudio (crateExplosion, audio);
				gm.transform.position = other.transform.position;
				Destroy (other.gameObject);
			}
		}
			
		//Scooby Collides with ghost
		if (other.gameObject.tag == "Ghost") {
			ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear + 20;

			//Play audio here
			PlayAudio (scoobyScared, audio);

			hud.updateFear ();
			Debug.Log ("Ghost Collision Detected");
		}


		//Scooby Collides with Mummy
		if (other.gameObject.tag == "Mummy") {
			ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear + 20;

			//Play audio here
			PlayAudio (scoobyScared, audio);

			hud.updateFear ();
			Debug.Log ("Mummy Collision Detected");
		}

		//Scooby Collides with Spider
		if (other.gameObject.tag == "Spider") {
			ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear + 5;
			hud.updateFear ();

			//Play audio here
			PlayAudio (scoobyScared, audio);

			Debug.Log ("Spider Collision Detected");
		}

        //Scooby Collides with Spikes
        if (other.gameObject.tag == "Spikes")
        {
            ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear + 100;
            hud.updateFear();

            //Play audio here
            PlayAudio(scoobyScared, audio);

            Debug.Log("Spike Collision Detected");
        }

        if (other.gameObject.tag == "Bones") {
			ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear + 100;
			hud.updateFear ();

			//Play audio here
			PlayAudio (scoobyScared, audio);

			Debug.Log ("Bones Collision Detected");
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{

        //Scooby Collides with key
        if (other.gameObject.tag == "Key")
        {
            ScoobyDoo.Instance.HasKey = ScoobyDoo.Instance.HasKey;
            hud.updateKey();
           // dc = gameObject.GetComponent<DoorController>();
           // dc.isKeyFound = true;
            

            //Play audio here
            PlayAudio(scoobyLaugh, audio);

            //Destroy GameObject
            Destroy(other.gameObject);
        }
        


        //Scooby Collides with red gem
        if (other.gameObject.tag == "Red Gem") {

			//Add Points to treasure
			ScoobyDoo.Instance.Treasure = ScoobyDoo.Instance.Treasure + 4;
			hud.updateGems ();

			//Play audio here
			PlayAudio (scoobyLaugh, audio);

			Debug.Log ("Red Gem Collision Detected");

			//Destroy GameObject
			Destroy (other.gameObject);
		}

		//Scooby Collides with blue gem
		if (other.gameObject.tag == "Blue Gem") {

			//Add Points to treasure
			ScoobyDoo.Instance.Treasure = ScoobyDoo.Instance.Treasure + 4;
			hud.updateGems ();
			Debug.Log ("Blue Gem Collision Detected");

			//Play audio here
			PlayAudio (scoobyLaugh, audio);

			//Destroy GameObject
			Destroy (other.gameObject);
		}

		//Scooby Collides with Treasure
		if (other.gameObject.tag == "Treasure") {

			//Add Points to treasure
			ScoobyDoo.Instance.Treasure = ScoobyDoo.Instance.Treasure + 20;
			hud.updateTreasures ();
			Debug.Log ("Treausre Collision Detected");

			//Play audio here
			PlayAudio (scoobyLaugh, audio);

			//Destroy GameObject
			Destroy (other.gameObject);
		}

		//Scooby collides with food
		if (other.gameObject.tag == "Food") {

			//Add Points to fear
			ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear - 10;
			hud.updateFear ();

			//Run animation and Destory food
			_animator.SetBool ("isEating", true);

			//Play audio here
			PlayAudio (scoobySnack, audio);

			Destroy (other.gameObject);


			Debug.Log ("Food Collision Detected");
		}



        //change animator back to idle
        if (_animator != null)
            _animator.SetBool("isEating", false);
        else
            Debug.Log("no animator found for Scooby");	

//If scooby touch enter_to_pyramid_hook*********************************************************************************
// he will be transformed to the position x = 9.336, y = 6.8 which is inside the pyramid
        if(other.gameObject.tag == "EntranceHook")
        {
            _animator.SetBool("isCommingIn", true);
            
        }

	}

    public void stopGoingIn() {
        var pos = transform.position;
        pos.x = 9.6f;
        pos.y = 6.9f;
        Vector2 newPosition = new Vector2(pos.x, pos.y);
        gameObject.transform.position = newPosition;
        _animator.SetBool("isCommingIn", false);
    }

	private void PlayAudio (AudioClip audio, AudioSource asrc)
	{
		//Play Audio based on parameters
		if (asrc != null) {
			asrc.clip = audio;
			asrc.Play ();
		}
	}
}
