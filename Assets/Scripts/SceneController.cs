using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	private float startTime;

	// Use this for initialization
	void Start () {
		
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {

		float _time = Time.time - startTime;
		if(_time >= 3 && SceneManager.GetActiveScene().name == "TitlePage")
			SceneManager.LoadScene (1);
	
	}

	public void startGame(){
		if(SceneManager.GetActiveScene().name == "StartLevelOne")
			SceneManager.LoadScene ("LevelOne");
		if(SceneManager.GetActiveScene().name == "StartLevelTwo")
			SceneManager.LoadScene ("LevelTwo");
		if(SceneManager.GetActiveScene().name == "RestartLevelOne")
			SceneManager.LoadScene ("LevelOne");
		if(SceneManager.GetActiveScene().name == "RestartLevelTwo")
			SceneManager.LoadScene ("LevelTwo");
	}
}
