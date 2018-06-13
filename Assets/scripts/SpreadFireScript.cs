using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadFireScript : MonoBehaviour {

	private WeaponScript[] weapons;
	// Use this for initialization
	void Start () {	
		weapons = GetComponentsInChildren<WeaponScript>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (WeaponScript weapon in weapons)
		{
			if (weapon != null && weapon.enabled && weapon.CanAttack)
			{
				weapon.Attack(false);
			}
		}
		Destroy (gameObject);
	}
}
