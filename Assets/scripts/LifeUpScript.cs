using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpScript : MonoBehaviour {

	// Use this for initialization
	public bool powerGet = false;
	void Update () {
		if (powerGet)
			Destroy (gameObject);
	}
}
