using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldScript : MonoBehaviour {
	private PlayerScript player;
	private SpriteRenderer sprite;
	private BoxCollider2D collis;
	private HealthScript health;
	private bool slowed = false;
	private float magicCooldown;
	private float magicCooldownTime = 0.25f;

	void Start () {
		player = transform.parent.gameObject.GetComponent<PlayerScript>();	
		health = player.GetComponent<HealthScript> ();
		sprite = GetComponent<SpriteRenderer>();
		collis = GetComponent<BoxCollider2D> ();
	}
	void Update () {
		if ((player.shieldActive)&&(player.setElement2==2)) {
			if (!slowed) {
				player.speed.x = 5;
				player.speed.y = 2.5f;
				slowed = true;
			}
			sprite.enabled = true;
			collis.enabled = true;
			if (health.hp == 1)
				health.hp = 2;
			// Magic consumption
			if (magicCooldown > 0){
				magicCooldown -= Time.deltaTime;
			}
			if (magicCooldown <= 0) {
				player.magic -= 4;
				magicCooldown = magicCooldownTime;
			}
		} else  {
			if (slowed) {
				player.speed.x = 10;
				player.speed.y = 5;
				slowed = false;
			}
			sprite.enabled = false;
			collis.enabled = false;
			if (health.hp >= 2)
				health.hp = 1;
		}
	}
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) {
			if (shot.isEnemyShot) {
				player.magic -= 48;
				Destroy (shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}
