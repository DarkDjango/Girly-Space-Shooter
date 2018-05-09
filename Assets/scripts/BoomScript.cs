﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour {

	// Use this for initialization
	public float timer;
	public bool isEnemyDeath = true;

	private AudioSource audio_death;

	void Start(){

		audio_death = GetComponent<AudioSource>();
		if(isEnemyDeath){
			audio_death.clip = Resources.Load("sounds/enemy_death.wav") as AudioClip;
		}

	}

	void Update()
	{

		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			Destroy(gameObject);
		}
	}
}
