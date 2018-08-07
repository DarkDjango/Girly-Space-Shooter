using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLivesScript : MonoBehaviour {

	private GameObject config;
	private Image image;
	MainMenuScript configScript;
	public int LiveNum = 0;
	// Use this for initialization
	void Start () {
		config = GameObject.FindGameObjectWithTag("Config");
		configScript = config.GetComponent<MainMenuScript> ();
		image = this.gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (configScript.Lives >= LiveNum) {
			image.enabled = true;
		} else
			image.enabled = false;
	}
}
