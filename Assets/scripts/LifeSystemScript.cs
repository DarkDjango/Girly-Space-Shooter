using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystemScript : MonoBehaviour {
	public Transform playerPrefab;
	private GameObject livePlayer;
	private Vector3 pos;
	public int lifeNum;
	private int shotLevel;
	private int shotElement;
	private PlayerScript player;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		livePlayer = GameObject.FindGameObjectWithTag("Char");
		if (livePlayer != null){
			player = livePlayer.GetComponent<PlayerScript> ();
			pos = livePlayer.transform.position;
			shotLevel = player.shotLevel;
			shotElement = player.shotElement;
		}
		else if (lifeNum > 0) {
			shotLevel -= 50;
			var playerTransform = Instantiate (playerPrefab) as Transform;
			playerTransform.position = pos;
			livePlayer = GameObject.FindGameObjectWithTag("Char");
			player = livePlayer.GetComponent<PlayerScript>();
			player.shotLevel = shotLevel;
			player.shotElement = shotElement;
			lifeNum--;
		} else {
			print ("Game Over");
		}
	}
}
