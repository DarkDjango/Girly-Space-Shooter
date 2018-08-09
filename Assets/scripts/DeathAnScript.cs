using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnScript : MonoBehaviour {
	public Transform boomPrefab;
	public float Timer;
	
	private SpriteRenderer mob;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDestroy()
	{
		var boomTransform = Instantiate(boomPrefab) as Transform;
		
		
		mob = GetComponent<SpriteRenderer>();
		if(mob.IsVisibleFrom(Camera.main)){
			BoomScript boom = boomTransform.gameObject.GetComponent<BoomScript>();
			boomTransform.position = transform.position;
			if (boom != null){
				boom.timer = Timer;
			}
		}
		
		
	}
}
