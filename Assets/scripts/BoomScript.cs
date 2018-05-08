using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour {

	// Use this for initialization
	public float timer;
	void Start()
	{
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
