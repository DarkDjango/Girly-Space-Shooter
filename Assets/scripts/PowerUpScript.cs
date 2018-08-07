using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public int shotXP;
	public bool powerGet = false;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (powerGet)
			Destroy (gameObject);
	}
}
