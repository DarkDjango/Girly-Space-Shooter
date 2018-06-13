using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleAcelScript : MonoBehaviour {

	private MoveScript shotMove;
	public float interval = 0.17f;
	private float timer;
	// Use this for initialization
	void Start () {
		shotMove = GetComponent<MoveScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (shotMove.speed.x < 20) {
			if (timer > 0) {
				timer -= Time.deltaTime;
			}
			if (timer <= 0) {
				shotMove.speed.x = shotMove.speed.x * 2;
				timer = interval;
			}
		} else if (shotMove.speed.x > 20)
			shotMove.speed.x = 20;
	}
}
