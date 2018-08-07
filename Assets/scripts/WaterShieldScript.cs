using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShieldScript : MonoBehaviour {

	private PlayerScript player;
	private SpriteRenderer sprite;
	private BoxCollider2D collis;
	private HealthScript health;
	private float magicCooldown;
	private float magicCooldownTime = 0.25f;

	void Start () {
		player = transform.parent.gameObject.GetComponent<PlayerScript>();	
		health = player.GetComponent<HealthScript> ();
		sprite = GetComponent<SpriteRenderer>();
		collis = GetComponent<BoxCollider2D> ();
	}
	void Update () {
		if ((player.shieldActive)&&(player.setElement2==1)) {
			sprite.enabled = true;
			collis.enabled = true;
			health.reflect = true;
			// Magic consumption
			if (health.shotReflected) {
				player.magic -= 16;
				health.shotReflected = false;
			}
			if (magicCooldown > 0){
				magicCooldown -= Time.deltaTime;
			}
			if (magicCooldown <= 0) {
				player.magic -= 4;
				magicCooldown = magicCooldownTime;
			}
		} else  {
			sprite.enabled = false;
			collis.enabled = false;
			health.reflect = false;
		}
	}
}
