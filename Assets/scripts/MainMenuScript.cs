using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public int Lives = 2;
	int nextStage;
	public bool Powers = true;
	private Scene mainMenuScene;
	private GameObject eventSystem;
	public bool ShotLevel = true;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		mainMenuScene = SceneManager.GetActiveScene ();
	}

	public void PowersCheck () {
		Powers = !Powers;
	}

	public void ShotLevelCheck () {
		ShotLevel = !ShotLevel;
	}
	public void IncreaseLives () {
		if (Lives < 5)
			Lives++;
	}

	public void DecreaseLives () {
		if (Lives > 0)
			Lives--;
	}
	public void StartButton () {
		nextStage = Random.Range (1, 4);
		if (nextStage == 1)
			SceneManager.LoadScene("Stage1");
		else if (nextStage == 2)
			SceneManager.LoadScene("Stage2");	
		else if (nextStage == 3)
			SceneManager.LoadScene("Stage3");	
	}
	// Update is called once per frame
	void Update () {
		Scene currentScene = SceneManager.GetActiveScene ();
		if (currentScene != mainMenuScene) {
			eventSystem = GameObject.FindGameObjectWithTag("LifeControl");
			LifeSystemScript lifeSystem = eventSystem.GetComponent<LifeSystemScript> ();
			if (lifeSystem != null) {
				lifeSystem.lifeNum = Lives + 1;
			}
			Destroy (gameObject);
		}
	}
}
