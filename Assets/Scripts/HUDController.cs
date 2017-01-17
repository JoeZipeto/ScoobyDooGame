using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour {

	[SerializeField]
	Text fearLabel = null;

	[SerializeField]
	Text lootsLabel = null;

	[SerializeField]
	Text timeLabel = null;

    [SerializeField]
    Image keyLabel = null;

	private float startTime;
	string minutes, seconds;
	int counter = 1;

	public void updateFear(){
		fearLabel.text = "Fear: " + ScoobyDoo.Instance.Fear + "%";
		if (ScoobyDoo.Instance.Fear >= 100) {
			gameOver ();
		}
	}

	public void updateTreasures(){
		lootsLabel.text = "Gems: " + ScoobyDoo.Instance.Treasure + "%";
	}

	public void updateGems(){
		lootsLabel.text = "Gems: " + ScoobyDoo.Instance.Treasure + "%";
	}

    public void updateKey()
    {
        //show key
        keyLabel.enabled = true;
    }

    public void updateTime(string minutes, string seconds){
        if (minutes.Equals("0"))
        {
            if(timeLabel!=null)
                timeLabel.text = "Time " + seconds;
            else
                Debug.Log("timeLabel not set");
        }
        else
        {
            if (timeLabel != null)
                timeLabel.text = "Time " + minutes + ":" + seconds;
            else
                Debug.Log("timeLabel not set");
        }
    }

	public void gameOver(){
		ScoobyDoo.Instance.Fear = 0;
		ScoobyDoo.Instance.Treasure = 0;
		ScoobyDoo.Instance.Time = 0;
		if(SceneManager.GetActiveScene().name == "LevelOne")
			SceneManager.LoadScene ("RestartLevelOne");
		if(SceneManager.GetActiveScene().name == "LevelTwo")
			SceneManager.LoadScene ("RestartLevelTwo");
	
	}

	public void restartGame(){
		SceneManager.LoadScene (0);
	}
		

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		ScoobyCollider.hud = this;
	}

	// Update is called once per frame
	void Update () {
		float _time = Time.time - startTime;

		minutes = ((int)_time / 60).ToString ();
		seconds = (_time % 60).ToString ("f1");
		if ( _time % 60 >= (10 * counter) && _time % 60 < ((10 * counter) + 0.03)) {
			counter++;
			if (counter > 5)
				counter = 0;
			ScoobyDoo.Instance.Fear = ScoobyDoo.Instance.Fear + 5;
			updateFear ();

		}
		updateTime (minutes, seconds);

	}
}
