using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour {
	private PlayerScript player;
	private SpriteRenderer sprite;
	private WeaponScript weapon;
	private bool optionEnabled = false;
	// Use this for initialization
	void Start () {
		player = transform.parent.gameObject.GetComponent<PlayerScript>();	
		sprite = GetComponent<SpriteRenderer>();
		weapon = GetComponent<WeaponScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.shotLevel < 100)
			optionEnabled = false;
		else {
			optionEnabled = true;
			if (player.shotLevel >= 200) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					// false because the player is not an enemy
					weapon.shootingRate = 0.15f;
				}
			} else
				weapon.shootingRate = 0.25f;
		}
		if (optionEnabled) {
			sprite.enabled = true;
			if (player.shoot)
				weapon.Attack(false);
		}
		else
			sprite.enabled = false;
	}
}
