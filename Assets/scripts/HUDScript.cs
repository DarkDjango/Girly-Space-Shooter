using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {
	public int HudType;
	// 0 - Life System
	public int extraInfo;
	private Image image;
	private LifeSystemScript lifeSystem;
	private GameObject 	livePlayer;
	private PlayerScript player;
	public Sprite[] Bar = new Sprite[31];
	public int pos;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		lifeSystem = transform.parent.parent.gameObject.GetComponent<LifeSystemScript> ();

		#if UNITY_STANDALONE || UNITY_WEBPLAYER

			if(GameObject.FindWithTag("androidButton")){
				GameObject.FindWithTag("androidButton").SetActive(false);
			}

		#endif

	}

	// Update is called once per frame
	void Update () {
		if (HudType == 0) {
			if (lifeSystem.lifeNum >= extraInfo)
				image.enabled = true;
			else
				image.enabled = false;
		} else 	if (HudType == 1) {
			livePlayer = GameObject.FindGameObjectWithTag("Char");
			if (livePlayer != null){
				player = livePlayer.GetComponent<PlayerScript> ();
				if (player.shotLevel < 25) {
					image.sprite = Bar [0];
				}	else if ((player.shotLevel >=25)&&(player.shotLevel < 50)) {
					image.sprite = Bar [1];
				} 	else if ((player.shotLevel >=50)&&(player.shotLevel < 75)) {
					image.sprite = Bar [2];
				} 	else if ((player.shotLevel >=75)&&(player.shotLevel < 100)) {
					image.sprite = Bar [3];
				} 	else if ((player.shotLevel >=100)&&(player.shotLevel < 125)) {
					image.sprite = Bar [4];
				} 	else if ((player.shotLevel >=125)&&(player.shotLevel < 150)) {
					image.sprite = Bar [5];
				} 	else if ((player.shotLevel >=150)&&(player.shotLevel < 175)) {
					image.sprite = Bar [6];
				} 	else if ((player.shotLevel >=175)&&(player.shotLevel < 200)) {
					image.sprite = Bar [7];
				} 	else if ((player.shotLevel >=200)&&(player.shotLevel < 225)) {
					image.sprite = Bar [8];
				} 	else if ((player.shotLevel >=225)&&(player.shotLevel < 250)) {
					image.sprite = Bar [9];
				} 	else if ((player.shotLevel >=250)&&(player.shotLevel < 275)) {
					image.sprite = Bar [10];
				} 	else if ((player.shotLevel >=275)&&(player.shotLevel < 300)) {
					image.sprite = Bar [11];
				} 	else if (player.shotLevel >=300) {
					image.sprite = Bar [12];
				} 
			} 
		}  else if (HudType == 2) {
			livePlayer = GameObject.FindGameObjectWithTag("Char");
			if (livePlayer != null) {
				player = livePlayer.GetComponent<PlayerScript> ();
				pos = player.magic / 4;
				if (pos < 0)
					pos = 0;
				else if (pos > 30)
					pos = 30;
				image.sprite = Bar [pos];
			} 
		}
	}
}
