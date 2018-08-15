using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LifeSystemScript : MonoBehaviour {
	public Transform playerPrefab;
	private string nextScene;
	private GameObject livePlayer;
	private GameObject gameOver;
	public bool stageClear = false;
	private Vector3 pos = new Vector3(0, 0, 0);
	public int lifeNum;
	private int shotLevel;
	private int shotElement;
	private int SetElement1;
	private int SetElement2;
	private int nextStage;
	private bool shoot;	
	SpriteRenderer sprite, sprite2;
	public float fixedTimer = 0.015f;
	private float finalTimer = 1f;
	private float timer = 1f;
	private float stageClearTimer = 6f;
	private PlayerScript player;
	// Use this for initialization

	void Start () {
		do {
			nextStage = Random.Range (1, 4);
			if (nextStage == 1)
				nextScene = "Stage1";
			else if (nextStage == 2)
				nextScene = "Stage2";
			else if (nextStage == 3)
				nextScene = "Stage3";
		} while (nextScene == SceneManager.GetActiveScene ().name);
		livePlayer = GameObject.FindGameObjectWithTag("Char");
		if (livePlayer != null) {
			player = livePlayer.GetComponent<PlayerScript> ();
			lifeNum = player.currentLives;
		} else {
			SetElement2 = 0;
			SetElement1 = 0;
			shotLevel = 0;
			shotElement = 0;
			shoot = true;
		}
	}
	// Update is called once per frame
	void Update () {
		livePlayer = GameObject.FindGameObjectWithTag("Char");
		if (livePlayer != null) {
			if ((stageClear) && (player.GotNewPower==0)) {
				if (stageClearTimer < 0) {
					sprite = GameObject.FindGameObjectWithTag ("StageClearText").GetComponent<SpriteRenderer> ();
					if (sprite != null) {
						if (sprite.color != Color.white) {
							if (timer <= 0) {
								sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + 0.05f);
								timer = fixedTimer;
							} else {
								timer -= Time.deltaTime;
							}
						} else {
							if (finalTimer > 0)
								finalTimer -= Time.deltaTime;
							else {
								DontDestroyOnLoad (player.gameObject);
								SceneManager.LoadScene (nextScene);
							}
						}
					}
				} else
					stageClearTimer -= Time.deltaTime;
			}
			player = livePlayer.GetComponent<PlayerScript> ();
			if (player.GotLife) {
				lifeNum++;
				player.GotLife = false;
			}
			pos = livePlayer.transform.position;
			shotLevel = player.shotLevel;
			shotElement = player.shotElement;
			SetElement1 = player.setElement;
			SetElement2 = player.setElement2;
			shoot = player.shoot;
			player.currentLives = lifeNum;
		}
		else if (lifeNum > 0) {
			shotLevel -= 50;
			var playerTransform = Instantiate (playerPrefab) as Transform;
			playerTransform.position = pos;
			livePlayer = GameObject.FindGameObjectWithTag("Char");
			player = livePlayer.GetComponent<PlayerScript>();
			player.shotLevel = shotLevel;
			player.shotElement = shotElement;
			player.setElement = SetElement1;
			player.setElement2 = SetElement2;
			player.shoot = shoot;
			lifeNum--;
			player.currentLives = lifeNum;
		} else {
			sprite = GameObject.FindGameObjectWithTag ("GameOver").GetComponent<SpriteRenderer> ();
			if (sprite != null) {
				if (sprite.color != Color.black) {
					if (timer <= 0) {
						sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + 0.05f);
						timer = fixedTimer;
					} else {
						timer -= Time.deltaTime;
					}
				} else {
					sprite2 = GameObject.FindGameObjectWithTag ("GameOverText").GetComponent<SpriteRenderer> ();
					if (sprite2 != null) {
						if (sprite2.color != Color.white) {
							if (timer <= 0) {
								sprite2.color = new Color (sprite2.color.r, sprite2.color.g, sprite2.color.b, sprite2.color.a + 0.05f);
								timer = fixedTimer;
							} else {
								timer -= Time.deltaTime;
							}
						} else {
							if (finalTimer > 0)
								finalTimer -= Time.deltaTime;
							else
								SceneManager.LoadScene ("MainMenu");
						}
					}
				}
			}
		}
	}
}
