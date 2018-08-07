using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour {

	public Transform loopPrefab;
	public Transform nextSensor;
	private bool BackGenerated;
	public bool checkpoint = false;
	void Update ()
	{
		if (checkpoint) {
			var newBackground = Instantiate (loopPrefab, transform.position + new Vector3 (42.35f, 0), Quaternion.identity, transform.parent) as Transform;
			var newSensor = Instantiate (nextSensor, transform.position + new Vector3 (42.35f, 0), transform.rotation, transform.parent) as Transform;
			BackgroundLoop loop = newSensor.transform.GetComponent<BackgroundLoop> ();
			loop.checkpoint = false;
			Destroy (gameObject);
		}
	}
}