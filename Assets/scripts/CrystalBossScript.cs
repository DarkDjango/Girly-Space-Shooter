using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBossScript : MonoBehaviour {
	private bool hasSpawn, inPosition;
	private int crystalStage = 1;
	private float crystalTimer = 4f;
	public float timer = 5f;
	private HealthScript health;
	private MoveScript moveScript;
	private Animator anim;
	private WeaponScript[] weapons;
	private Collider2D coliderComponent;
	private SpriteRenderer rendererComponent;
	//  private AudioSource audioComponent;
	private float originalDirY;

	void Awake()
	{
			// Retrieve the weapon only once
		weapons = GetComponentsInChildren<WeaponScript>();
		health = GetComponent<HealthScript> ();
			// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
		anim = GetComponent<Animator> ();
		coliderComponent = GetComponent<Collider2D>();

		rendererComponent = GetComponent<SpriteRenderer>();

			//        audioComponent = GetComponent<AudioSource>();

	}

		// 1 - Disable everything
		void Start()
		{
			hasSpawn = false;
			// Disable everything
			// -- Audio
			//      audioComponent.enabled = false;
			// -- collider
			coliderComponent.enabled = false;
			// -- Moving
			moveScript.enabled = true;
			// -- Shooting
			foreach (WeaponScript weapon in weapons)
			{
				weapon.enabled = false;
			}

		}

	void Update()
	{
		anim.SetInteger ("CrystalStage", crystalStage);
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			if (rendererComponent.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			if (timer > 0)
				timer -= Time.deltaTime;
			else
				moveScript.speed.x = 0;
			if (crystalStage == 3)
				health.reflect = true;
			else
				health.reflect = false;
			if (crystalTimer > 0)
				crystalTimer -= Time.deltaTime;
			else {
				if (crystalStage == 1) {
					crystalStage = 2;
					crystalTimer = 0.5f;
				} else if (crystalStage == 2) {
					crystalStage = 3;
					crystalTimer = Random.Range (3f, 5f);
				} else if (crystalStage == 3) {
					crystalStage = 1;
					crystalTimer = Random.Range (5f, 6.5f);
				}
			}
			moveScript.direction = new Vector2(moveScript.direction.x, Mathf.Sin(Time.time)*originalDirY);
			// Auto-fire
			if (crystalStage == 1) {
				foreach (WeaponScript weapon in weapons) {
					if (weapon != null && weapon.enabled && weapon.CanAttack) {
						weapon.Attack (true);
					}
				}
			}
			// 4 - Out of the camera ? Destroy the game object.
			if (rendererComponent.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}

		// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
	
		// Enable everything
		// -- Audio
			//    audioComponent.enabled = true;
			// -- Collider
		coliderComponent.enabled = true;
		// -- Moving
		moveScript.enabled = true;
			// -- Shooting
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}

		originalDirY = moveScript.direction.y;
		moveScript.speed = new Vector2(1, 1);

	}
}