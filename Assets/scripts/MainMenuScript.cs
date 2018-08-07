using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public int Lives = 2;
	public bool Powers = true;
	public bool ShotLevel = true;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
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
	// Update is called once per frame
	void Update () {
		
	}
}
