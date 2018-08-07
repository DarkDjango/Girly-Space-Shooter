using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShieldScript : MonoBehaviour {
	private PlayerScript player;
	private SpriteRenderer sprite;
	private BoxCollider2D collis;
	private MercyScript mercy;
	private bool quickened = false;
	private float magicCooldown;
	private float magicCooldownTime = 0.15f;

	void Start () {
		player = transform.parent.gameObject.GetComponent<PlayerScript>();	
		mercy = player.GetComponent<MercyScript> ();
		sprite = GetComponent<SpriteRenderer>();
		collis = GetComponent<BoxCollider2D> ();
	}
	void Update () {
		if ((player.shieldActive)&&(player.setElement2==3)) {
			if (!quickened) {
				player.speed.x = 15;
				player.speed.y = 7.5f;
				quickened = true;
			}
			sprite.enabled = true;
			collis.enabled = true;
			mercy.isInvencible = true;
			mercy.timer = 0.1f;
			// Magic consumption
			if (magicCooldown > 0){
				magicCooldown -= Time.deltaTime;
			}
			if (magicCooldown <= 0) {
				player.magic -= 4;
				magicCooldown = magicCooldownTime;
			}
		} else  {
			if (quickened) {
				player.speed.x = 10;
				player.speed.y = 5;
				quickened = false;
			}
			sprite.enabled = false;
			collis.enabled = false;
		}
	}
}
