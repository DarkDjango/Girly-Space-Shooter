using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnScript : MonoBehaviour {
	public Transform boomPrefab;
	public float Timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDestroy()
	{
		var boomTransform = Instantiate(boomPrefab) as Transform;
		BoomScript boom = boomTransform.gameObject.GetComponent<BoomScript>();
		// Assign position
		boomTransform.position = transform.position;
		if (boom != null)
		{
			boom.timer = Timer;
		}
	}
}
