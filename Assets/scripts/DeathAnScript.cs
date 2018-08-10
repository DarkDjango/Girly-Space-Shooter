using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnScript : MonoBehaviour {
	public Transform boomPrefab;
	public float Timer;
	private HealthScript health;
	private SpriteRenderer mob;

	void Start () {
		health = gameObject.GetComponent<HealthScript> ();
	}
	
	// Update is called once per frame
	void OnDestroy()
	{
		if ((health != null) && (health.hp<=0)) {
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
}
