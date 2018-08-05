using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShieldScript : MonoBehaviour {
	private PlayerScript player;
	private SpriteRenderer sprite;
	private BoxCollider2D collis;
	private float magicCooldown;
	private float magicCooldownTime = 1f;
	public bool hit = false;

	void Start () {
		player = transform.parent.gameObject.GetComponent<PlayerScript>();	
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
			// Magic consumption
			if (magicCooldown > 0){
				magicCooldown -= Time.deltaTime;
			}
			if (magicCooldown <= 0) {
				player.magic -= 1;
				magicCooldown = magicCooldownTime;
			}
		} else  {
			sprite.enabled = false;
			collis.enabled = false;
		}
	}
}
