﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {



	/// 1 - The speed of the character
	public Vector2 speed = new Vector2(25, 25);

	// 2 - Store the movement and the component
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
	public int shotElement;
	// 0 - None
	// 1 - Water
	// 2 - Earth
	// 3 - Air
	// 4 - Fire
	public int shotLevel;
	public bool shoot = true;
	public bool switchElement = false;
	private float switchTimer = 1;
	// Use this for initialization

	/// 3 - Swipe Controls
	private Vector2 touchOrigin = -Vector2.one;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// 3 - Retrieve axis information
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
            
	        float inputX = Input.GetAxis("Horizontal");
			float inputY = Input.GetAxis("Vertical");
	            
	        if(inputX != 0){
	            inputY = 0;
	        }
	        
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            
        	if (Input.touchCount > 0){
                
                //Store the first touch detected
                Touch myTouch = Input.touches[0];
                
                if (myTouch.phase == TouchPhase.Began){
                    touchOrigin = myTouch.position;
                }
                
                else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0){
                    Vector2 touchEnd = myTouch.position;
                    float x = touchEnd.x - touchOrigin.x;
                    float y = touchEnd.y - touchOrigin.y;
                    touchOrigin.x = -1;
                    
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        horizontal = x > 0 ? 1 : -1;
                    else
                        vertical = y > 0 ? 1 : -1;
                }
            }
            
        #endif 


		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		// 5 - Shooting
		//shoot = Input.GetButton("Fire1");
		//shoot |= Input.GetButton("Fire2");
		if (shoot) {
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}


		// 5.5 Element switching button
		switchElement = Input.GetButton ("Fire3");
		if (switchTimer > 0) {
			switchTimer -= Time.deltaTime;
		}

		if ((switchElement)&&(switchTimer <= 0)) {
			shotElement++;
			if (shotElement > 4)
				shotElement = 0;
			switchTimer = 1;
		}

		// 6 - Make sure we are not outside the camera bounds
	    var dist = (transform.position - Camera.main.transform.position).z;

	    var leftBorder = Camera.main.ViewportToWorldPoint(
	      new Vector3(0, 0, dist)
	    ).x;

	    var rightBorder = Camera.main.ViewportToWorldPoint(
	      new Vector3(1, 0, dist)
	    ).x;

	    var topBorder = Camera.main.ViewportToWorldPoint(
	      new Vector3(0, 0, dist)
	    ).y;

	    var bottomBorder = Camera.main.ViewportToWorldPoint(
	      new Vector3(0, 1, dist)
	    ).y;

	    transform.position = new Vector3(
	      Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
	      Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
	      transform.position.z
	    );

		
	}

	void FixedUpdate()
	{
		// 6 - Get the component and store the reference
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// 7 - Move the game object
		rigidbodyComponent.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		// Collision with enemy
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		PowerUpScript powerup = collision.gameObject.GetComponent<PowerUpScript> ();
		if (enemy != null)
		{
			// Kill the enemy
	//		HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
	//		if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

			damagePlayer = true;
		}
		if (powerup != null) {
			shotLevel += powerup.shotXP;
			powerup.powerGet = true;
		}
		// Damage the player
		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1, false);
		}
	}
}
