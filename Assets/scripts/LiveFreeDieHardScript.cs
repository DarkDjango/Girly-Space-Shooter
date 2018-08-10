using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveFreeDieHardScript : MonoBehaviour {


	private MoveScript enemyMove;
	public float interval = 0.17f, interval2 = 4f;
	private float timer, timer2;
	public float speedBoost;
	// Use this for initialization
	void Start () {
		enemyMove = GetComponent<MoveScript> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyMove.enabled) {
			if (timer >= 0) {
				timer -= Time.deltaTime;
			}
			if (timer < 0) {
				enemyMove.speed.x = enemyMove.speed.x / 2;
				enemyMove.speed.y = enemyMove.speed.y / 2;
				timer = interval;
			}
			if (timer2 >= 0) {
				timer2 -= Time.deltaTime;
			}
			if (timer2 < 0) {
				enemyMove.speed.x = speedBoost;
				enemyMove.speed.y = speedBoost;
				timer2 = interval2;
			}
		}
	}
}
