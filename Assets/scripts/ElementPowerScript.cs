using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPowerScript : MonoBehaviour {


	public int shotElement;
	public bool powerGet = false;
	// Use this for initialization
	void Start () {

	}
		
	void Update () {
		if (powerGet)
			Destroy (gameObject);
	}
}
