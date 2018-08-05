using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLevelScript : MonoBehaviour {
	private PlayerScript player;
	// Use this for initialization

	// public int player.shotElement = 0;
	// 0 - None
	// 1 - Water
	// 2 - Earth
	// 3 - Air
	// 4 - Fire
	public Transform shotPrefab0; public Transform shotPrefab1; public Transform shotPrefab2; public Transform shotPrefab3; public Transform shotPrefab4; public Transform shotPrefab5; public Transform optionPrefab0; public Transform optionPrefab1; public Transform optionPrefab2; public Transform optionPrefab3; public Transform optionPrefab4; public Transform optionPrefab5;
	public WeaponScript[] optionShots; 
	public SpriteRenderer[] optionGraphics;
	void Start () {
		player = GetComponent<PlayerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.shotLevel < 100) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab0;
					weapon.shootingRate = 0.35f;
				}
		} else if ((player.shotLevel >= 100)&&(player.shotLevel < 200)) {
			if (player.shotElement == 0) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab0;
					weapon.shootingRate = 0.15f;
				}
			} else if (player.shotElement == 1) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab1;
					weapon.shootingRate = 0.3f;
				}
			} else if (player.shotElement == 2) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab2;
					weapon.shootingRate = 0.6f;
				}
			} else if (player.shotElement == 3) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab3;
					weapon.shootingRate = 0.25f;
				}
			} else if (player.shotElement == 4) {
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab4;
					weapon.shootingRate = 0.15f;
				}
			}
		} else if (player.shotLevel >= 200) {
			if (player.shotElement == 0) {
				
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab0;
					weapon.shootingRate = 0.15f;
				}
				optionShots = GetComponentsInChildren<WeaponScript> ();
				optionGraphics = GetComponentsInChildren<SpriteRenderer> ();
				if (optionShots[2] != null) {
					optionShots[2].shotPrefab = optionPrefab0;
					optionShots[2].shootingRate = 0.25f;
				}
				if (optionShots[1] != null) {
					optionShots[1].shotPrefab = optionPrefab0;
					optionShots[1].shootingRate = 0.25f;
				}
				if (optionGraphics [2] != null)
					optionGraphics [2].color = new Color (1, 1, 1, 1);
				if (optionGraphics [1] != null)
					optionGraphics [1].color = new Color (1, 1, 1, 1);
				
			} else if (player.shotElement == 1) {
				
				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab1;
					weapon.shootingRate = 0.3f;
				}
				optionShots = GetComponentsInChildren<WeaponScript> ();
				optionGraphics = GetComponentsInChildren<SpriteRenderer> ();
				if (optionShots[2] != null) {
					optionShots[2].shotPrefab = optionPrefab1;
					optionShots[2].shootingRate = 0.35f;
				}
				if (optionShots[1] != null) {
					optionShots[1].shotPrefab = optionPrefab1;
					optionShots[1].shootingRate = 0.35f;
				}
				if (optionGraphics [2] != null)
					optionGraphics [2].color = new Color (0, 1, 1, 1);
				if (optionGraphics [1] != null)
					optionGraphics [1].color = new Color (0, 1, 1, 1);
			} else if (player.shotElement == 2) {

				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab2;
					weapon.shootingRate = 0.5f;
				}
				optionShots = GetComponentsInChildren<WeaponScript> ();
				optionGraphics = GetComponentsInChildren<SpriteRenderer> ();
				if (optionShots[2] != null) {
					optionShots[2].shotPrefab = optionPrefab2;
					optionShots[2].shootingRate = 0.8f;
				}
				if (optionShots[1] != null) {
					optionShots[1].shotPrefab = optionPrefab2;
					optionShots[1].shootingRate = 0.8f;
				}
				if (optionGraphics [2] != null)
					optionGraphics [2].color = new Color (0, 1, 0, 1);
				if (optionGraphics [1] != null)
					optionGraphics [1].color = new Color (0, 1, 0, 1);
			} else if (player.shotElement == 3) {

				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab3;
					weapon.shootingRate = 0.25f;
				}
				optionShots = GetComponentsInChildren<WeaponScript> ();
				optionGraphics = GetComponentsInChildren<SpriteRenderer> ();
				if (optionShots[2] != null) {
					optionShots[2].shotPrefab = optionPrefab3;
					optionShots[2].shootingRate = 0.7f;
				}
				if (optionShots[1] != null) {
					optionShots[1].shotPrefab = optionPrefab5;
					optionShots[1].shootingRate = 0.7f;
				}
				if (optionGraphics [2] != null)
					optionGraphics [2].color = new Color (0.75f, 0, 1, 1);
				if (optionGraphics [1] != null)
					optionGraphics [1].color = new Color (0.75f, 0, 1, 1);
			} else if (player.shotElement == 4) {

				WeaponScript weapon = GetComponent<WeaponScript> ();
				if (weapon != null) {
					weapon.shotPrefab = shotPrefab5;
					weapon.shootingRate = 0.15f;
				}
				optionShots = GetComponentsInChildren<WeaponScript> ();
				optionGraphics = GetComponentsInChildren<SpriteRenderer> ();
				if (optionShots[2] != null) {
					optionShots[2].shotPrefab = optionPrefab4;
					optionShots[2].shootingRate = 0.05f;
				}
				if (optionShots[1] != null) {
					optionShots[1].shotPrefab = optionPrefab4;
					optionShots[1].shootingRate = 0.05f;
				}
				if (optionGraphics [2] != null)
					optionGraphics [2].color = new Color (1, 0.75f, 0.5f, 1);
				if (optionGraphics [1] != null)
					optionGraphics [1].color = new Color (1, 0.75f, 0.5f, 1);
			}
		}
	}	
}
