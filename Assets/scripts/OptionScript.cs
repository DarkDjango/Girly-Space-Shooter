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
		if (player.shotLevel < 200)
			optionEnabled = false;
		else {
			optionEnabled = true;
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
