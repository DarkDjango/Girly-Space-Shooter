using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public int shotXP;
	public bool powerGet = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Physics2D.IgnoreLayerCollision (0, 7);
	}
	void Update () {
		if (powerGet)
			Destroy (gameObject);
	}
}
