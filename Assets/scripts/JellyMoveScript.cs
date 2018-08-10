using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMoveScript : MonoBehaviour {

	private MoveScript enemyMove;
	public float interval = 0.17f;
	public float speedBoost;
	private float timer;
	// Use this for initialization
	void Start () {
		enemyMove = GetComponent<MoveScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyMove.enabled) {
			if (timer > 0) {
				timer -= Time.deltaTime;
			}
			if (timer <= 0) {
				enemyMove.speed.x = enemyMove.speed.x / 2;
				timer = interval;
			}
			if (enemyMove.speed.x <= 0.1)
				enemyMove.speed.x = speedBoost;
		}
	}
}
