using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystemScript : MonoBehaviour {
	public Transform playerPrefab;
	private GameObject livePlayer;
	private GameObject gameOver;
	private Vector3 pos;
	public int lifeNum;
	private int shotLevel;
	private int shotElement;
	private bool shoot;	
	SpriteRenderer sprite;
	public float fixedTimer = 10f;
	private float timer = 0.015f;
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
			shoot = player.shoot;
		}
		else if (lifeNum > 0) {
			shotLevel -= 50;
			var playerTransform = Instantiate (playerPrefab) as Transform;
			playerTransform.position = pos;
			livePlayer = GameObject.FindGameObjectWithTag("Char");
			player = livePlayer.GetComponent<PlayerScript>();
			player.shotLevel = shotLevel;
			player.shotElement = shotElement;
			player.shoot = shoot;
			lifeNum--;
		} else {
			GameOver ();
		}
	}
	void GameOver () {
		sprite = GameObject.FindGameObjectWithTag ("GameOver").GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			while (sprite.color != Color.black) {
				timer = fixedTimer;
				sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + 0.05f);
				while (timer > 0) {
					timer -= Time.deltaTime;
				}
			}
		}
	}
}
