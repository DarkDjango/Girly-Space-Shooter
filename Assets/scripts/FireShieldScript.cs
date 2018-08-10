using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShieldScript : MonoBehaviour {
	private PlayerScript player;
	private SpriteRenderer sprite;
	private BoxCollider2D collis;
	private HealthScript health;
	private float magicCooldown;
	private float magicCooldownTime = 0.15f;
	public bool hit = false;

	void Start () {
		player = transform.parent.gameObject.GetComponent<PlayerScript>();	
		health = player.GetComponent<HealthScript> ();
		sprite = GetComponent<SpriteRenderer>();
		collis = GetComponent<BoxCollider2D> ();
	}
	void Update () {
		if (hit) {
			player.magic -= 12;
			hit = false;
		}
		if ((player.shieldActive)&&(player.setElement2==4)) {
			sprite.enabled = true;
			collis.enabled = true;
			if (health.hp == 1)
				health.hp = 2;
			// Magic consumption
			if (magicCooldown > 0){
				magicCooldown -= Time.deltaTime;
			}
			if (magicCooldown <= 0) {
				player.magic -= 8;
				magicCooldown = magicCooldownTime;
			}
		} else  {
			sprite.enabled = false;
			collis.enabled = false;
		}
	}
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) {
			if (shot.isEnemyShot) {
				player.magic -= 8;
				Destroy (shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}
